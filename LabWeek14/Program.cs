using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabWeek14
{
    class Program
    {
        public delegate double TestFunctions(double a, int b);

        static void Main(string[] args)
        {
            Console.WriteLine("Enter a number:");
            double num1 = double.Parse(Console.ReadLine());
            Console.WriteLine("Enter anotehr number:");
            int num2 = int.Parse(Console.ReadLine());

            TestFunctions test_roots = new TestFunctions(FindSquareRoot);

            Console.WriteLine("The square root of " + num1 + " with " + num2 + " points of accuracy is " + test_roots(num1, num2));

            test_roots = new TestFunctions(MoveDecimal);
            Console.WriteLine(num1 + " with its decimal moved " + num2 + " numbers over is " + test_roots(num1, num2));

            Console.Read();
        }

        public static double MoveDecimal(double num_to_move, int num_moves)
        {
            return num_to_move * Math.Pow(10, num_moves);
        }

        public static double FindSquareRoot(double target, int decimals)
        {
            if (decimals > 15)
                Console.WriteLine("ERROR: Accuracy too great. Cannot exceed 15 points of accuracy. Adjusting decimals to 15.");

            int upper = 1;
            int lower = 0;

            while (upper * upper < target)
            {
                upper ++;
            }
            lower = upper - 1;

            double test = lower;
            double adder = 0.1;
            int i = 0;
            while (i < decimals || test * test == target)
            {
                test += adder;
                if ((adder > 0 && test * test > target) || (adder < 0 && test * test < target))
                {
                    adder /= -10;
                    i++;
                }
            }

            return test;
        }
    }
}
