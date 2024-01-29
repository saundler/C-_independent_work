/*
   Студент:     Жалилов Актан
   Группа:      БПИ 223-1
   Вариант:     10
   Дата:        24.11.2022
*/

/*   
    Структура файла:
    <Name> <Increase> <TaxRate> <Tenure> <Price>
    .
    . 
    .
    <Name> <Increase> <TaxRate> <Tenure> <Price>
    -----
    N = <Вещественное число>
    M = <Вещественное число>
*/

//   Входной файл должен подаваться строго в кодировке <UTF8> другие кодировки программа не обрабатывает. 

using System;
using System.IO;
using System.Text;
using System.Collections;

namespace SR2_Zhalilov_Aktan_223_1_10var
{
    internal class Program
    {
        /// <summary>
        /// Метод выводящий на экран сообщение об ошибке.
        /// </summary>
        /// <param name="error_Message">Сообщение об ошибке.</param>
        static void PrintErrorMessage(string error_Message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(error_Message);
            Console.ForegroundColor = ConsoleColor.White;
        }

        /// <summary>
        /// Метод отвечающий за корректный ввод имени файла.
        /// </summary>
        /// <returns>Имя файла.</returns>
        static string NameInput()
        {
            string file_Name;             // Имя исходного файла.
            bool wrong_Name = false,      // Есть ли в имени файла некорректные символы.
                 not_Exist = false,       // Существует ли файл.
                 wrong_Type = false;      // Правильно ли указан тип файла.

            // Повтор ввод при некорректном вводе.
            do
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Enter filename:");
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.CursorVisible = true;

                // Ввод имени файла.
                file_Name = Console.ReadLine();

                Console.CursorVisible = false;

                // Проверка на корректность символов.
                wrong_Name = file_Name.IndexOfAny(Path.GetInvalidPathChars()) != -1;
                if (wrong_Name)
                {
                    PrintErrorMessage("The name of the specified file contains invalid characters, please try again.");
                    continue;
                }

                // Проверка на существование.
                not_Exist = !File.Exists(file_Name);
                if (not_Exist)
                {
                    PrintErrorMessage("The specified file name does not exist, please try again.");
                    continue;
                }

                // Проверка на корректность типа.
                wrong_Type = file_Name.Length < 5 || file_Name.Substring(file_Name.Length - 4, 4) != ".txt";
                if (wrong_Type)
                {
                    PrintErrorMessage("The file type does not match the <txt> type, please try again.");
                }

            } while (wrong_Name || not_Exist || wrong_Type);
            return file_Name;
        }

        /// <summary>
        /// Метод проверяющий кодировку файла на корректность.
        /// </summary>
        /// <param name="file_Name">Имя файла.</param>
        /// <returns>Корректна ли кодировка.</returns>
        static bool EncodingСheck(string file_Name)
        {
            StreamReader streamReader = new StreamReader(file_Name);
            if (streamReader.CurrentEncoding is UTF8Encoding)
            {
                streamReader.Close();
                return true;
            }
            streamReader.Close();
            PrintErrorMessage("Incorrect file encoding.");
            return false;
        }

        /// <summary>
        /// Метод заменяющий разделитель десятичных чисел в соответсвии с региональными настройками пользователя.
        /// </summary>
        /// <param name="num">Десятичное число с исходным разделителем.</param>
        /// <returns>Десятичное число с соответствующим разделителем.</returns>
        static string ChangeSeparator(string num)
        {
            Char separator = System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencyDecimalSeparator[0];
            num = num.Contains('.') ? num.Replace('.', separator) : num.Replace(',', separator);
            return num;
        }

