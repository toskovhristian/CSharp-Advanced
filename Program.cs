using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace Miner
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int minedCoal = 0;
            int coalCounter = 0;
            string[,] matrix = new string[n, n];
            int[] miner = new int[2] { 0, 0 };
            string[] directions = Console.ReadLine().Split(' ').ToArray();
            FillMatrix(n , coalCounter , miner , matrix);

            foreach (var item in matrix)
            {
                if (item == "c")
                {
                    coalCounter++;
                }
            }

            for (int i = 0; i < directions.Length + 1; i++)
            {
                if (i == directions.Length)
                {
                    Console.WriteLine($"{coalCounter} coals left. ({miner[0]}, {miner[1]})");
                    return;
                }
                switch (directions[i])
                {
                    case "up":
                        if (miner[0] - 1 < 0)
                        {
                            break;
                        }
                        else if (matrix[miner[0] - 1, miner[1]] == "e")
                        {
                            Console.WriteLine("Game over!" + " " + "(" + (miner[0] - 1) + ", " + miner[1] + ")");
                            return;
                        }
                        else
                        {
                            if (matrix[miner[0] - 1, miner[1]] == "c")
                            {
                                minedCoal++;
                                coalCounter--;
                                matrix[miner[0] - 1, miner[1]] = "s";
                                matrix[miner[0], miner[1]] = "*";
                                miner[0] -= 1;
                            }
                            else
                            {
                                matrix[miner[0], miner[1]] = "*";
                                matrix[miner[0] - 1, miner[1]] = "s";
                                miner[0] -= 1;
                            }
                            if (coalCounter == 0)
                            {
                                Console.WriteLine($"You collected all coals! ({miner[0]}, {miner[1]})");
                                return;
                            }

                        }
                        break;
                    case "down":
                        if (miner[0] + 1 >= matrix.GetLength(0))
                        {
                            break;
                        }
                        else if (matrix[miner[0] + 1, miner[1]] == "e")
                        {
                            Console.WriteLine("Game over!" + " " + "(" + (miner[0] + 1) + ", " + miner[1] + ")");
                            return;
                        }
                        else
                        {
                            if (matrix[miner[0] + 1, miner[1]] == "c")
                            {
                                minedCoal++;
                                coalCounter--;
                                matrix[miner[0] + 1, miner[1]] = "s";
                                matrix[miner[0], miner[1]] = "*";
                                miner[0] += 1;
                            }
                            else
                            {
                                matrix[miner[0], miner[1]] = "*";
                                matrix[miner[0] + 1, miner[1]] = "s";
                                miner[0] += 1;
                            }
                            if (coalCounter == 0)
                            {
                                Console.WriteLine($"You collected all coals! ({miner[0]}, {miner[1]})");
                                return;
                            }
                        }
                        break;
                    case "left":
                        if (miner[1] - 1 < 0)
                        {
                            break;
                        }
                        else if (matrix[miner[0], miner[1] - 1] == "e")
                        {
                            Console.WriteLine("Game over!" + " " + "(" + miner[0] + ", " + (miner[1] - 1) + ")");
                            return;
                        }
                        else
                        {
                            if (matrix[miner[0], miner[1] - 1] == "c")
                            {
                                minedCoal++;
                                coalCounter--;
                                matrix[miner[0], miner[1] - 1] = "s";
                                matrix[miner[0], miner[1]] = "*";
                                miner[1] -= 1;
                            }
                            else
                            {
                                matrix[miner[0], miner[1]] = "*";
                                matrix[miner[0], miner[1] - 1] = "s";
                                miner[1] -= 1;
                            }
                            if (coalCounter == 0)
                            {
                                Console.WriteLine($"You collected all coals! ({miner[0]}, {miner[1]})");
                                return;
                            }
                        }
                        break;
                    case "right":
                        if (miner[1] + 1 >= matrix.GetLength(1))
                        {
                            break;
                        }
                        else if (matrix[miner[0], miner[1] + 1] == "e")
                        {
                            Console.WriteLine("Game over!" + " " + "(" + miner[0] + ", " + (miner[1] + 1) + ")");
                            return;
                        }
                        else
                        {
                            if (matrix[miner[0], miner[1] + 1] == "c")
                            {
                                minedCoal++;
                                coalCounter--;
                                matrix[miner[0], miner[1] + 1] = "s";
                                matrix[miner[0], miner[1]] = "*";
                                miner[1] += 1;
                            }
                            else
                            {
                                matrix[miner[0], miner[1]] = "*";
                                matrix[miner[0], miner[1] + 1] = "s";
                                miner[1] += 1;
                            }
                            if (coalCounter == 0)
                            {
                                Console.WriteLine($"You collected all coals! ({miner[0]}, {miner[1]})");
                                return;
                            }
                        }
                        break;

                    default:
                        break;
                }
            }


        }

        public static void FillMatrix(int n,int coalCounter, int[] miner, string[,] matrix)
        {
            for (int i = 0; i < n; i++)
            {
                string[] matrixFill = Console.ReadLine().Split(' ').ToArray();

                for (int j = 0; j < n; j++)
                {
                    matrix[i, j] = matrixFill[j];

                    if (matrix[i, j] == "s")
                    {
                        miner[0] = i;
                        miner[1] = j;
                    }
                }
            }
        }

        //public static void CollectedCoals(int coalCounter, int[] miner)
        //{
        //    if (coalCounter == 0)
        //    {
        //        Console.WriteLine($"You collected all coals! ({miner[0]}, {miner[1]})");
        //        return;
        //    }
        //}

    }
}
