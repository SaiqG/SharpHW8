using System.Globalization;
Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");

// Задача 58: Задайте две матрицы. Напишите программу, которая будет находить произведение двух матриц.

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
            Console.Write($"{array[i, j],3} ");
        }
        Console.WriteLine();
    }
    Console.WriteLine();
}

int[,] Multiplication(int[,] matrixA, int[,] matrixB)
{
    if (matrixA.GetLength(1) != matrixB.GetLength(0))
    {
        Console.WriteLine("Матрицы нельзя перемножить");
    }

    int[,] matrixResult = new int[matrixA.GetLength(0), matrixB.GetLength(1)];

    for (int i = 0; i < matrixA.GetLength(0); i++)
    {
        for (int j = 0; j < matrixB.GetLength(1); j++)
        {
            for (int k = 0; k < matrixB.GetLength(0); k++)
            {
                matrixResult[i, j] += matrixA[i, k] * matrixB[k, j];
            }
        }
    }
    return matrixResult;
}


Console.WriteLine("Введите размерность первой матрицы.");
int[] sizeA = ParseInput(EnterAndSplitString());

Console.WriteLine("Введите размерность второй матрицы.");
int[] sizeB = ParseInput(EnterAndSplitString());

Console.WriteLine("Матрица A:");
int[,] matrixA = new int[sizeA[0], sizeA[1]];
Fill2dArray(matrixA);
Print2dArray(matrixA);

Console.WriteLine("Матрица B:");
int[,] matrixB = new int[sizeB[0], sizeB[1]];
Fill2dArray(matrixB);
Print2dArray(matrixB);

Console.WriteLine("Матрица C = A * B:");
Print2dArray(Multiplication(matrixA, matrixB));