        /// <summary>
        /// Метод для считывания и проверки структуры файла.
        /// </summary>
        /// <param name="file_Lines">Массив строк прочитанного файла.</param>
        /// <param name="properties">Массив д</param>
        /// <param name="n">Первое значение налога.</param>
        /// <param name="m">Второе значение налога.</param>
        /// <returns>Корректна ли структура файла.</returns>
        static bool StructureCheck(string[] file_Lines, List<Property> properties, out double n, out double m)
        {
            string[] elements_Line;     // Массив элементов строки разделенной через пробел.
            n = 0;
            m = 0;

            // Считывание файла и проверка его структуры.
            try
            {
                // Инициализация первого значения налога при наличии его в файле.
                if (file_Lines[^2].Contains("N = "))
                {
                    n = double.Parse(ChangeSeparator(file_Lines[^2].Split(" = ")[1]));
                }
                else
                {
                    throw new ArgumentException("The file does not contain the first tax value (N).");
                }
                // Инициализация второго значения налога при наличии его в файле.
                if (file_Lines[^1].Contains("M = "))
                {
                    m = double.Parse(ChangeSeparator(file_Lines[^1].Split(" = ")[1]));
                }
                else
                {
                    throw new ArgumentException("The file does not contain the second tax value (M).");
                }
                // Инициализация массива объектов.
                foreach (string line in file_Lines)
                {
                    // Завершение работы цикла в случае встречи разделителя.
                    if (line == "-----")
                    {
                        break;
                    }

                    // Элементы строки разделенные пробелом.
                    elements_Line = line.Split(' ');

                    // Создание экземпляра класса Apartment.
                    if (elements_Line[0] == "Apartment")
                    {
                        properties.Add(new Apartment(elements_Line[1],
                                                     double.Parse(ChangeSeparator(elements_Line[2])),
                                                     double.Parse(ChangeSeparator(elements_Line[3])),
                                                     int.Parse(elements_Line[4]), int.Parse(elements_Line[5])));
                    }
                    // Создание экземпляра класса CountryHouse.
                    else if (elements_Line[0] == "CountryHouse")
                    {
                        properties.Add(new CountryHouse(elements_Line[1],
                                                        double.Parse(ChangeSeparator(elements_Line[2])),
                                                        double.Parse(ChangeSeparator(elements_Line[3])),
                                                        int.Parse(elements_Line[4]), int.Parse(elements_Line[5])));
                    }
                    // Вывод ошибки в случае несоотвествия данных.
                    else
                    {
                        throw new ArgumentException("Incorrect data entry in the file.");
                    }
                }
            }
            catch (IndexOutOfRangeException)
            {
                PrintErrorMessage("Lack of required information in the file.");
                properties = new List<Property>();
                return false;
            }
            catch (ArgumentException e)
            {
                PrintErrorMessage(e.Message);
                properties = new List<Property>();
                return false;
            }
            catch (FormatException)
            {
                PrintErrorMessage("Incorrect data entry in the file.");
                properties = new List<Property>();
                return false;
            }
            catch
            {
                PrintErrorMessage("Incorrect file structure.");
                properties = new List<Property>();
                return false;
            }
            return true;
        }

        static void Main()
        {                                                              
            double n,                       // Первое значение налога.
                   m;                       // Второе значение налога.
            string file_Name;               // Имя исходного файла.
            string[] file_Lines;            // Все строки исходного файла.
            List<string> apartments,        // Строки содержащие данные об апартаментах чьи налоги больше N. 
                         houses;            // Строки содержащие данные о загородных домах чьи налоги больше M.
            List<Property> properties;      // Массив всех имуществ содержащихся в файле.
            ConsoleKey command;             // Клавиша нажатая пользователем.

            // Регистрирация поставщика кодировки.
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);

            do
            {
                // Вывод приветствующего сообщения с информацие о программе.
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Hello, this program filters the correct properties,\n" +
                                  "located in text files.\n");
                Console.ForegroundColor = ConsoleColor.Gray;

                // Отчистка и инициализация массивов для работы с новым файлом.
                apartments = new List<string>();
                houses = new List<string>();
                properties = new List<Property>();

                // Ввод имени файла.
                file_Name = NameInput();

                // Запись всех строк файла в массив строк.
                file_Lines = File.ReadAllLines(file_Name);

                // Условие работы программы при корректной структуре файла.
                if (EncodingСheck(file_Name) && StructureCheck(file_Lines, properties, out n, out m))
                {
                    // Цикл отбирающий необходимые имущества в соотвествии с условием задачи. 
                    for (int i = 0; i < properties.Count; i++)
                    {
                        if (properties[i] is Apartment && properties[i][properties[i].Price] > n)
                        {
                            apartments.Add(properties[i].ToString());
                        }
                        else if (properties[i] is CountryHouse && properties[i][properties[i].Price] > m)
                        {
                            houses.Add(properties[i].ToString());
                        }
                    }

                    // Запись отобранных данных в новые файлы.
                    File.WriteAllLines(@"apartments.txt", apartments, Encoding.GetEncoding(1251));
                    File.WriteAllLines(@"houses.txt", houses, Encoding.GetEncoding(1251));

                    // Вывод сообщения об успешном выполнении операции.
                    Console.WriteLine("The data was successfully processed and saved to files:\n" +
                                      "apartemnts.txt and houses.txt");
                }

                // Вывод условия необходимого для повторной работы программы. 
                Console.WriteLine("To repeat the program, press the space bar, otherwise the program will exit.");

                command = Console.ReadKey().Key;
                Console.Clear();
            } while (command == ConsoleKey.Spacebar);

            // Завершение работы.
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(Console.WindowWidth / 2 - 9, Console.WindowHeight / 2 - 3);
            Console.WriteLine("Goodbye!");
            Console.ForegroundColor = ConsoleColor.Blue;
        }
    }
}