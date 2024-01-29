using System;
using System.Text;
using System.Text.Json;
using EBookLib;

namespace Library
{
    /// <summary>
    /// Все методы учавствующие в записи файла.
    /// </summary>
    partial class Program
    {
        /// <summary>
        /// Метод серирализующий данные библиотеки в файл формата json.
        /// </summary>
        /// <param name="myLibrary">Сериалезующаяся библиотека.</param>
        /// <returns>Возникли ли ошибки при сериализации.</returns>
        static bool SerializeInFile(MyLibrary<PrintEdition> myLibrary)
        {
            string[] editionsInformation = new string[myLibrary.library.Count];    // Массив с данными о библиотеке.

            // Сериализация всех изданий.
            for (int i = 0; i < editionsInformation.Length; i++)
            {
                if (myLibrary.library[i] is Magazine)
                    editionsInformation[i] = JsonSerializer.Serialize((Magazine)myLibrary.library[i]);
                else
                    editionsInformation[i] = JsonSerializer.Serialize((Book)myLibrary.library[i]);
            }
            try
            {
                // Запись данных в файл типа json.
                File.WriteAllLines(@"myLibrary.json", editionsInformation, Encoding.Unicode);
            }
            // Ошибка при использовании файла другой программой.
            catch (System.IO.IOException)
            {
                PrintOnScreen(ConsoleColor.Red, "Файл используется другой програмой, пожалуйста закройте файл и повторите попытку.");
                PrintOnScreen(ConsoleColor.Yellow, "Для повтора работы программы нажмите любую клавишу.");
                Console.ReadKey();
                Console.Clear();
                return true;
            }
            return false;
        }

        /// <summary>
        /// Метод считывающий данные с записаного файла.
        /// </summary>
        /// <returns>Массив строк с данными из файла.</returns>
        static string[] ReadFile()
        {
            try
            {
                // Чтение файла сгенерированного программой.
                return File.ReadAllLines(@"myLibrary.json");
            }
            // Ошибка при ненахождении файла.
            catch (System.IO.FileNotFoundException)
            {
                PrintOnScreen(ConsoleColor.Red, "Файл не найден, пожалуйста, повторите попытку.");
                PrintOnScreen(ConsoleColor.Yellow, "Для повтора работы программы нажмите любую клавишу.");
                Console.ReadKey();
                Console.Clear();
                return new string[] { "!!!Exception!!!" };
            }
            // Ошибка при использовании файла другой программой.
            catch (System.IO.IOException)
            {
                PrintOnScreen(ConsoleColor.Red, "Файл используется другой програмой, пожалуйста закройте файл и повторите попытку.");
                PrintOnScreen(ConsoleColor.Yellow, "Для повтора работы программы нажмите любую клавишу.");
                Console.ReadKey();
                Console.Clear();
                return new string[] { "!!!Exception!!!" };
            }
        }

        /// <summary>
        /// Метод десериализующий строку в печатное издание.
        /// </summary>
        /// <typeparam name="T">Тип печатного издания.</typeparam>
        /// <param name="edition">Данные о печатном издании.</param>
        /// <param name="flag">Возникли ли ошибки при десериализации.</param>
        /// <returns>Десериализованное печатное издание.</returns>
        static T ReadEdition<T>(string edition, ref bool flag)
        {
            try
            {
                // Сериализация строки с данными в печатное издание типа <T>.
                return JsonSerializer.Deserialize<T>(edition);
            }
            // Ошибка при повреждении данных в файле.
            catch (System.Text.Json.JsonException)
            {
                PrintOnScreen(ConsoleColor.Red, "Данные файла поверждены, пожалуйста повторите попытку.");
                PrintOnScreen(ConsoleColor.Yellow, "Для повтора работы программы нажмите любую клавишу.");
                Console.ReadKey();
                Console.Clear();
                flag = true;
                return default(T);
            }
        }
        /// <summary>
        /// Метод десериализующий файл с данными о библиотеке.
        /// </summary>
        /// <param name="myLibrary">Библиотека для хранения печатных изданий.</param>
        /// <returns>Возникли ли ошибки при десериализации.</returns>
        static bool Deserialize(MyLibrary<PrintEdition> myLibrary)
        {
            bool flag = false;                 // Индикатор возникновения ошибки.
            string[] editions = ReadFile();    // Массив данных о печатных изданиях.

            // Проверка на наличие ошибок при чтении файла.
            if (editions.Contains("!!!Exception!!!"))
                return true;

            // Заполнение библиотеки данными из файла.
            for (int i = 1; i < editions.Length; i++)
            {
                if (editions[i].Contains("Period"))
                    myLibrary.Add(ReadEdition<Magazine>(editions[i], ref flag));
                else
                    myLibrary.Add(ReadEdition<Book>(editions[i], ref flag));

                // Проверка на наличие ошибок при десериализации файла.
                if (flag)
                    return true;

                myLibrary.library[^1].onPrint += PrintHandler;
            }
            return false;
        }
    }
}
