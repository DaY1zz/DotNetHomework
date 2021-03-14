using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace HomeWork3
{
    abstract class Shape
    {
        abstract public double CalArea();

        abstract public bool IsLegal();
    }

    class Rectangle:Shape
    {
        public double Width { get; set; }
        public double Height { get; set; }

        public Rectangle(double width,double height)
        {
            Width = width;
            Height = height;

        }
        public override bool IsLegal()
        {
            if (Width <= 0 || Height <= 0)
                return false;
            return true;
            
        }
        public override double CalArea()
        {
            if (!IsLegal())
                throw new ArgumentException("The rectangle is illegal");
            return Width * Height;
        }
    }

    class Square : Shape
    {
        public double Side { get; set; }

        public Square(double side)
        {
            Side = side;
        }

        public override bool IsLegal()
        {
            if (Side <= 0)
                return false;
            return true;
        }
        public override double CalArea()
        {
            if (!IsLegal())
                throw new ArgumentException("The square is illegal");
            return Side * Side;
        }
        
    }
    class Circle : Shape
    {
        public double Radius { get; set; }
        public Circle(double radius)
        {
            Radius = radius;
        }
        public override bool IsLegal()
        {
            if (Radius <= 0)
                return false;
            return true;
        }
        public override double CalArea()
        {
            if (!IsLegal())
                throw new ArgumentException("The circle is illegal");
            return Math.PI * Radius * Radius;
        }

    }

    class Triangle : Shape
    {
        public double SideA { get; set; }
        public double SideB { get; set; }
        public double SideC { get; set; }

        public Triangle(double a,double b,double c)
        {
            SideA = a;
            SideB = b;
            SideC = c;
        }
        public override bool IsLegal()
        {
            double longerSide = SideA > SideB ? SideA : SideB;
            double longestSide = longerSide > SideC ? longerSide : SideC;
            if (SideA + SideB + SideC - longestSide < longestSide || SideA < 0 || SideB < 0 || SideC < 0) 
                return false;
            return true;
        }

        public override double CalArea()
        {
            if (!IsLegal())
                throw new ArgumentException("The triangle is illegal");
            double p = SideA + SideB + SideC;
            return Math.Sqrt(p * (p - SideA) * (p - SideB) * (p - SideC));
        }
    }



    class ShapeFactory
    {
        public Shape RandomCreateShape(String command)
        {
            Shape createdShape;
            Random rand = new Random();
            switch (command)
            {
                case "rectangle":
                    {
                        double width = rand.Next(-10,11);
                        double height = rand.Next(-10, 11);
                        createdShape = new Rectangle(width, height);
                        break;
                    }
                case "square":
                    {
                        double side = rand.Next(-10, 11);
                        createdShape = new Square(side);
                        break;
                    }
                case "circle":
                    {
                        double radius = rand.Next(-10, 11);
                        createdShape = new Circle(radius);
                        break;
                    }
                case "triangle":
                    {
                        double sideA = rand.Next(-10, 11);
                        double sideB = rand.Next(-10, 11);
                        double sideC = rand.Next(-10, 11);
                        createdShape = new Triangle(sideA, sideB, sideC);
                        break;
                    }
                default:throw new ArgumentException("the command is unsatified");
            }
            return createdShape;
        }
    }
    class Commander
    {
        public string RandomCommand()
        {
            Random rand = new Random();
            int command = rand.Next(0, 4);
            switch (command)
            {
                case 0: return "rectangle";
                case 1: return "square";
                case 2: return "circle";
                case 3: return "triangle";
            }
            return null;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            ShapeFactory factory = new ShapeFactory();
            Commander commander = new Commander();
            Shape shape;
            double sum = 0;
            for(int i = 0; i < 10; i++)
            {
                try
                {
                    Thread.Sleep(20);
                    shape = factory.RandomCreateShape(commander.RandomCommand());
                    Console.WriteLine($"the area of thes shape is {shape.CalArea()}");
                    sum += shape.CalArea();
                    Console.WriteLine();
                }catch(Exception e)
                {
                    Console.WriteLine(e.Message+"\n");
                    i--;  //生成的图形不合法，重新生成一次
                }
            }
            Console.WriteLine($"总面积为：{sum}");
            Console.ReadKey();
        }
    }


}
