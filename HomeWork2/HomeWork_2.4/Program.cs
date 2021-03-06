using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_2._4
{
    class Program
    {
       public static bool Solution(int[][] matrix,int m,int n)
        {

            for(int row = 1; row < m; row++)
            {
                for(int col = 1; col < n; col++)
                {
                    if (matrix[row][col] != matrix[row - 1][col - 1])
                        return false;
                }
            }
            return true;
        }
        static void Main(string[] args)
        {
            int[][] matrix = new int[3][];
            matrix[0] = new int[4] { 1, 2, 3, 4 };
            matrix[1] = new int[4] { 5, 1, 2, 3 };
            matrix[2] = new int[4] { 9, 5, 1, 2 };
            Console.WriteLine(Solution(matrix, 3, 4));
            Console.ReadKey();
        }
    }
}
