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
        double schaal = 0.01;
        int herhalingen = 100;
        double middenX = 0;
        double middenY = 0;

        public Form1()
        {
            InitializeComponent();
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        public void panel1_Paint(object sender, PaintEventArgs e)
        {
            Panel p = sender as Panel;
            Graphics g = e.Graphics;

            Brush brushZwart = new SolidBrush(Color.Black);
            Brush brushWit = new SolidBrush(Color.White);

            int mandelGetal;
            double xWaarde;
            double yWaarde;

            double defaultMiddenX = panel1.Width / 2; // 200
            double defaultMiddenY = panel1.Height / 2; // 200

            for (int x = 0; x < panel1.Width; x++)
            {
                for (int y = 0; y < panel1.Height; y++)
                {
           
                    xWaarde = (((double)x - defaultMiddenX) * schaal) + middenX;
                    yWaarde = ((double)y - defaultMiddenY) * schaal + middenY;

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
                middenX = double.Parse(textBoxX.Text);
                middenY = double.Parse(textBoxY.Text);
                herhalingen = int.Parse(textBoxMax.Text);
                schaal = double.Parse(textBoxSchaal.Text);
            }
            catch (Exception ex) 
            {
                // Iets responsiefs voor de gebruiker toevoegen?
            }

            this.panel1.Refresh();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void panel1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                try
                {
                    schaal = schaal * 2;

                }
                catch (Exception ex)
                {
                    // Iets responsiefs voor de gebruiker toevoegen?
                }
            }
            else if (e.Button == MouseButtons.Left) 
            {
                try
                {
                    schaal = schaal / 2;

                }
                catch (Exception ex)
                {
                    // Iets responsiefs voor de gebruiker toevoegen?
                }
            }
             this.panel1.Refresh();
        }
    }
}
