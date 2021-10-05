using System;
using System.Collections.Generic;
using System.Linq;

namespace ImageKernelCalculator
{
    public class KernelCalculator
    {
        public KernelCalculator()
        {

        }

        public int[][] Calculate(int[][] bitmapImage, int[][] kernel)
        {
            //.Clone() makes it do weird shit idk
            int[][] output = new int[bitmapImage.Length][];
            int kernelSize = kernel.GetLength(0);
            int kernelSizeHalved = (int) Math.Floor((float) kernelSize / 2);

            for (int i = 0; i < bitmapImage.Length; i++)
            {
                output[i] = new int[bitmapImage.GetLength(0)];
            }

            for (int i = 0; i < bitmapImage.Length; i++)
            {
                for (int j = 0; j < bitmapImage[i].Length; j++)
                {
                    //Console.Write($"i: {i}, j: {j}");
                    int anchor = bitmapImage[i][j];
                    // Console.WriteLine($"anchor: {anchor}");
                    List<int> sums = new List<int>();
                    List<string> debugSums = new List<string>();
                    int kernelX = 0;
                    int kernelY = 0;

                    for (int i2 = i - kernelSizeHalved; i2 <= i + kernelSizeHalved; i2++ )
                    {
                        for (int j2 = j - kernelSizeHalved; j2 <= j + kernelSizeHalved; j2++)
                        {
                            int bitmapY = i2;
                            int bitmapX = j2;

                            if (bitmapY < 0)
                            {
                                //if = -1 then should become 3
                                //+ because bitmapY is by definition negative and pos + negative = negative
                                bitmapY = bitmapImage.Length + bitmapY;
                            }
                            else if (bitmapY > (bitmapImage.Length - 1))
                            {
                                //if = 4 thens hould become 0
                                bitmapY -= bitmapImage.Length;
                            }

                            if (bitmapX < 0)
                            {
                                bitmapX = bitmapImage[i].Length + bitmapX;
                            }
                            else if (bitmapX > (bitmapImage[i].Length - 1))
                            {
                                bitmapX -= bitmapImage[i].Length;
                            }

                            int result = bitmapImage[bitmapY][bitmapX] * kernel[kernelY][kernelX];
                            // debugSums.Add($"{bitmapImage[bitmapY][bitmapX]} * {kernel[kernelY][kernelX]} = {result}");

                            sums.Add(result);

                            kernelX++;
                        }

                        kernelY++;
                        kernelX = 0;
                    }

                    // sums.ForEach((x) => Console.Write(x + ","));
                    // debugSums.ForEach((x) => Console.Write(x + "\n"));
                    // Console.Write(" = ");
                    output[i][j] = sums.Sum();
                    // Console.WriteLine(output[i][j]);
                }
            }


            return output;
        }
    }
}