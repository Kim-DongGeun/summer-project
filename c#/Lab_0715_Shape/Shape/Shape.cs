using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shape
{
    abstract class Shape
    {
        public int len;
        public abstract void Calarea();
        public double Area;
    }
   abstract class TwoDim : Shape
    {
       public string name;
        public abstract void Calperimeter();
        public double perimeter;
        public void print(double area, double perimeter)
        {
            Console.WriteLine("Area : " + area + "\nPerimeter : " + perimeter);
        }
    }
    abstract class ThreeDim : Shape
    {
        public string name;
        public abstract void Calvolume();
        public double volume;
        public void print(double area, double volume)
        {
            Console.WriteLine("Area : " + area + "\nVolume : " + volume);
        }
    }
    class square : TwoDim
    {

        public override void Calarea()
        {
            Area = len * len;
        }
        public override void Calperimeter()
        {
            perimeter = 4 * len;
        }
    }
    class triangle : TwoDim
    {
        public override void Calarea()
        {
            Area = Math.Sqrt(3) / 4 * len * len;
        }
        public override void Calperimeter()
        {
            perimeter = 3 * len;
        }
    }
    class circle : TwoDim
    {
        public override void Calarea()
        {
            Area = 3.14 * len * len;
        }
        public override void Calperimeter()
        {
            perimeter = 2 * 3.14 * len;
        }
    }
    class cube : ThreeDim
    {
        public override void Calarea()
        {
            Area = 6 * len * len;
        }
        public override void Calvolume()
        {
            volume = len * len * len;
        }
    }
    class sphere : ThreeDim
    {
        public override void Calarea()
        {
            Area = 4 * 3.14 * len * len;
        }
        public override void Calvolume()
        {
            volume = 3.0 / 4 * 3.14 * len * len * len;
        }
    }
}
