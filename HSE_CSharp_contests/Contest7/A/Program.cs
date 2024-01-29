using System;

// Задача А. Второй в массиве

partial class Program
{
    // Объявление делегата-типа
    delegate int SecondMaxDelegate(int[] arr);

    //Создание и инициализация экземпляра делегата
    static SecondMaxDelegate secondMax = SecondInArray;

    static void Main(string[] args)
    {
        string[] stringArr = Console.ReadLine().Split();
        int[] arr = new int[stringArr.Length];
        for (int i = 0; i < stringArr.Length; i++)
        {
            arr[i] = int.Parse(stringArr[i]);
        }

        try
        {
            Console.WriteLine(secondMax(arr));
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}