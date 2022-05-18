namespace ComputerClasses
{
    /// <summary>
    /// Класс, определяющий поведение приложения в компьютере
    /// </summary>
    public class Application
    {
        /// <summary>
        /// Выключает ли данное приложение компьютер
        /// </summary>
        public bool IsOffComputer {get; private set;}
        /// <summary>
        /// Уничтожает ли материнскую плату данное приложение
        /// </summary>
        public bool IsDestroyMotherBoard {get; private set;}
        /// <summary>
        /// Конструктор класса
        /// </summary>
        /// <param name="offComputer">может ли приложение выключить компьютер</param>
        /// <param name="destroyMotherBoard">может ли приложение сжечь материнскую плату</param>
        public Application(bool offComputer = false, bool destroyMotherBoard = false)
        {
            IsOffComputer = offComputer;
            IsDestroyMotherBoard = destroyMotherBoard;
        }

    }
}