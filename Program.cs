using System;

namespace ImageKernelCalculator
{
    class Program
    {
        private static int[][] Bitmap = new int[][]
        {
            new int[] {128, 255, 196, 64},
            new int[] {20, 128, 255, 96},
            new int[] {210, 20, 128, 255},
            new int[] {210, 210, 20, 128},
        };

        private static int[][] Kernel = new int[][]
        {
            new int[] {1, 2, 1},
            new int[] {0, 0, 0},
            new int[] {-1, -2, -1},
        };

        public static KernelCalculator MainKernelCalculator = new KernelCalculator(); 

        static void Main(string[] args)
        {
            Console.WriteLine("Image:");
            PrintMatrix(Bitmap);
            Console.WriteLine("Kernel:");
            PrintMatrix(Kernel);
            Console.WriteLine("Output:");
            PrintMatrix(MainKernelCalculator.Calculate(Bitmap, Kernel));
        }

        private static void PrintMatrix(int[][] matrix)
        {
            //"┌" "┘" "└" "┐" "|"

            for (int i = 0; i < matrix.Length; i++)
            {
                if (i == 0)
                {
                    Console.Write("┌ ");
                }
                else if (i == matrix.Length - 1)
                {
                    Console.Write("└ ");
                }
                else
                {
                    Console.Write("| ");
                }

                int longest = 3;

                for (int j = 0; j < matrix[i].Length; j++)
                {
                    string num = matrix[i][j].ToString();
                    int numLength = Math.Abs(matrix[i][j]).ToString().Length;

                    if (numLength > longest)
                    {
                        longest = numLength;
                    }

                    if (matrix[i][j] >= 0)
                    {
                        Console.Write(" ");
                    }

                    Console.Write(num);
                    //add comma if not at end of the array
                    if (j < matrix[i].Length - 1)
                    {
                        Console.Write("," + new String(' ', ((longest + 1) - numLength)));
                    }
                    else
                    {
                        Console.Write(new String(' ', ((longest + 1) - numLength)));
                    }

                    
                }


                if (i == 0)
                {
                    Console.Write("┐");
                }
                else if (i == matrix.Length - 1)
                {
                    Console.Write("┘");
                }
                else
                {
                    Console.Write("|");
                }

                Console.Write('\n');
            }
        }
    }
}
