using System;

namespace Library
{
    /// <summary>
    /// Все методы выполняющие простые задачи.
    /// </summary>
    partial class Program
    {
        /// <summary>
        /// Метод выводящий на экран сообщение с определенным цветом.
        /// </summary>
        /// <param name="color">Цвет сообщения.</param>
        /// <param name="message"><Сообщение./param>
        static void PrintOnScreen(ConsoleColor color, string message)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(message);
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        /// <summary>
        /// Метод определяющий действие программы.
        /// </summary>
        /// <returns>Начать работу программы или завершить.</returns>
        public static bool SelectCommand()
        {
            PrintOnScreen(ConsoleColor.Yellow,
                          "Для начала или повтора работы программы нажмите \"Spacebar\", для завершения работы программы нажмите \"Escape\".");

            Console.ForegroundColor = ConsoleColor.Black;
            ConsoleKey key = Console.ReadKey().Key;         // Переменная отображающая клавишу нажатую пользователем.

            // Повтор ввода пока пользователь не нажмет нужную клавишу.
            while (key != ConsoleKey.Escape && key != ConsoleKey.Spacebar)
            {
                key = Console.ReadKey().Key;
            }

            Console.ResetColor();

            // Условие завершения программы.
            if (key == ConsoleKey.Escape)
            {
                Console.BackgroundColor = ConsoleColor.Blue;
                Console.Clear();
                Console.SetCursorPosition(Console.WindowWidth / 2 - 9, Console.WindowHeight / 2 - 3);
                PrintOnScreen(ConsoleColor.White, "lДо свидания!");
                Console.ForegroundColor = ConsoleColor.Blue;
                Environment.Exit(0);
                return false;
            }
            // Условие повтора работы программы.
            else
                return true;
        }
        /// <summary>
        /// Метод генерирующий имена для изданий и авторов.
        /// </summary>
        /// <returns>Имя автора или издания.</returns>
        static string GiveName()
        {
            string str = "";
            Random rnd = new Random();
            int n = rnd.Next(10);
            str += (char)rnd.Next(65, 91);
            for (int i = 1; i < n; i++)
            {
                str += (char)rnd.Next(97, 123);
            }
            return str;
        }
        /// <summary>
        /// Метод ввода желаемого количества изданий в библиотеке.
        /// </summary>
        /// <returns>Количество изданий в библиотеке.</returns>
        static int InputN()
        {
            int n;
            PrintOnScreen(ConsoleColor.Yellow, "Введите количество изданий");

            // Повтор ввода при некорретно введенном значении. 
            while (!int.TryParse(Console.ReadLine(), out n) || n < 0)
            {
                PrintOnScreen(ConsoleColor.Red, "Недопустимое значение количесва изданий, повторите ввод");
            }
            return n;
        }
    }
}
