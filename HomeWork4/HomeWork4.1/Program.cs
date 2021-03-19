using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork4._1
{
    class Program
    {
        static void Main(string[] args)
        {
            GenericList<int> list = new GenericList<int>();
            for (int i = 1; i < 1024; i += i)
                list.Add(i);

            int max = list.Head.Data, min = list.Head.Data, sum = 0;

            //依次输出
            list.ForEach(x => Console.WriteLine(x));
            //求最大值
            list.ForEach(x => max = max < x ? x : max);
            //求最小值
            list.ForEach(x => min = min > x ? x : min);
            //求和
            list.ForEach(x => sum += x);

            Console.WriteLine($"Max: {max}, Min: {min}, Sum: {sum}");

            Console.ReadKey();


        }
    }
}
