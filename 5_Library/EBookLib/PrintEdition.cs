using System;

namespace EBookLib
{
    /// <summary>
    /// Класс печатного издания.
    /// </summary>
    public abstract class PrintEdition : IPrinting 
    {
        /// <summary>
        /// Событие сигнализирующее о печати книги.
        /// </summary>
        public event EventHandler onPrint;

        /// <summary>
        /// Автореалезуемое свойство названия издания.
        /// </summary>
        public string Name { set; get; }

        /// <summary>
        /// Автореалезуемое свойство количесвта страниц в издании.
        /// </summary>
        public int Pages { set; get; }

        /// <summary>
        /// Конструктор класса.
        /// </summary>
        /// <param name="name">Название издания.</param>
        /// <param name="pages">Количество страниц в издании.</param>
        /// <exception cref="PrintEditionException">
        /// Ошибка сигнализирущая о некорректном количестве страниц в издании.
        /// </exception>
        public PrintEdition(string name, int pages)
        {
            if (pages < 0)
                throw new PrintEditionException("Количесвто страниц не может быть меньше нуля.");
            Name = name;
            Pages = pages;
        }

        /// <summary>
        /// Метод предоставляющий доступ к событию onPrint.
        /// </summary>
        public void Print()
        {
            onPrint?.Invoke(this, EventArgs.Empty);
        }

        /// <summary>
        /// Метод возвращающий данные об издании.
        /// </summary>
        /// <returns>Строка с данными об издании.</returns>
        public override string ToString()
        {
            return $"name={Name}; pages={Pages}";
        }
    }
}
