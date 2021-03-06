using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_2._3
{
    class Program
    {

        public static int[] Solution()
        {
            bool[] isPrime = new bool[101];
            isPrime[0] = false;
            isPrime[1] = false;
            for (int i = 2; i < isPrime.Length; i++)   //初始认为2-100均为素数
                isPrime[i] = true;

            int[] primes = new int[99];   //存放记录素数
            int index = 0;
            for(int i = 2; i <= 100; i++)
            {
                if(isPrime[i])
                {
                    primes[index++] = i;
                    for(int j = i+i; j <= 100; j += i)
                        isPrime[j] = false;       //素数的倍数不是素数
                }
            }
            return primes;


        }
        static void Main(string[] args)
        {
            int[] primes = Solution();
            foreach(int num in primes)
            {
                if(num!=0)
                    Console.WriteLine(num);
            }
            Console.ReadKey();
        }
    }
}
