using System;
using System.IO;
using System.Text;
using System.Data.Common;
using System.Collections.Generic;
using EKRLib;



namespace Transports
{
    public class Program
    {
        /// <summary>
        /// Метод выводящий на экран сообщение с определенным цветом.
        /// </summary>
        /// <param name="color">Цвет сообщения.</param>
        /// <param name="message"><Сообщение./param>
        public static void PrintOnScreen(ConsoleColor color, string message)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(message);
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        /// <summary>
        /// Метод задающий название новой модели.
        /// </summary>
        /// <returns>Название модели.</returns>
        public static string NameModel()
        {
            char[] model = new char[5];         // Название модели в массиве символов.
            Random rnd = new Random();          // Переменная для получения случайных значений.

            // Состваление названия.
            for (int j = 0; j < 5; j++)
            {
                // Условие добавления случайного латинского символа.
                if (rnd.Next(2) == 0)
                {
                    model[j] = (char)rnd.Next(65, 91);
                }
                // Условие добавления случайной цифры.
                else
                {
                    model[j] = (char)rnd.Next(48, 58);
                }
            }

            return String.Join("", model);
        }

        /// <summary>
        /// Метод для заполнения списка транспортных средств.
        /// </summary>
        /// <param name="transports">Список транспортных средств.</param>
        /// <param name="cars_information">Список строк с информацией о машинах.</param>
        /// <param name="motorboats_information">Список строк с информацией о моторных лодках.</param>
        public static void TransportGeneration(List<Transport> transports, List<string> cars_information, List<string> motorboats_information)
        {
            Random rnd = new Random();                    // Переменная для получения случайных значений.
            int number = rnd.Next(6, 10);                 // Количество транспортных средств.

            // Заполнение списка транспортных средств.
            for (int i = 0; i < number; i++)
            {
                try
                {
                    // Условие создания объекта класса Car.
                    if (rnd.Next(2) == 0)
                    {
                        transports.Add(new Car(NameModel(), (uint)rnd.Next(10, 100)));
                        cars_information.Add(transports[^1].ToString());
                    }
                    // Условие создания объекта класса MotorBoat.
                    else
                    {
                        transports.Add(new MotorBoat(NameModel(), (uint)rnd.Next(10, 100)));
                        motorboats_information.Add(transports[^1].ToString());
                    }
                    Console.WriteLine(transports[^1].StartEngine());
                }
                catch (TransportException exception)
                {
                    // Вывод ошибки на экран.
                    PrintOnScreen(ConsoleColor.Red, exception.Message);
                    i--;
                }
            }
        }

        /// <summary>
        /// Метод определяющий действие программы после завершения цикла.
        /// </summary>
        /// <returns>Повторять работу программы или завершить.</returns>
        public static bool SelectCommand()
        {
            PrintOnScreen(ConsoleColor.White, 
                          "Для повтора работы программы нажмите \"Spacebar\", для завершения работы программы нажмите \"Escape\".");

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
                return false;
            }
            // Условие повтора работы программы.
            else
            {
                return true;
            }
        }

        static void Main()
        {
            Random rnd = new Random();                    // Переменная для получения случайных значений.
            List<string> cars_information,                // Список строк с информацией о машинах.
                         motorboats_information;          // Список строк с информацией о моторных лодках.
            List<Transport> transports;                   // Список транспортных средств.
                
            Console.CursorVisible = false;

            // Повтор работы.
            do
            {
                // Инициализация переменных перед началом работы программы.
                transports = new List<Transport>();
                cars_information = new List<string>();
                motorboats_information = new List<string>();
                
                Console.Clear();

                // Приветсвие пользователя с инструкцией о дальнейших действиях.
                PrintOnScreen(ConsoleColor.White,
                              "   Здравствуйте данная программа генерирует несколько транспортных средсвт\n" +
                              "    в диапазоне от 6 до 9 выводит созданные транспорты на экран \n" +
                              "    и записывает каждую группу типа транспорта в отдельный файл.\n");

                PrintOnScreen(ConsoleColor.Yellow,
                              "Сгенерированные транспортные средства:");

                // Заполнение списка транспортных средств.
                TransportGeneration(transports, cars_information, motorboats_information);

                // Запись данных о транспортных средствах в отдельные файлы.
                File.WriteAllLines(@"..\..\..\..\Cars.txt", cars_information, Encoding.Unicode);
                File.WriteAllLines(@"..\..\..\..\MotorBoats.txt", motorboats_information, Encoding.Unicode);

                // Отчет об успешной работе программы.
                PrintOnScreen(ConsoleColor.Green,
                              "\nДанные о транспортных средствах успешно записанны в файлы Cars.txt и MotorBoats.txt\n");

            } while (SelectCommand());

            // Завершение работы.
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.Clear();
            Console.SetCursorPosition(Console.WindowWidth / 2 - 9, Console.WindowHeight / 2 - 3);
            PrintOnScreen(ConsoleColor.White, " До свидания!");
            Console.ForegroundColor = ConsoleColor.Blue;
        }
    }
}