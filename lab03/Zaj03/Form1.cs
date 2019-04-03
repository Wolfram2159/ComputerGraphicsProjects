using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Zaj03
{
    public partial class Form1 : Form
    {
        private System.Drawing.Graphics g;
        private System.Drawing.Pen pen1 = new System.Drawing.Pen(Color.Blue, 2);
        PointF p1;
        PointF p2;
        PointF p3;
        PointF p4;
        public Form1()
        {
            InitializeComponent();
            g = pictureBox1.CreateGraphics();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            takePoints();
            float delta = (p2.X - p1.X) * (p3.Y - p4.Y) - (p3.X - p4.X) * (p2.Y - p1.Y);
            if (delta == 0)
            {
                MessageBoxButtons buttons = MessageBoxButtons.OK;

                MessageBox.Show("Proste są równoległe", "Informacja", buttons);
            }
            else
            {
                float deltaMi = (p3.X - p1.X) * (p3.Y - p4.Y) - (p3.X - p4.X) * (p3.Y - p1.Y);
                float mi = deltaMi / delta;
                PointF pp = new PointF((1 - mi) * p1.X + mi * p2.X, (1 - mi) * p1.Y + mi * p2.Y);
                MessageBoxButtons buttons = MessageBoxButtons.OK;

                MessageBox.Show("Punkt przecięcia - X:" + pp.X + " Y:" + pp.Y, "Informacja", buttons);
                g.Clear(Color.White);
                g.DrawLine(pen1, p1, p2);
                g.DrawLine(pen1, p3, p4);
                g.DrawEllipse(pen1, pp.X - 5, pp.Y - 5, 10, 10);
            }
        }
        public void takePoints()
        {
            p1 = new PointF(float.Parse(textBox1.Text), float.Parse(textBox2.Text));
            p2 = new PointF(float.Parse(textBox3.Text), float.Parse(textBox4.Text));
            p3 = new PointF(float.Parse(textBox5.Text), float.Parse(textBox6.Text));
            p4 = new PointF(float.Parse(textBox7.Text), float.Parse(textBox8.Text));

        }
        public void take2Points()
        {
            p1 = new PointF(float.Parse(textBox1.Text), float.Parse(textBox2.Text));
            p2 = new PointF(float.Parse(textBox3.Text), float.Parse(textBox4.Text));
            //p3 = new PointF(float.Parse(textBox5.Text), float.Parse(textBox6.Text));
            //p4 = new PointF(float.Parse(textBox7.Text), float.Parse(textBox8.Text));

        }
        private void button2_Click(object sender, EventArgs e)
        {
            takePoints();
            float a1 = (p2.Y - p1.Y) / (p2.X - p1.X);
            float a2 = (p4.Y - p3.Y) / (p4.X - p3.X);
            double angle = Math.Atan(Math.Abs((a1 - a2) / (1 + a1 * a2)));
            angle = (180 / Math.PI) * angle; // radiany na stopnie
            MessageBoxButtons buttons = MessageBoxButtons.OK;

            MessageBox.Show("Kat wynosi: " + angle, "Informacja", buttons);
            g.Clear(Color.White);
            g.DrawLine(pen1, p1, p2);
            g.DrawLine(pen1, p3, p4);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            take2Points();
            float x1 = p1.X;
            float y1 = p1.Y;
            float z1 = float.Parse(textBox9.Text);
            float x2 = p2.X;
            float y2 = p2.Y;
            float z2 = float.Parse(textBox10.Text);
            float x3 = p3.X;
            float y3 = p3.Y;
            float z3 = float.Parse(textBox11.Text);
            float v1x = x2 - x1;
            float v1y = y2 - y1;
            float v1z = z2 - z1;
            float v2x = x3 - x1;
            float v2y = y3 - y1;
            float v2z = z3 - z1;
            float x4 = v1y * v2z - v2y * v1z;
            float y4 = v1z * v2x - v2z * v1y;
            float z4 = v1x * v2y - v2x * v1y;
            MessageBoxButtons buttons = MessageBoxButtons.OK;

            MessageBox.Show(x4 + "(x-" + x1 + ")+" + y4 + "(y-" + y1 + ")+" + z4 +"(z-"+z1+")=0", "Informacja", buttons);


        }

        private void button3_Click(object sender, EventArgs e)
        {
            float b = float.Parse(textBox12.Text);
            float d = float.Parse(textBox13.Text);
            float n = float.Parse(textBox14.Text);
            float k = float.Parse(textBox15.Text);
            float mi = (k - (n * b))/(n * d);
            MessageBoxButtons buttons = MessageBoxButtons.OK;

            MessageBox.Show("u = "+mi, "Informacja", buttons);

        }
    }
}
