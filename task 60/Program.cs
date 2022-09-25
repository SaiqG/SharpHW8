using System.Globalization;
Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");

//Сформируйте трёхмерный массив из неповторяющихся двузначных чисел. Напишите программу, которая будет построчно выводить массив, добавляя индексы каждого элемента.

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

int[] RandomFillNoRep(int[,,] array) //собираем массив неповторяющихся двухзначных числе чтоб заполнить нашу матрицу.
{
    int[] randNums = new int[array.GetLength(0) * array.GetLength(1) * array.GetLength(2)];

    for (int i = 0; i < randNums.GetLength(0); i++)
    {
        Random r = new Random();
        int y = 0;
        randNums[i] = r.Next(10, 100);
        y = randNums[i];
        if (i >= 1)
        {
            for (int j = 0; j < i; j++)
            {
                while (randNums[i] == randNums[j])
                {
                    randNums[i] = r.Next(10, 100);
                    j = 0;
                    y = randNums[i];
                }
                y = randNums[i];
            }
        }

    }
    return randNums;
}

void Fill3dArray(int[,,] array, int[] fill)
{
    int l = 0;
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            for (int k = 0; k < array.GetLength(2); k++)
            {
                array[i, j, k] = fill[l++];
            }
        }
    }
}

void Print3dArray(int[,,] array)
{
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            for (int k = 0; k < array.GetLength(2); k++)
            {
                Console.Write($"{array[i, j, k],3} ({i}, {j}, {k}) ");
            }
            Console.WriteLine();
        }
        Console.WriteLine();
    }

}

int[] size3d = ParseInput(EnterAndSplitString());

int[,,] matrix = new int[size3d[0], size3d[1], size3d[2]];

int[] fill = RandomFillNoRep(matrix);

Fill3dArray(matrix, fill);
Print3dArray(matrix);
