using System;

namespace ComputerClasses
{
    /// <summary>
    /// Класс, определяющий комплектующие компьютера
    /// </summary>
    public abstract class Components: ScrapMetal
    {
        /// <summary>
        /// название комплектующего
        /// </summary>
        public string NameComponent {get; protected set;}
        /// <summary>
        /// Говорит о работоспособности комплектующего
        /// </summary>
        public bool IsWorking { get; private set;}

        public Components()
        {
            IsWorking = true;
        }
        /// <summary>
        /// Метод, который уничтожает комплектующее
        /// </summary>
        public void DestroyComponent()
        {
            IsWorking = false;
        }
        /// <summary>
        /// Метод, который заменяет комплектующее
        /// </summary>
        public void ChangeComponent()
        {
            IsWorking = true;
        }
        /// <summary>
        /// получить информацию о компоненте
        /// </summary>
        public void Info()
        {
            Console.WriteLine("Название компоненты: " + NameComponent);
            Console.WriteLine("Количество металла: " + CountMetal + " Работает: " + IsWorking);
        }
    }
}