using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mandelbrot
{
    static class Mandelbrot
    {
        static void Main()
        {
            Application.Run(new Form1());
        }
        public static int Mandel(int herhalingen, double x, double y)
        {
            double pyt = 0;
            double manx = x;
            double many = y;
            double mana = 0;
            double manb = 0;
            int mandelgetal = 0;
            
            do
            {
                mandelgetal += 1;
               
                (double, double) mangetallen = Formula(manx, many, mana, manb);
                double newmana = mangetallen.Item1;
                double newmanb = mangetallen.Item2;
                
                pyt = Math.Sqrt(newmana * newmana + newmanb * newmanb);
            
                mana = newmana;
                manb = newmanb;

            } while (pyt <= 2 & mandelgetal < herhalingen);

            return mandelgetal;
        }
        static (double, double) Formula(double x, double y, double a, double b)
        {
            double manx = a * a - b * b + x;
            double many = 2 * a * b + y;
            return (manx, many);
        }
    }
}
