using System;
using System.Collections.Generic;
using System.Text;

namespace ComputerClasses
{
    /// <summary>
    /// Класс реализующий взаимодействие с компьютерной комнатой
    /// </summary>
    public class ComputerRoom
    {
        private int budget;

        private int countMetals;

        private List<Computer> computers = new List<Computer>();

        private const int DEFAULT_BUDGET = 200;
        /// <summary>
        /// Конструктор класса
        /// </summary>
        /// <param name="budget">деньги, которыми может располагать компьютерная комната</param>
        public ComputerRoom(int budget = DEFAULT_BUDGET)
        {
            this.budget = budget;
            countMetals = 0;
        }
        /// <summary>
        /// Покупает компьютер
        /// </summary>
        /// <param name="computer">компьютер, который покупают в компьютеную комнату</param>
        public void BuyComputer(Computer computer)
        {
            if (computer.Cost <= budget)
            {
                budget -= computer.Cost;
                computers.Add(computer);
                Console.WriteLine("Компьютер успешно куплен");
                return;
            }
            Console.WriteLine("Недостаточно средств!");
        }
        /// <summary>
        /// продажа компьютера
        /// </summary>
        /// <param name="idComputer">номер компьютера в комнате</param>
        public void SellComputer(int idComputer)
        {
            if (idComputer >= computers.Count)
            {
                Console.WriteLine("Такого компьютера не существует!");
                return;
            }

            if (!computers[idComputer].WorkCheck())
            {
                Console.WriteLine("Компьютер не подходит для продажи, почините его!");
                return;
            }

            budget += computers[idComputer].Cost;
            computers.RemoveAt(idComputer);
            Console.WriteLine("Компьютер успешно продан!");
        }
        /// <summary>
        /// Установка приложения на все компьютеры
        /// </summary>
        /// <param name="application">Приложение, которое нужно установить</param>
        public void DownloadAppAllComputers(Application application)
        {
            for (int i = 0; i < computers.Count; i++)
            {
                DownloadAppComputer(i, application);
            }
        }

        /// <summary>
        /// Установка приложения на конкретный компьютер
        /// </summary>
        /// <param name="application">Приложение, которое нужно установить</param>
        public void DownloadAppComputer(int idComputer, Application application)
        {
            if (idComputer >= computers.Count)
            {
                Console.WriteLine("Такого компьютера не существует!");
                return;
            }
            Console.WriteLine("Компьютер № " + idComputer);
            computers[idComputer].DownloadApp(application);
        }

        /// <summary>
        /// Заменить материнскую плату на конкретном компьютере
        /// </summary>
        /// <param name="idComputer">номер компьютера</param>
        public void ChangeMotherBoardComputer(int idComputer)
        {
            if (idComputer >= computers.Count)
            {
                Console.WriteLine("Такого компьютера не существует!");
                return;
            }
            Console.WriteLine("Компьютер № " + idComputer);
            countMetals += computers[idComputer].MetalComponent(nameof(MotherBoard));// так как старая материнка не нужна, она автоматом сдается на металллолом
            computers[idComputer].ChangeMotherBoard();
        }
        /// <summary>
        /// Замена материнской платы на всех компьютерах
        /// </summary>
        public void ChangeMotherBoardAllComputer()
        {
            for (int i = 0; i < computers.Count; i++)
            {
                ChangeMotherBoardComputer(i);
            }
        }
        /// <summary>
        /// сдать конкретный компьютер на металлолом
        /// </summary>
        /// <param name="idComputer">номер компьютера</param>
        public void ScrapItComputer(int idComputer)
        {
            if (idComputer >= computers.Count)
            {
                Console.WriteLine("Такого компьютера не существует!");
                return;
            }
            Console.WriteLine("Компьютер № " + idComputer);
            countMetals += computers[idComputer].CountMetal;
            countMetals += computers[idComputer].MetalAllComponents();
            computers.RemoveAt(idComputer);
            Console.WriteLine("Компьютер успешно сдан на металлолом");
        }
        /// <summary>
        /// сдать все компьютеры на металлолом
        /// </summary>
        public void ScrapItAllComputer()
        {
            for(int i = computers.Count - 1; i >= 0; i--)
            {
                ScrapItComputer(i);
            }
        }

        /// <summary>
        /// включить конкретный компьютер
        /// </summary>
        /// <param name="idComputer">номер компьютера</param>
        public void OnComputer(int idComputer)
        {
            if (idComputer >= computers.Count)
            {
                Console.WriteLine("Такого компьютера не существует!");
                return;
            }
            Console.WriteLine("Компьютер № " + idComputer);
            computers[idComputer].OnComputer();
        }
        /// <summary>
        /// Включить все компьютеры
        /// </summary>
        public void OnAllComputer()
        {
            for(int i = 0; i < computers.Count; i++)
            {
                OnComputer(i);
            }
        }
        /// <summary>
        /// Получить информацию о компьютерной комнате
        /// </summary>
        public void Info()
        {
            Console.WriteLine("бюджет: " + budget + " количество металла: " + countMetals);
            for(int i = 0; i < computers.Count; i++)
            {
                Console.WriteLine("Компьютер № " + i);
                computers[i].Info();
            }
        }
    }
}
