using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_2._2
{
    class Program
    {
        public static void Solution(int[] nums,out int max,out int min, out float average,out int sum)
        {
            sum = 0;
            foreach (int num in nums)
                sum += num;
            average = (float)sum / nums.Length;

            max = nums[0];
            min = nums[0];
            foreach(int num in nums)
            {
                if (num > max)
                    max = num;
                if (num < min)
                    min = num;
            }
        }
        static void Main(string[] args)
        {
            int max, min, sum;
            float average;
            int[] nums = { 1, 2, 100, 4, 99, 6, 9, -10, -1 , 9};
            Solution(nums,out max,out min,out average,out sum);
            Console.WriteLine($"max:{max} min:{min} average:{average} sum:{sum}");
            Console.ReadKey();
        }
    }
}
