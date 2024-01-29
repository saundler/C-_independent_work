using System;
using System.Linq.Expressions;
using EBookLib;

namespace Library
{
    partial class Program
    {
        static void Main()
        {
            HashSet<char> firstLetters;             // Массив всех первых букв книг содержащихся в библиотеке.
            MyLibrary<PrintEdition> myLibrary,      // Библиотека содержащая печатные издания. 
                                    myNewLibrary;   // Библиотека сформированная в резултате работы программы.

            Console.CursorVisible = false;

            // Повтор работы.
            while (SelectCommand())
            {
                Console.Clear();

                // Приветсвие пользователя с инструкцией о дальнейших действиях.
                PrintOnScreen(ConsoleColor.White,
                              "   Здравствуйте данная программа генерирует N печатных изданий и помещает их в библиотеку\n" +
                              "    выводит созданные книги на экран, затем удаляет все издания начинающиеся\n" +
                              "    на произвольную букву и записывает информацию об оставшихся файл.\n");

                // Инициализация переменных перед началом работы программы.
                firstLetters = new HashSet<char>();
                myLibrary = new MyLibrary<PrintEdition>();
                myNewLibrary = new MyLibrary<PrintEdition>();
                CreateEditions(myLibrary, InputN());
                myLibrary.onTake += TakeHandler;

                // Вывод всех напечатанных книг.
                PrintOnScreen(ConsoleColor.Yellow, "Напечатанные книги:");
                foreach (var edition in myLibrary)
                {
                    if (edition is Book)
                    {
                        firstLetters.Add(edition.Name[0]);
                        edition.Print();
                    }
                }

                // Вывод всех изданий в библиотеке.
                PrintOnScreen(ConsoleColor.Yellow, "\nВсе издания в библиотеке:");
                Console.WriteLine(myLibrary);

                // Изъятие изданий начинающихся на случайную букву.
                if(firstLetters.Count == 0)
                    PrintOnScreen(ConsoleColor.Red, "Невозможно изъять книги из пустой библиотеки.");
                else
                    myLibrary.TakeBooks(firstLetters.ToArray()[new Random().Next(firstLetters.Count)]);

                // Вывод всех оставшихся изданий в библиотеке.
                PrintOnScreen(ConsoleColor.Yellow, "Все издания оставшиеся библиотеке:");
                Console.WriteLine(myLibrary);

                // Сериализация и десериализация библиотеки в формате json.
                // Метод возвращают булево значение, если при работе метода
                // произошла ошибка то программа не выполняет дальнейшие действия.
                if (SerializeInFile(myLibrary) || Deserialize(myNewLibrary))
                    continue;

                // Вывод всех изданий из новой библиотеки. 
                PrintOnScreen(ConsoleColor.Yellow, "Все издания прочитанные из файла:");
                Console.WriteLine(myNewLibrary);

                // Вывод параметров новой библиотеки.
                Console.WriteLine($"Общее количесвто страниц во всех книгах: {myNewLibrary.AverageBooks:f2}");
                Console.WriteLine($"Общее количесвто страниц во всех журналах: {myNewLibrary.AverageMagazines:f2} \n");
            }
        }
        

        /// <summary>
        /// Метод обработчик события onTake, сигнализирующий что
        /// удалит все книги начинающиеся на определенную букву.
        /// </summary>
        /// <param name="sender">Объект вызвавший данный метод.</param>
        /// <param name="e">Класс содержащий букву.</param>
        static void TakeHandler(object sender, FirstLetterEventArgs e)
        {
            var tempLibrary = ((MyLibrary<PrintEdition>)sender).library;    // Список печатных изданий в библиотеке.
            PrintOnScreen(ConsoleColor.Green, $"ATTENTION! Books starts with {e.firstLetter} were taken!");

            for (int i = 0; i < tempLibrary.Count; i++)
            {
                // Условие изъятия книги из библиотеки.
                if (tempLibrary[i] is Book && tempLibrary[i].Name[0] == e.firstLetter)
                {
                    tempLibrary.RemoveAt(i);
                    i--;
                }
            }
        }

        /// <summary>
        /// Обработчик события onPrint,
        /// сигнализирующий о печати книги.
        /// </summary>
        /// <param name="sender">Объект вызвавший данный метод.</param>
        /// <param name="e">Пустой класс.</param>
        static void PrintHandler(object sender, EventArgs e)
        {
            Console.WriteLine("PRINTED! " + sender);
        }

        /// <summary>
        /// Метод заполняющий библиотеку печатными изданиями.
        /// </summary>
        /// <param name="myLibrary">Библиотека печатных изданий.</param>
        /// <param name="n">Количество печатных изданий в библиотеке.</param>
        static void CreateEditions(MyLibrary<PrintEdition> myLibrary, int n)
        {
            Random rnd = new Random();
            for (int i = 0; i < n; i++)
            {
                try
                {
                    if (rnd.Next(2) == 0)
                        myLibrary.Add(new Book(GiveName(), GiveName(), rnd.Next(-10, 101)));
                    else
                        myLibrary.Add(new Magazine(rnd.Next(-10, 101), GiveName(), rnd.Next(-10, 101)));
                    myLibrary.library[i].onPrint += PrintHandler;
                }
                // Ошибка при создании издания с отрицательным числом страниц.
                catch (PrintEditionException)
                {
                    i--;
                }
            }
        }
    }
}