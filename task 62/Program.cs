using System.Globalization;
Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");

// Задача 62. Напишите программу, которая заполнит спирально массив 4 на 4.
// Например, на выходе получается вот такой массив:
// 01 02 03 04
// 12 13 14 05
// 11 16 15 06
// 10 09 08 07

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

// Через рекурсию не получилось :(  Точнее получилось, но код выглядил ужасно,с кучей костылей, и работал долго.

// int ind = 1;    
// void FillSpiralArray(int row, int col, int ind)
// {
//     if (array2d[row, col] == 0 && row - 1 >= 0 && col - 1 >= 0)
//     {
//         array2d[row, col] = ind;
//         ind++;
//         if (array2d[row - 1, col] == 0 && array2d[row, col +1 ] == 0)
//         {
//            FillSpiralArray(row - 1, col, ind);
//         }
//         else
//         {
//             FillSpiralArray(row, col + 1, ind);
//             FillSpiralArray(row + 1, col, ind);
//             FillSpiralArray(row, col - 1, ind);
//         }
//     }
// }
// FillSpiralArray(0, 0, ind);

int[,] FillSpiralArray(int[,] array2d) // нууу.. зато работает XD
{
    int row = 1;
    int col = 1;
    int fill = 1;

    while (fill < array2d.GetLength(1) * array2d.GetLength(0) - array2d.GetLength(1) * 4 + 5) // изначально собирается массив где 0 и последняя строчка и столбец - нули
    {
        while (array2d[row, col] == 0 && col + 1 < array2d.GetLength(1))
        {
            array2d[row, col] = fill;
            fill++;
            col++;
        }
        row++;
        col--;
        while (array2d[row, col] == 0 && row + 1 < array2d.GetLength(0))
        {
            array2d[row, col] = fill;
            fill++;
            row++;
        }
        col--;
        row--;
        while (array2d[row, col] == 0 && col - 1 >= 0)
        {
            array2d[row, col] = fill;
            fill++;
            col--;
        }
        col++;
        row--;
        while (array2d[row, col] == 0 && array2d[row - 1, col] >= 0)
        {
            array2d[row, col] = fill;
            fill++;
            row--;
        }
        col++;
        row++;
    }

    int[,] fineArray = new int[array2d.GetLength(0) - 2, array2d.GetLength(1) - 2]; // убираем из массива коробку из нулей.

    for (int i = 1; i < array2d.GetLength(0) - 1; i++)
    {
        for (int j = 1; j < array2d.GetLength(1) - 1; j++)
        {
            fineArray[i - 1, j - 1] = array2d[i, j];
        }
    }

    return fineArray; //получаем нормальный массив, завернутый в спираль

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

Console.WriteLine("Задайте размер матрицы.");
int[] arrayScale = ParseInput(EnterAndSplitString());
Console.WriteLine();
int[,] array2d = new int[arrayScale[0] + 2, arrayScale[1] + 2]; // метод собирает массив с 2 лишними строками и 2 лишними столбцами а потом убирает их, по этому такой костыль.
Print2dArray(FillSpiralArray(array2d));