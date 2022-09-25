using System.Globalization;
Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");

//Задача 54: Задайте двумерный массив. Напишите программу, которая упорядочит по убыванию элементы каждой строки двумерного массива.

string[] EnterAndSplitString()
{
    Console.Write("Введите числа через пробел, запятую или / : ");
    return Console.ReadLine()!.Split(' ', ',', '/');
}

int[] ParseInput(string[] nums)
{
    int[] integerNums = new int[nums.Length];
    for (int i = 0; i < nums.Length; i++)
    {
        integerNums[i] = int.Parse(nums[i])!;
    }
    return integerNums;
}

void Swap(ref int a, ref int b)
{
    int temp = a;
    a = b;
    b = temp;
}

void Fill2dArray(int[,] array)
{
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            array[i, j] = new Random().Next(10);
        }
    }
}

void Print2dArray(int[,] array)
{
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            Console.Write($"{array[i, j],4} ");
        }
        Console.WriteLine();
    }
    Console.WriteLine();
}

void Sort2dArray(int[,] array)
{
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int s = 0; s < array.GetLength(1); s++)
        {
            for (int j = 0; j < array.GetLength(1); j++)
            {
                if (j + 1 < array.GetLength(1))
                {
                    {
                        if (array[i, j] <= array[i, j + 1])
                        {
                            Swap(ref array[i, j], ref array[i, j + 1]);
                        }
                    }
                }
            }
        }
    }
}

//Задайте прямоугольный двумерный массив. Напишите программу, которая будет находить строку с наименьшей суммой элементов.

int[] GetArrayWithRowsSum(int[,] array)
{
    int[] sums = new int[array.GetLength(0)];
    for (int i = 0; i < array.GetLength(0); i++)
        for (int j = 0; j < array.GetLength(0); j++)
            sums[i] += array[i, j];

    return sums;
}

int SortArray(int[] array)
{
    int min = array[0];
    for (int i = 0; i < array.Length; i++)
    {
        if (array[i] <= min)
        {
            min = array[i];
        }
    }
    return min;

}


Console.WriteLine("Задайте размер двумерного массива.");
int[] size = ParseInput(EnterAndSplitString());
int[,] array = new int[size[0], size[1]];
Fill2dArray(array);
Print2dArray(array);
Console.WriteLine("Этот же массив, но каждая строка отсортированна по убыванию: ");
Sort2dArray(array);
Print2dArray(array);

int[] sumInRows = GetArrayWithRowsSum(array);
int min = SortArray(sumInRows);
Console.WriteLine($"Строка с самой маленькой суммой эементов - {Array.IndexOf(sumInRows, min) + 1} сумма элементов в ней - {min}"); //нумерация в выводе с единицы.
