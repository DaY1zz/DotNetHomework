using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_2._1
{
    class Program
    {
        public static bool IsPrime(int Pnum)
        {
            if (Pnum <= 1)
                return false;
            for(int i = 2; i*i <= Pnum;i++)
            {
                if (Pnum % i == 0)
                    return false;
            }
            return true;
        }

        public static String Solution(int num)
        {
            StringBuilder factor = new StringBuilder();
            int result = num;
            if (IsPrime(num))
                return num.ToString();
            for(int i = 2; i < num;)
            {
                if (!(IsPrime(i) && result % i == 0))
                { 
                    i++;
                    continue;
                }
                 result = result / i;
                 factor.Append(i);
                 factor.Append(" ");
                if (IsPrime(result))
                {
                    factor.Append(result);
                    break;
                }
            }
            return factor.ToString();
        }

        static void Main(string[] args)
        {

            try
            {
                int num = Int32.Parse(Console.ReadLine());
                Console.WriteLine(Solution(num));
                Console.ReadKey();
            }
            catch (InvalidCastException e)
            {
                Console.WriteLine(e.Message);
            }


        }
    }
}
