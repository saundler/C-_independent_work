using System;

namespace EBookLib
{
    /// <summary>
    /// Класс журнала.
    /// </summary>
    public class Magazine : PrintEdition
    {
        /// <summary>
        /// Автореалезуемое свойство периодичности издания журнала.
        /// </summary>
        public int Period { get; }

        /// <summary>
        /// Констурктор класса.
        /// </summary>
        /// <param name="period">Периодичность издания журнала.</param>
        /// <param name="name">Название книги.</param>
        /// <param name="pages">Количество страниц в книге.</param>
        public Magazine(int period, string name, int pages) : base(name, pages)
        {
            if (period < 1)
                throw new PrintEditionException("Период не может быть меньше единицы.");
            Period = period;
        }

        /// <summary>
        /// Метод возвращающий данные о журнале.
        /// </summary>
        /// <returns>Строка с данными о журнале.</returns>
        public override string ToString()
        {
            return base.ToString() + $"; period={Period}";
        }
    }
}
