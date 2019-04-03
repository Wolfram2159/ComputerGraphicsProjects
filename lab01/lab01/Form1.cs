using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab01
{

    public partial class Form1 : Form
    {
        //jp
        private System.Drawing.Graphics g;
        private System.Drawing.Pen pen = new System.Drawing.Pen(Color.Blue, 2);
        PointF p1 = new PointF();
        PointF p2 = new PointF();
        PointF p3 = new PointF();
        PointF p4 = new PointF();
        PointF[] tp = new PointF[4];
        public Form1()
        {
            InitializeComponent();
            g = pictureBox1.CreateGraphics();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            g.Clear(Color.White);
            p1.X = (float)Double.Parse(textBox1.Text);
            p1.Y = (float)Double.Parse(textBox2.Text);
            g.DrawLine(pen, 0, 0, p1.X, p1.Y);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //g.Rectangle(memoryContext, 10, 10, 200, 200);
            g.Clear(Color.White);
            p1.X = (float)Double.Parse(textBox1.Text);
            p1.Y = (float)Double.Parse(textBox2.Text);
            p2.X = (float)Double.Parse(textBox3.Text);
            p2.Y = (float)Double.Parse(textBox4.Text);
            g.DrawRectangle(pen, p1.X, p1.Y, p2.X, p2.Y);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            g.Clear(Color.White);
            p1.X = (float)Double.Parse(textBox1.Text);
            p1.Y = (float)Double.Parse(textBox2.Text);
            p2.X = (float)Double.Parse(textBox3.Text);
            p2.Y = (float)Double.Parse(textBox4.Text);
            g.DrawEllipse(pen, p1.X, p1.Y, p2.X, p2.Y);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            g.Clear(Color.White);
            p3.X = 0;
            p3.Y = 100;
            p4.X = 100;
            p4.Y = 0;
            p1.X = (float)Double.Parse(textBox1.Text);
            p1.Y = (float)Double.Parse(textBox2.Text);
            p2.X = (float)Double.Parse(textBox3.Text);
            p2.Y = (float)Double.Parse(textBox4.Text);
            g.DrawBezier(pen, p1, p2, p3, p4);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            g.Clear(Color.White);
            tp[0] = p1;
            tp[1] = p2;
            tp[2] = p3;
            tp[3] = p4;
            p3.X = 0;
            p3.Y = 100;
            p4.X = 100;
            p4.Y = 0;
            p1.X = (float)Double.Parse(textBox1.Text);
            p1.Y = (float)Double.Parse(textBox2.Text);
            p2.X = (float)Double.Parse(textBox3.Text);
            p2.Y = (float)Double.Parse(textBox4.Text);
            g.DrawPolygon(pen, tp);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            g.Clear(Color.White);
            p1.X = (float)Double.Parse(textBox1.Text);
            p1.Y = (float)Double.Parse(textBox2.Text);
            p2.X = (float)Double.Parse(textBox3.Text);
            p2.Y = (float)Double.Parse(textBox4.Text);
            g.DrawArc(pen, p1.X, p1.Y, p2.X, p2.Y, 50, 100);

        }
    }
}
