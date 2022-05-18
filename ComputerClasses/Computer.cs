using System;
using System.Collections.Generic;

namespace ComputerClasses
{
    /// <summary>
    /// Класс, определяющий поведение компьютера
    /// </summary>
    public class Computer : ScrapMetal
    {
        public int Cost {get; private set;}

        private bool isOn;
        private List<Components> allComputerComponents = new List<Components>();

        private const int DEFAULT_COST = 10;
        private const int DEFAULT_COUNT_METAL = 15;
        /// <summary>
        /// Конструктор класса
        /// </summary>
        /// <param name="countMetal">количество металла, получаемое при сдаче на металлолом</param>
        /// <param name="cost">Стоимость компьютера, для купли-продажи</param>
        /// <param name="allComponents">список комплектующих компьютера</param>
        public Computer(int countMetal = DEFAULT_COUNT_METAL, int cost = DEFAULT_COST, List<Components> allComponents = null)
        {
            CountMetal = countMetal;
            Cost = cost;
            isOn = false;
            if (allComponents != null)
            {
                allComputerComponents = allComponents;
                return;
            }
            // на случай, если списка комплектующих, не поступило на вход, заполняем комплектующими с дефолтными значениями
            allComputerComponents.Add(new MotherBoard());
        }

        /// <summary>
        /// Метод, который включает/перезагружает компьютер
        /// </summary>
        public void OnComputer()
        {
            if (!WorkCheck())
            {
                Console.WriteLine("Компьютер не исправен, поэтому не может быть включен, пожалуйста замените комплектующие!");
                return;
            }
            isOn = true;
            Console.WriteLine("Компьютер включен");
        }
        /// <summary>
        /// устанавливает приложение на данный компьютер
        /// </summary>
        /// <param name="application">приложение, которое необходимо установить</param>
        public void DownloadApp(Application application)
        {
            if (!isOn)
            {
                Console.WriteLine("Компьютер не включен, поэтому установка приложения невозможна, пожалуйста включите компьютер!");
                return;
            }

            AppComputerOffCheck(application.IsOffComputer);
            AppMotherBoardDestroyCheck(application.IsDestroyMotherBoard);
        }

        /// <summary>
        /// Заменяет материнскую плату на данном компьютере
        /// </summary>
        public void ChangeMotherBoard()
        {
            MotherBoard mother = SearchComponents(nameof(MotherBoard)) as MotherBoard;
            mother.ChangeComponent();
            Console.WriteLine("Произошла замена материнской платы");
        }
        /// <summary>
        /// Проверка на работоспособность компьютера
        /// </summary>
        /// <returns>true - если работает, иначе false</returns>
        public bool WorkCheck()
        {
            for (int i = 0; i < allComputerComponents.Count; i++)
            {
                if (!allComputerComponents[i].IsWorking)
                {
                    return false;
                }
            }
            return true;
        }
        /// <summary>
        /// Возвращает количество металла со всех компонентов компьютера
        /// </summary>
        /// <returns></returns>
        public int MetalAllComponents()
        {
            int countMetal = 0;
            for(int i = 0; i < allComputerComponents.Count; i++)
            {
                countMetal += allComputerComponents[i].CountMetal;
            }
            return countMetal;
        }
        /// <summary>
        /// Возвращает количество металла с конкретного компонента
        /// </summary>
        /// <param name="nameComponent">название компонента</param>
        /// <returns></returns>
        public int MetalComponent(string nameComponent)
        {
            Components component = SearchComponents(nameComponent);
            if (component != null)
            {
                return component.CountMetal;
            }
            return 0;
        }
        /// <summary>
        /// получить информацию о компьютере
        /// </summary>
        public void Info()
        {
            Console.WriteLine("Количество металла: " + CountMetal + " Стоимость: " + Cost + " Включен: " + isOn);
            for(int i = 0; i < allComputerComponents.Count; i++)
            {
                allComputerComponents[i].Info();
            }
        }

        private void AppComputerOffCheck(bool isOffComputer)
        {
            if (isOffComputer)
            {
                Console.WriteLine("Установка приложения выключила компьютер");
                isOn = false;
            }
        }

        private Components SearchComponents(string nameComponent)
        {
            for (int i = 0; i < allComputerComponents.Count; i++)
            {
                if (allComputerComponents[i].NameComponent == nameComponent)
                {
                    return allComputerComponents[i];
                }
            }
            Console.WriteLine("Компонент не был найден!");
            return null;
        }
        private void AppMotherBoardDestroyCheck(bool isDestroyMotherBoard)
        {
            if (!isDestroyMotherBoard)
            {
                return;
            }

            MotherBoard mother = SearchComponents(nameof(MotherBoard)) as MotherBoard;

            if(mother != null) 
            { 
                mother.DestroyComponent();
                isOn = false;
                Console.WriteLine("Установка приложения сожгла материнскую плату");
                return;
            }
        }
    }
}