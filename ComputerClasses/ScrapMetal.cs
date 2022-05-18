namespace ComputerClasses
{
    /// <summary>
    /// Класс, определяющий объекты, которые можно сдать на металлолом
    /// </summary>
    public abstract class ScrapMetal
    {
        /// <summary>
        /// количество металла, получаемого при сдаче на металлолом
        /// </summary>
        public int CountMetal {get; protected set;}
    }
}