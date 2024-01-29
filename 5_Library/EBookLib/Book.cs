using System;

namespace EBookLib
{
    /// <summary>
    /// Класс книги.
    /// </summary>
    public class Book : PrintEdition
    {
        /// <summary>
        /// Автореалезуемое свойство имени автора.
        /// </summary>
        public string Author { set; get; }

        /// <summary>
        /// Конструктор класса.
        /// </summary>
        /// <param name="author">Имя автора книги.</param>
        /// <param name="name">Название книги.</param>
        /// <param name="pages">Количество страниц в книге.</param>
        public Book(string author, string name, int pages) : base(name, pages)
        {
            Author = author;
        }

        /// <summary>
        /// Метод возвращающий данные о книге.
        /// </summary>
        /// <returns>Строка с данными о книге.</returns>
        public override string ToString()
        {
            return base.ToString() + $"; author={Author}";
        }
    }
}
