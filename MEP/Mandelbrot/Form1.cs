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
        public Form1()
        {
            /*int standaardTextBox = 100;
            int labelSize = 60;
            
            Label labelX = new Label()
            {
                Text = "Midden X:",
                Location = new Point(10, 10),
                TabIndex = 5,
                Size = new Size(labelSize, 20)
            };

            TextBox fieldX = new TextBox()
            {
                Location = new Point(75, 10),
                TabIndex = 11,
                Size = new Size(standaardTextBox, 20)
            };

            Label labelY = new Label()
            {
                Text = "Midden Y:",
                Location = new Point(10, 35),
                TabIndex = 12,
                Size = new Size(labelSize, 20)
            };

            TextBox fieldY = new TextBox()
            {
                Location = new Point(75, 35),
                TabIndex = 11,
                Size = new Size(standaardTextBox, 20)
            };
            
            Label labelSchaal = new Label()
            {
                Text = "Schaal:",
                Location = new Point(200, 10),
                TabIndex = 12,
                Size = new Size(labelSize, 20)
            };

            TextBox fieldSchaal = new TextBox()
            {
                Location = new Point(265, 10),
                TabIndex = 11,
                Size = new Size(standaardTextBox, 20)
            };

            Label labelMax = new Label()
            {
                Text = "Max:",
                Location = new Point(200, 35),
                TabIndex = 12,
                Size = new Size(labelSize, 20)
            };

            TextBox fieldMax = new TextBox()
            {
                Location = new Point(265, 35),
                TabIndex = 11,
                Size = new Size(50, 20)
            };

            Button buttonOk = new Button()
            {
                Text = "OK",
                Location = new Point(320, 35),
                Size = new Size(45, 20)
            };
            buttonOk.DialogResult = DialogResult.OK;
            Controls.Add(buttonOk);

            this.Controls.Add(labelX);
            this.Controls.Add(fieldX);
            this.Controls.Add(labelY);
            this.Controls.Add(fieldY);
            this.Controls.Add(labelSchaal);
            this.Controls.Add(fieldSchaal);
            this.Controls.Add(labelMax);
            this.Controls.Add(fieldMax);*/

            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            var p = sender as Panel;
            var g = e.Graphics;

            Brush brushZwart = new SolidBrush(Color.Black);
            Brush brushWit = new SolidBrush(Color.White);

            int mandelGetal;
            int schaal = 100;
            int herhalingen = 100;
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

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
