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
        int modeSelected = 0;
        int prevModeSelected = 0;
        
        // De verschillende kleur-variaties
        bool basis = true;
        bool toxic = false;
        bool spikkels = false;
        bool spiraal = false;

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
           
            // Het x- en y-punt vaarvoor het mandelgetal moet worden berekend
            double xWaarde; 
            double yWaarde;

            // Teken het mandelfiguur
            for (int x = 0; x < panel1.Width; x++)
            {
                for (int y = 0; y < panel1.Height; y++)
                {
                    xWaarde = (((double)x - 200) * schaal) + middenX;
                    yWaarde = ((((double)y * -1) + 200) * schaal) + middenY;

                    mandelGetal = Mandelbrot.Mandel(herhalingen, xWaarde, yWaarde);

                    // Het "normale" mandelbrot figuur
                    if (basis)
                    {
                        // if mandelgetal even wordt het wit. Als oneven zwart. Oneindig ook zwart
                        if ((mandelGetal % 2 == 0) & mandelGetal != herhalingen)
                        {
                            g.FillRectangle(brushWit, x, y, 1, 1);
                        }
                        else
                        {
                            g.FillRectangle(brushZwart, x, y, 1, 1);
                        }
                    }

                    // Een variatie op het mandelfiguur met groen en rood
                    if (toxic)
                    { 
                        myRgbColor = Color.FromArgb(mandelGetal*2/herhalingen*100, 255/mandelGetal, 1*mandelGetal);
                        Brush brushToxic = new SolidBrush(myRgbColor);
                        g.FillRectangle(brushToxic, x, y, 1, 1);
                    }

                    // Een variatie op het mandelfiguur met allerlei verschillende kleuren
                    if (spikkels)
                    {
                        Brush lichtBlauw = new SolidBrush(Color.LightBlue);
                        Brush brushRood = new SolidBrush(Color.Red);
                        Brush brushOranje = new SolidBrush(Color.Orange);
                        Brush brushGeel = new SolidBrush(Color.Yellow);
                        Brush brushGroen = new SolidBrush(Color.Green);
                        Brush brushBlauw = new SolidBrush(Color.Blue);
                        Brush brushPaars = new SolidBrush(Color.Purple);

                        if ((mandelGetal % 2 == 0) & mandelGetal != herhalingen)
                        {
                            g.FillRectangle(brushWit, x, y, 1, 1);
                        }
                        else if ((mandelGetal % 3 == 0) & mandelGetal != herhalingen)
                        {
                            g.FillRectangle(brushRood, x, y, 1, 1);
                        }
                        else if ((mandelGetal % 5 == 0) & mandelGetal != herhalingen)
                        {
                            g.FillRectangle(brushOranje, x, y, 1, 1);
                        }
                        else if ((mandelGetal % 7 == 0) & mandelGetal != herhalingen)
                        {
                            g.FillRectangle(brushGeel, x, y, 1, 1);
                        }
                        else if ((mandelGetal % 11 == 0) & mandelGetal != herhalingen)
                        {
                            g.FillRectangle(brushGroen, x, y, 1, 1);
                        }
                        else if ((mandelGetal % 13 == 0) & mandelGetal != herhalingen)
                        {
                            g.FillRectangle(brushBlauw, x, y, 1, 1);
                        }
                        else if ((mandelGetal % 17 == 0) & mandelGetal != herhalingen)
                        {
                            g.FillRectangle(brushPaars, x, y, 1, 1);
                        }
                        else
                        {
                            g.FillRectangle(lichtBlauw, x, y, 1, 1);
                        }
                    }
                   
                    // Een variatie op het mandelfiguur die een spiraal laat zien
                    if (spiraal)
                    {
                        int herh5 = herhalingen / 5;
                        
                        if (mandelGetal == herhalingen)
                        {
                            g.FillRectangle(brushZwart, x, y, 1, 1);
                        }
                        else if (mandelGetal < herh5)
                        {
                            myRgbColor = Color.FromArgb(255, Convert.ToInt32(mandelGetal*((double)255/herhalingen)), 0);
                            Brush rg = new SolidBrush(myRgbColor);
                            g.FillRectangle(rg, x, y, 1, 1);
                        }
                        else if (mandelGetal < 2*herh5)
                        {
                            myRgbColor = Color.FromArgb(255 - Convert.ToInt32(mandelGetal * ((double)255 / herhalingen)), 255, 0);
                            Brush gg = new SolidBrush(myRgbColor);
                            g.FillRectangle(gg, x, y, 1, 1);
                        }
                        else if (mandelGetal < 3*herh5)
                        {
                            myRgbColor = Color.FromArgb(0, 225, Convert.ToInt32(mandelGetal * ((double)255 / herhalingen)));
                            Brush ggb = new SolidBrush(myRgbColor);
                            g.FillRectangle(ggb, x, y, 1, 1);
                        }
                        else if (mandelGetal < 4 * herh5)
                        {
                            myRgbColor = Color.FromArgb(0, 255 - Convert.ToInt32(mandelGetal * ((double)255 / herhalingen)), 225);
                            Brush gbb = new SolidBrush(myRgbColor);
                            g.FillRectangle(gbb, x, y, 1, 1);
                        }
                        else if (mandelGetal < 5 * herh5)
                        {
                            myRgbColor = Color.FromArgb(Convert.ToInt32(mandelGetal * ((double)255 / herhalingen)), 0, 255);
                            Brush bp = new SolidBrush(myRgbColor);
                            g.FillRectangle(bp, x, y, 1, 1);
                        }
                    }
                }
            }
        }

        // Haalt de waardes uit de velden op
        private void buttonOk_Click(object sender, EventArgs e)
        {
            try
            {
                textBoxX.BackColor = Color.White;
                textBoxY.BackColor = Color.White;
                textBoxMax.BackColor = Color.White;
                textBoxSchaal.BackColor = Color.White;

                // Maakt van het sender object het aankomende object. Dit zodat de catch weet welk veld de exeption teweeg bracht
                sender = textBoxX;
                middenX = double.Parse(textBoxX.Text);
                sender = textBoxY;
                middenY = double.Parse(textBoxY.Text);
                sender = textBoxMax;
                herhalingen = int.Parse(textBoxMax.Text);
                sender = textBoxSchaal;
                schaal = double.Parse(textBoxSchaal.Text);
    
                modeSelected = listBox1.SelectedIndex;

                if (modeSelected == 0)
                {
                    basis = true;
                    toxic = false;
                    spikkels = false;   
                    spiraal = false;

                    prevModeSelected = 0;
                }
                else if (modeSelected == 1 && prevModeSelected != 1)
                {
                    middenX = -0.103125;
                    middenY = 0.935;
                    schaal = 0.0003125;
                    herhalingen = 75;

                    basis = false;
                    toxic = true;
                    spikkels = false;
                    spiraal = false;

                    prevModeSelected = 1;
                }
                else if (modeSelected == 2 && prevModeSelected != 2)
                {
                    middenX = -0.188046875;
                    middenY = 0.666640625;
                    schaal = 1.953125E-05;
                    herhalingen = 10000;

                    basis = false;
                    toxic = false;
                    spikkels = true;
                    spiraal = false;

                    prevModeSelected = 2;
                }
                
                else if (modeSelected == 3 && prevModeSelected != 3)
                {
                    middenX = -0.570546875;
                    middenY = -0.561953125;
                    schaal = 3.90625E-05;
                    herhalingen = 100;

                    basis = false;
                    toxic = false;
                    spikkels = false;  
                    spiraal = true;

                    prevModeSelected = 3;
                }
            }
            catch (Exception ex)
            {
                // Maakt de textbox met een verkeerde input rood
                ((TextBox)sender).BackColor = Color.Red;
            }

            this.panel1.Refresh();
        }
        private void panel1_MouseClick(object sender, MouseEventArgs e)
        {
            // Zoomed het plaatje uit en maakt van het aangeklikte punt het middelpunt
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
                    Console.WriteLine(ex);
                }
            }
            // Zoomed het plaatje in en maakt van het aangeklikte punt het middelpunt
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
                    Console.WriteLine(ex);
                }
            }
            this.panel1.Refresh();
        }
    }
}
