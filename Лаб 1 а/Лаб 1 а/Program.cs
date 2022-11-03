using System;

public class Program
{
    public static void Main()
    {

        double x = double.Parse(Console.ReadLine());
        double k = double.Parse(Console.ReadLine());
        double res;
                
        

            res = (1 / (Math.Pow(Math.E, ((-k) * x + 0.5))))
              * (((Math.Log(Math.Abs(k + x))) - (Math.Sqrt(Math.Pow(Math.Sin(x), 4)))) 
              / Math.Abs(Math.Atan((x + 1) + (x - k)) + (Math.PI / 10) * Math.Log(Math.PI) + 1) + 2);

        
        Console.WriteLine(res);
    }
}