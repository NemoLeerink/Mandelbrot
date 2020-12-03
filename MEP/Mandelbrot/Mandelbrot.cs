/**
 * @author Michiel Borghuis & Nemo Leerink.
 * Groep 2. 
 * Dit programma laat een mandelbrot figuur zien en heeft een aantal interactieve componenten. 
 */

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
        
        // Deze methode berekend het mandelgetal
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
                
                // Berekend de afstand tot het 0-punt
                pyt = Math.Sqrt(newmana * newmana + newmanb * newmanb);
            
                mana = newmana;
                manb = newmanb;

            } while (pyt <= 2 & mandelgetal < herhalingen);

            return mandelgetal;
        }
        // Berekend het nieuwe punt
        static (double, double) Formula(double x, double y, double a, double b)
        {
            double manx = a * a - b * b + x;
            double many = 2 * a * b + y;
            return (manx, many);
        }
    }
}
