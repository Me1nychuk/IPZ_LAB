using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace лаб_1_б
{
    internal class Program
    {
        static void Main(string[] args)
        {

            double x = double.Parse(Console.ReadLine());
            double a = double.Parse(Console.ReadLine());
            double y = 0;

            if (Math.Abs(x * a) < 1 && x < 0) { y = (x + a) / Math.Pow(Math.E, x * a); }
            else if (2 < x && a <= 0) { y =  - Math.Pow(Math.Log(x), 2); }
            else if (0 < a && 0 <= x && x <= 2) { Math.Log10(Math.Sqrt(a)); }

            Console.WriteLine(y);
        }
    }
}
