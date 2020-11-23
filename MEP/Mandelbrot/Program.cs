using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mandelbrot
{
    static class Program
    {
        static void Main()
        {
            int getal = Mandel(100, 0.5, 0.8, 0, 0);
            Console.WriteLine("De teller is geïndigd op: " + getal);
            Application.Run(new Form1());
        }
        static int Mandel(int herhalingen, double x, double y, double a, double b)
        {
            double pyt = 0;
            double manx = x;
            double many = y;
            double mana = a;
            double manb = b;
            int counter = 0;
            do
            {
                counter += 1;
                //Console.WriteLine("\nDe teller staat op: " + counter);
                (double, double) test1 = Formula(manx, many, mana, manb);
                double newmana = test1.Item1;
                double newmanb = test1.Item2;
                //Console.WriteLine("Mandel x is: " + newmana);
                //Console.WriteLine("Mandel y is: " + newmanb);
                pyt = Math.Sqrt(newmana * newmana + newmanb * newmanb);
                //Console.Write("Afstand is: " + pyt);
                mana = newmana;
                manb = newmanb;

            } while (pyt <= 2 & counter < herhalingen);

            //Console.WriteLine("\nDone!");
            //Console.WriteLine("Afstand is: " + pyt);
            //Console.WriteLine("De teller is geïndigd op: " + counter);

            return counter;
        }
        public static (double, double) Formula(double x, double y, double a, double b)
        {
            double manx = a * a - b * b + x;
            double many = 2 * a * b + y;
            return (manx, many);
        }
    }
}
