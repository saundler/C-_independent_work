using System;
using System.Collections;
using System.Collections.Generic;

namespace EBookLib
{
    /// <summary>
    /// Класс библиотеки.
    /// </summary>
    /// <typeparam name="T">Тип объектов хранящихся в библиотеке.</typeparam>
    public class MyLibrary<T> : IEnumerable<T>
        where T : PrintEdition
    {
        public List<T> library = new List<T>();                       // Список объектов хранящихся в библиотеке.

        /// <summary>
        /// Событие сигнализирующее о том, что из библиотеки были изъяты все книги,
        /// названия которых начинаются с определенной буквы.
        /// </summary>
        public event EventHandler<FirstLetterEventArgs> onTake;

        /// <summary>
        /// Свойсто возвращающее среднее количество страниц в книге.
        /// </summary>
        public double AverageBooks
        {
            get 
            {
                int numberOfPages = 0, count = 0;
                foreach (T edition in library)
                {
                    if(edition is Book)
                    {
                        numberOfPages += edition.Pages;
                        count++;
                    }
                }
                if(count == 0)
                    return count;
                return (double)numberOfPages / count; 
            }
        }

        /// <summary>
        /// Свойсто возвращающее среднее количество страниц в журнале.
        /// </summary>
        public double AverageMagazines
        {
            get
            {
                int numberOfPages = 0, count = 0;
                foreach (T edition in library)
                {
                    if (edition is Magazine)
                    {
                        numberOfPages += edition.Pages;
                        count++;
                    }
                }
                if (count == 0)
                    return count;
                return (double)numberOfPages / count;
            }
        }

        /// <summary>
        /// Метод добавляющий новый объект в библиотеку.
        /// </summary>
        /// <param name="printed">Новый объект.</param>
        public void Add(T printed)
        {
            library.Add(printed);
        }

        /// <summary>
        /// Метод предоставляющий доступ к событию onTake.
        /// </summary>
        /// <param name="start">
        /// Все объекты название которых начинается на эту букву будут удалены.
        /// </param>
        public void TakeBooks(char start)
        {
            onTake?.Invoke(this, new FirstLetterEventArgs(start));
        }

        /// <summary>
        /// Метод возвращающий данные о библиотеке.
        /// </summary>
        /// <returns>Строка с данными о библиотеке.</returns>
        public override string ToString()
        {
            int numberOfPages = 0;
            string information = "";
            foreach (PrintEdition edition in library)
            {
                numberOfPages += edition.Pages;
                information += edition + "\n";
            }
            return "Общее количесвто страниц во всех изданиях: " + numberOfPages + "\n" + information;
        }

        /// <summary>
        /// Метод возвращающий перечислитель, который выполняет итерацию по коллекции.
        /// </summary>
        /// <returns>перечислитель, который выполняет итерацию по коллекции.</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return new MyLibraryEnumerator<T>(library);
        }

        /// <summary>
        /// Метод возвращающий перечислитель, который выполняет итерацию по коллекции.
        /// </summary>
        /// <returns>перечислитель, который выполняет итерацию по коллекции.</returns>
        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            return new MyLibraryEnumerator<T>(library);
        }

        /// <summary>
        /// Класс перечеслителя для библиотеки.
        /// </summary>
        /// <typeparam name="U">Тип объектов хранящихся в библиотеке.</typeparam>
        class MyLibraryEnumerator<U> : IEnumerator<U>
        {
            private int index = -1;     // Индекс итератора.
            private List<U> library;    // Список объектов хранящихся в библиотеке.

            /// <summary>
            /// Конструктор класса.
            /// </summary>
            /// <param name="library">Список объектов хранящихся в библиотеке.</param>
            public MyLibraryEnumerator(List<U> library)
            {
                this.library = library;
            }

            /// <summary>
            /// Возвращает элемент коллекции в текущей позиции перечислителя.
            /// </summary>
            U IEnumerator<U>.Current => library[index];

            /// <summary>
            /// Возвращает элемент коллекции в текущей позиции перечислителя.
            /// </summary>
            object IEnumerator.Current => library[index];

            /// <summary>
            /// Метод перемещающий перечислитель к следующему элементу коллекции.
            /// </summary>
            /// <returns>Перместился ли перечеслитель.</returns>
            public bool MoveNext()
            {
                return ++index < library.Count;
            }

            /// <summary>
            /// Метод устанавливающий перечислитель в исходное положение, 
            /// которое находится перед первым элементом в коллекции.
            /// </summary>
            public void Reset()
            {
                index = -1;
            }

            /// <summary>
            /// Выполняет определяемые приложением задачи,
            /// связанные с освобождением, 
            /// высвобождением или сбросом неуправляемых ресурсов.
            /// </summary>
            public void Dispose() { }
        }
    }
}