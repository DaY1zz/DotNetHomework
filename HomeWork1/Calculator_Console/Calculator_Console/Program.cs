using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator_Console
{
    class Program
    {
        public static void Calculate()
        {
            Console.WriteLine("Please input calculate expression, such as a+b, a-b");
            String ExpStr = Console.ReadLine();

            String[] numsOfAdd = ExpStr.Split('+');
            String[] numsOfSub = ExpStr.Split('-');
            String[] numsOfMul = ExpStr.Split('*');
            String[] numsOfDiv = ExpStr.Split('/');

            if (numsOfAdd.Length == 2)
            {
                int a = Int32.Parse(numsOfAdd[0]);
                int b = Int32.Parse(numsOfAdd[1]);
                Console.WriteLine($"{a + b}");
                return;
            }
            if (numsOfSub.Length == 2)
            {
                int a = Int32.Parse(numsOfSub[0]);
                int b = Int32.Parse(numsOfSub[1]);
                Console.WriteLine($"{a - b}");
                return;
            }
            if (numsOfMul.Length == 2)
            {
                int a = Int32.Parse(numsOfMul[0]);
                int b = Int32.Parse(numsOfMul[1]);
                Console.WriteLine($"{a * b}");
                return;
            }
            if (numsOfDiv.Length == 2)
            {
                int a = Int32.Parse(numsOfDiv[0]);
                int b = Int32.Parse(numsOfDiv[1]);
                if (b == 0)
                    Console.WriteLine("Error: by zero!");

                else
                    Console.WriteLine($"{a / b}");
                return;
            }
            Console.WriteLine("Error: The expression is unqualified !");



        }

        static void Main(string[] args)
        {
            Calculate();
            Console.ReadKey();

        }
    }
}

