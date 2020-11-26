using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mandelbrot
{
    public partial class Form1 : Form
    {
        int schaal = 100;
        int herhalingen = 100;

        public Form1()
        {
            InitializeComponent();
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Invalidate();

            var p = sender as Panel;
            var g = e.Graphics;

            Brush brushZwart = new SolidBrush(Color.Black);
            Brush brushWit = new SolidBrush(Color.White);

            int mandelGetal;
            double xWaarde;
            double yWaarde;

            for (int x = 0; x < panel1.Width; x++)
            {
                for (int y = 0; y < panel1.Height; y++)
                {
                    xWaarde = ((double)x - (panel1.Width / 2)) / schaal;
                    yWaarde = ((double)y - (panel1.Height / 2)) / schaal;

                    mandelGetal = Mandelbrot.Mandel(herhalingen, xWaarde, yWaarde);
                    
                    // if mandelgetal even wordt het wit. Als oneven zwart. Oneindig ook zwart.
                    if ((mandelGetal % 2 == 0) & mandelGetal != herhalingen)
                    {
                        g.FillRectangle(brushWit, x, y, 1, 1);
                    }
                    else
                    {
                        g.FillRectangle(brushZwart, x, y, 1, 1);
                    }
                }
            }
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            try
            {
                herhalingen = int.Parse(textBoxMax.Text);
                this.Invalidate();
            }
            catch (Exception ex) 
            {
                // Iets responsiefs voor de gebruiker toevoegen?
                herhalingen = 0;
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
