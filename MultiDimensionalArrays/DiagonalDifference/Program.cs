using System;
using System.Linq;

namespace DiagonalDifference_Matrix_
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[,] matrix = new int[n, n];

            FillMatrix(n, matrix);

            int firstDiagonal = 0;
            int secondDiagonal = 0;

            for (int i = 0; i < n; i++)
            {
                firstDiagonal += matrix[i, i];
                secondDiagonal += matrix[i, (n - 1) - i];
            }

            Console.WriteLine(Math.Abs(firstDiagonal - secondDiagonal));
        }

        private static void FillMatrix(int n, int[,] matrix)
        {
            for (int i = 0; i < n; i++)
            {
                int[] numbers = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();
                for (int j = 0; j < n; j++)
                {
                    matrix[i, j] = numbers[j];
                }
            }
        }
    }
}
