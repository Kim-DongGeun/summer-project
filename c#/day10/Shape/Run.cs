using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shape
{
    class Run
    {
        
        List<TwoDim> twodimlist = new List<TwoDim>();
        List<ThreeDim> threedimlist = new List<ThreeDim>();
        public void run()
        {
            while (true)
            {
                int count1 = twodimlist.Count;
                int count2 = threedimlist.Count;
                
                Console.WriteLine("\n\nTwoDim Shape : " + count1);
                
                Console.WriteLine("ThreeDim Shape : " + count2);

                Console.WriteLine("input len and shape");
                int Len = Int32.Parse(Console.ReadLine());
                
                if (Len == 0)
                {
                    break;
                }
                string shape = Console.ReadLine();
                int num = 0;
                foreach (var i in twodimlist)
                {
                    if (i.name == shape && i.len == Len)
                    {
                        Console.WriteLine("이미 존재함");
                        num = 1;
                        break;
                    }
                } 
                foreach (var i in threedimlist)
                {
                    if (i.name == shape && i.len == Len)
                    {
                        Console.WriteLine("이미 존재함");
                        num = 1;
                        break;
                    }
                }
                if (num == 1)
                {
                    continue;
                }
                if (shape == "정삼각형")
                {
                    TwoDim Triangle = new triangle();
                    Triangle.name = shape;
                    Triangle.len = Len;
                    Triangle.Calarea();
                    Triangle.Calperimeter();
                    Triangle.print(Triangle.Area, Triangle.perimeter);
                    twodimlist.Add(Triangle);
                }
                else if (shape == "정사각형")
                {
                    TwoDim Square = new square();
                    Square.name = shape;
                    Square.len = Len;
                    Square.Calarea();
                    Square.Calperimeter();
                    Square.print(Square.Area, Square.perimeter);
                    twodimlist.Add(Square);
                }
                else if (shape == "원")
                {
                    TwoDim Circle = new circle();
                    Circle.name = shape;
                    Circle.len = Len;
                    Circle.Calarea();
                    Circle.Calperimeter();
                    Circle.print(Circle.Area, Circle.perimeter);
                    twodimlist.Add(Circle);
                }
                else if (shape == "구")
                {
                    ThreeDim Sphere = new sphere();
                    Sphere.name = shape;
                    Sphere.len = Len;
                    Sphere.Calarea();
                    Sphere.Calvolume();
                    Sphere.print(Sphere.Area, Sphere.volume);
                    threedimlist.Add(Sphere);
                }
                else if (shape == "정육면체")
                {
                    ThreeDim Cube = new cube();
                    Cube.name = shape;
                    Cube.len = Len;
                    Cube.Calarea();
                    Cube.Calvolume();
                    Cube.print(Cube.Area, Cube.volume);
                    threedimlist.Add(Cube);
                }
                else
                {
                    Console.WriteLine("Wrong input");
                }
            }
        }
    }
}
