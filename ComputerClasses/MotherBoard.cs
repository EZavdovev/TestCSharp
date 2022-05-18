using System;
using System.Collections.Generic;
using System.Text;

namespace ComputerClasses
{
    /// <summary>
    /// Класс, определяющий материнскую плату
    /// </summary>
    public class MotherBoard: Components
    {
        private const int DEFAULT_COUNT_METAL = 5;
        /// <summary>
        /// Конструктор класса
        /// </summary>
        /// <param name="countMetal">количество металла, получаемое при сдаче на металлолом</param>
        public MotherBoard(int countMetal = DEFAULT_COUNT_METAL)
        {
            NameComponent = nameof(MotherBoard);
            CountMetal = countMetal;
        }
    }
}
