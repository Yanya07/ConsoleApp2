using System;
using System.Collections.Generic;

class StringArray
{
    private string[] array;
    private int currentIndex;

    public StringArray(int length)
    {
        array = new string[length];
        currentIndex = 0;
    }

    // Метод для добавления строки в массив
    public void Add(string value)
    {
        if (currentIndex < array.Length)
        {
            array[currentIndex++] = value;
        }
        else
        {
            Console.WriteLine("Массив заполнен.");
        }
    }

    // Метод для получения строки по индексу
    public string Get(int index)
    {
        if (index >= 0 && index < currentIndex)
        {
            return array[index];
        }
        else
        {
            throw new IndexOutOfRangeException("Индекс выходит за пределы массива.");
        }
    }

    // Метод для вывода всего массива
    public void DisplayAll()
    {
        Console.WriteLine("Элементы массива:");
        for (int i = 0; i < currentIndex; i++)
        {
            Console.WriteLine(array[i]);
        }
    }

    // Метод для сцепления двух массивов
    public StringArray Concatenate(StringArray other)
    {
        StringArray newArray = new StringArray(this.currentIndex + other.currentIndex);
        for (int i = 0; i < this.currentIndex; i++)
        {
            newArray.Add(this.array[i]);
        }
        for (int i = 0; i < other.currentIndex; i++)
        {
            newArray.Add(other.array[i]);
        }
        return newArray;
    }

    // Метод для слияния двух массивов с исключением повторяющихся элементов
    public StringArray MergeWithoutDuplicates(StringArray other)
    {
        HashSet<string> uniqueValues = new HashSet<string>(array, StringComparer.OrdinalIgnoreCase);
        for (int i = 0; i < other.currentIndex; i++)
        {
            uniqueValues.Add(other.array[i]);
        }

        StringArray resultArray = new StringArray(uniqueValues.Count);
        foreach (var value in uniqueValues)
        {
            resultArray.Add(value);
        }
        return resultArray;
    }
}

class Program
{
    static void Main()
    {
        // Создаем массив строк
        StringArray array1 = new StringArray(5);
        array1.Add("Hello");
        array1.Add("World");
        array1.Add("!");

        // Выводим массив
        array1.DisplayAll();

        // Создаем второй массив строк
        StringArray array2 = new StringArray(5);
        array2.Add("Goodbye");
        array2.Add("World");

        // Сцепляем два массива
        StringArray concatenated = array1.Concatenate(array2);
        Console.WriteLine("Результат сцепления:");
        concatenated.DisplayAll();

        // Сливаем два массива с исключением повторяющихся элементов
        StringArray merged = array1.MergeWithoutDuplicates(array2);
        Console.WriteLine("Результат слияния без дубликатов:");
        merged.DisplayAll();
        Console.ReadLine();
    }
}
