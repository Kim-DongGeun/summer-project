using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4
{
    class Program
    {
        class gugu
        {
            int[,] arr = new int[9, 9];

            public void data()
            {

                for (int i = 0; i < 9; i++)
                {
                    for (int j = 0; j < 9; j++)
                    {
                        arr[i, j] = (i + 1) * (j + 1);
                    }
                }
            }
            public void print(int A)
            {
                for (int k = 0; k < 9; k++)
                {
                    Console.WriteLine(arr[A-1, k]);
                }
            }
        }
        static void Main(string[] args)
        {
            gugu dan = new gugu();
            string B = Console.ReadLine();
            int A = Convert.ToInt32(B);
            dan.data();
            dan.print(A);
        }
    }
}
