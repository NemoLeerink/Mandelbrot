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
        int modeSelected;
        bool basis = true;
        bool experiment = false;

        public Form1()
        {
            InitializeComponent();
        }

        public void panel1_Paint(object sender, PaintEventArgs e)
        {
            textBoxX.Text = middenX.ToString();
            textBoxY.Text = middenY.ToString();
            textBoxSchaal.Text = schaal.ToString();
            textBoxMax.Text = herhalingen.ToString();

            Panel p = sender as Panel;
            Graphics g = e.Graphics;

            Color myRgbColor;
            Brush brushZwart = new SolidBrush(Color.Black);
            Brush brushWit = new SolidBrush(Color.White);

            int mandelGetal;
            double xWaarde;
            double yWaarde;

            for (int x = 0; x < panel1.Width; x++)
            {
                for (int y = 0; y < panel1.Height; y++)
                {
                    xWaarde = (((double)x - 200) * schaal) + middenX;
                    yWaarde = ((((double)y * -1) + 200) * schaal) + middenY;

                    mandelGetal = Mandelbrot.Mandel(herhalingen, xWaarde, yWaarde);

                    if (basis)
                    {
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

                    if (experiment)
                    { 
                        myRgbColor = Color.FromArgb(mandelGetal*2, 255/mandelGetal, 10);
                        Brush brushTest = new SolidBrush(myRgbColor);
                        g.FillRectangle(brushTest, x, y, 1, 1);
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
                modeSelected = listBox1.SelectedIndex;

                if (modeSelected == 0)
                {
                    basis = true;
                    experiment = false;
                }
                else if (modeSelected == 1) 
                {
                    basis = false;
                    experiment = true;
                }
            }
            catch (Exception ex) 
            {
                // Iets responsiefs voor de gebruiker toevoegen?
            }

            this.panel1.Refresh();
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
                    
                    middenX += (e.X - 200) * schaal;
                    middenY += ((e.Y * -1) + 200) * schaal;
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
                   
                    middenX += (e.X - 200) * schaal;
                    middenY += ((e.Y * -1) + 200) * schaal;
                    schaal = schaal / 2;

                }
                catch (Exception ex)
                {
                    // Iets responsiefs voor de gebruiker toevoegen?
                }
            }
            // initialize deed het niet. Weet nog niet waarom niet 
            this.panel1.Refresh();
        }
    }
}
