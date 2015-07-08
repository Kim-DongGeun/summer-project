using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5
{
    static class constant
    {
        public const double pi = 3.14;
    }
    class Program
    {
        
        class cal
        {
            double len;
            double area;

            public void Length(int r)
            {
                len = 2 * constant.pi * r;
                Console.WriteLine("원둘레 = " + len);
            }
            public void Area(int r)
            {
                area = constant.pi * r * r;
                Console.WriteLine("원넓이 = " + area);
            }
        }
        static void Main(string[] args)
        {
            cal Cal = new cal();
            string rad = Console.ReadLine();
            int r = Convert.ToInt32(rad);
            Cal.Length(r);
            Cal.Area(r);
        }
    }
}
