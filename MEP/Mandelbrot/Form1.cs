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
            int standaardTextBox = 100;
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

            this.Controls.Add(labelX);
            this.Controls.Add(fieldX);
            this.Controls.Add(labelY);
            this.Controls.Add(fieldY);
            this.Controls.Add(labelSchaal);
            this.Controls.Add(fieldSchaal);
            this.Controls.Add(labelMax);
            this.Controls.Add(fieldMax);
            MaakOkKnop();

            this.CreateMyPanel();
        }

        public void CreateMyPanel()
        {
            Panel panel1 = new Panel();
            TextBox textBox1 = new TextBox();
            Label label1 = new Label();

            // Initialize the Panel control.
            panel1.Location = new Point(0, 75);
            panel1.Size = new Size(400, 400);
            // Set the Borderstyle for the Panel to three-dimensional.
            panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            // Add the Panel control to the form.
            this.Controls.Add(panel1);
            
        }
        private void MaakOkKnop()
        {
            Button buttonOk = new Button()
            {
                Text = "OK",
                Location = new Point(320, 35),
                Size = new Size(45, 20)
            };
            buttonOk.DialogResult = DialogResult.OK;
            Controls.Add(buttonOk);
        }
    }
}
