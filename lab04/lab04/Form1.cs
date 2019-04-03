using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab04
{
    public partial class Form1 : Form
    {
        //jp
        private System.Drawing.Graphics g;
        private System.Drawing.Pen pen = new System.Drawing.Pen(Color.Red, 1);
        double Tx;
        double Ty;
        double Sx;
        double Sy;
        double angle;
        public Form1()
        {
            InitializeComponent();
            g = pictureBox1.CreateGraphics();
        }
        public void takeParams()
        {
            Tx = double.Parse(textBox1.Text);
            Ty = double.Parse(textBox2.Text);
            Sx = double.Parse(textBox3.Text);
            Sy = double.Parse(textBox4.Text);
            angle = double.Parse(textBox5.Text);
        }
        public PointF translate(PointF point)
        {
            point.X += (float)Tx;
            point.Y += (float)Ty;
            return point;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            takeParams();
            g.Clear(Color.White);
            PointF[] points = new PointF[300];
            double kat = 0;
            double theta = (2 * Math.PI) / 300;
            for (int i = 0; i < 300; i++)
            {
                float x = (float) (150 * Math.Cos(kat) + 150);
                float y = (float)(150 * Math.Sin(kat) + 150);
                points[i] = new PointF(x, y);
                kat += theta;
            }
            g.DrawLines(pen, points);
            for (int i = 0; i < 300; i++)
            {
                points[i] = translate(points[i]);
            }
            g.DrawLines(pen, points);
        }
        public PointF rotate(PointF point)
        {
            float katRadian = (float)(angle * Math.PI) / 180;
            point.X = (float)(point.X * Math.Cos(katRadian) + point.Y * Math.Sin(katRadian));
            point.Y = (float)(point.Y * Math.Cos(katRadian) - point.X * Math.Sin(katRadian));
            return point;
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            takeParams();
            g.Clear(Color.White);
            PointF[] points = new PointF[5];
            points[0] = new PointF(250, 250);
            points[1] = new PointF(300, 250);
            points[2] = new PointF(300, 300);
            points[3] = new PointF(250, 300);
            points[4] = new PointF(250, 250);
            g.DrawLines(pen, points);
            for (int i = 0; i < 5; i++)
            {
                points[i] = rotate(points[i]);
            }
            g.DrawLines(pen, points);
        }
        public PointF scale(PointF point)
        {
            point.X *= (float)Sx;
            point.Y *= (float)Sy;
            return point;
        }
        public float scaleX(float x)
        {
            return (float)Sx * x;
        }
        public float scaleY(float y)
        {
            return (float)Sy * y;
        }
        private void button3_Click(object sender, EventArgs e)
        {
            takeParams();
            g.Clear(Color.White);
            g.DrawEllipse(pen,0, 0, 100, 200);
            g.DrawEllipse(pen, 0, 0, scaleX(100), scaleY(200));
        }

        private void button4_Click(object sender, EventArgs e)
        {
            takeParams();
            g.Clear(Color.White);
            PointF[] points = new PointF[300];
            double kat = 0;
            double theta = (2 * Math.PI) / 300;
            for (int i = 0; i < 300; i++)
            {
                float x = (float)(150 * Math.Cos(kat) + 150);
                float y = (float)(150 * Math.Sin(kat) + 150);
                points[i] = new PointF(x, y);
                kat += theta;
            }
            g.DrawLines(pen, points);
            for (int i = 0; i < 300; i++)
            {
                points[i] = scale(points[i]);
                points[i] = translate(points[i]);
            }
            g.DrawLines(pen, points);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            takeParams();
            g.Clear(Color.White);
            PointF[] points = new PointF[5];
            points[0] = new PointF(250, 250);
            points[1] = new PointF(300, 250);
            points[2] = new PointF(300, 300);
            points[3] = new PointF(250, 300);
            points[4] = new PointF(250, 250);
            g.DrawLines(pen, points);
            for (int i = 0; i < 5; i++)
            {
                points[i] = rotate(points[i]);
                points[i] = translate(points[i]);
            }
            g.DrawLines(pen, points);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            takeParams();
            g.Clear(Color.White);
            PointF[] points = new PointF[5];
            points[0] = new PointF(50, 50);
            points[1] = new PointF(150, 50);
            points[2] = new PointF(200, 200);
            points[3] = new PointF(0, 200);
            points[4] = new PointF(50, 50);
            g.DrawLines(pen, points);
            for (int i = 0; i < 5; i++)
            {
                points[i] = scale(points[i]);
                points[i] = rotate(points[i]);
            }
            g.DrawLines(pen, points);
        }
    }
}
