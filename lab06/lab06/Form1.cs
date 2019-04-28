using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab06
{
    public partial class Form1 : Form
    {
        private System.Drawing.Graphics g;
        private System.Drawing.Pen pen1 = new System.Drawing.Pen(Color.Blue, 3);
        private System.Drawing.Pen pen2 = new System.Drawing.Pen(Color.Red, 3);
        public Form1()
        {
            InitializeComponent();
            g = pictureBox1.CreateGraphics();
            numericUpDown1.Value = 100;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        public float returnFloat(string text)
        {
            return float.Parse(text);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            pictureBox1.Refresh();
            int n = GetPointsAmount();

            var p1 = new PointF(returnFloat(textBox1.Text), returnFloat(textBox2.Text));//new PointF(100, 100);
            var r1 = new PointF(returnFloat(textBox3.Text), returnFloat(textBox4.Text));//new PointF(500, 500);
            var p4 = new PointF(returnFloat(textBox5.Text), returnFloat(textBox6.Text));//new PointF(300, 100);
            var r4 = new PointF(returnFloat(textBox7.Text), returnFloat(textBox8.Text));//new PointF(500, 500);

            g.DrawLines(pen1, DrawHermite(p1, p4, r1, r4, n));
            //g.DrawLine(pen2, p1.X, p1.Y, p1.X + r1.X, p1.Y + r1.Y); //wektor r1
            //g.DrawLine(pen2, p4.X, p4.Y, p4.X + r4.X, p4.Y + r4.Y); // wektor r4
        }

        private PointF[] DrawHermite(PointF p1, PointF p4, PointF r1, PointF r4, int amount)
        {
            double currentT = 0;
            double deltaT = 1d / amount;
            PointF[] points = new PointF[amount];
            for (int i = 0; i < amount; i++)
            {
                double x = CalcHermite(p1.X, p4.X, r1.X, r4.X, currentT);
                double y = CalcHermite(p1.Y, p4.Y, r1.Y, r4.Y, currentT);
                points[i] = new PointF((float)x, (float)y);
                currentT += deltaT;
            }

            return points;
        }

        private PointF[] DrawBezier(PointF p1, PointF p2, PointF p3, PointF p4, int amount)
        {
            double currentT = 0;
            double deltaT = 1d / amount;
            PointF[] points = new PointF[amount];
            for (int i = 0; i < amount; i++)
            {
                double x = CalcBezier(p1.X, p2.X, p3.X, p4.X, currentT);
                double y = CalcBezier(p1.Y, p2.Y, p3.Y, p4.Y, currentT);
                points[i] = new PointF((float)x, (float)y);
                currentT += deltaT;
            }

            return points;
        }

        private PointF[] DrawBSpline(PointF[] refPoints, int amount)
        {
            double currentT = 0;
            double deltaT = 1d / amount;
            PointF[] points = new PointF[amount * (refPoints.Length - 3)];


            for (int i = 0; i < refPoints.Length - 3; i++)
            {

                for (int j = 0; j < amount; j++)
                {
                    double x = CalcBSpline(refPoints[i].X, refPoints[i + 1].X, refPoints[i + 2].X, refPoints[i + 3].X, currentT);
                    double y = CalcBSpline(refPoints[i].Y, refPoints[i + 1].Y, refPoints[i + 2].Y, refPoints[i + 3].Y, currentT);

                    points[j] = new PointF((float)x, (float)y);
                    currentT += deltaT;
                }
                currentT = 0;

            }
            return points;
        }

        private double CalcHermite(double p1, double p4, double r1, double r4, double t)
        {
            double tPow3 = Math.Pow(t, 3);
            double tPow2 = Math.Pow(t, 2);

            return (2 * tPow3 - 3 * tPow2 + 1) * p1 + (-2 * tPow3 + 3 * tPow2) * p4
                   + (tPow3 - 2 * tPow2 + t) * r1 + (tPow3 - tPow2) * r4;
        }

        private double CalcBezier(double p1, double p2, double p3, double p4, double t)
        {
            return Math.Pow((1 - t), 3) * p1
                   + 3 * t * Math.Pow((1 - t), 2) * p2
                   + 3 * t * t * (1 - t) * p3
                   + Math.Pow(t, 3) * p4;
        }

        //p1 => P (i-3)
        //p4 => P (i)
        private double CalcBSpline(double p1, double p2, double p3, double p4, double t)
        {
            return (Math.Pow(1 - t, 3) / 6d) * p1
                   + ((3 * Math.Pow(t, 3) - 6 * t * t + 4) / 6d) * p2
                   + (-3 * Math.Pow(t, 3) + 3 * Math.Pow(t, 2) + 3 * t + 1) / 6d * p3
                   + Math.Pow(t, 3) / 6d * p4;
        }

        private int GetPointsAmount()
        {
            return Convert.ToInt32(numericUpDown1.Value);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            pictureBox1.Refresh();
            int n = GetPointsAmount();

            var p1 = new PointF(returnFloat(textBox1.Text), returnFloat(textBox2.Text));//new PointF(100, 100);
            var p2 = new PointF(returnFloat(textBox3.Text), returnFloat(textBox4.Text));//new PointF(500, 500);
            var p3 = new PointF(returnFloat(textBox5.Text), returnFloat(textBox6.Text));//new PointF(300, 100);
            var p4 = new PointF(returnFloat(textBox7.Text), returnFloat(textBox8.Text));//new PointF(500, 500);
            //var p1 = new PointF(100, 100);
            //var p2 = new PointF(150, 10);
            //var p3 = new PointF(250, 190);
            //var p4 = new PointF(300, 100);


            g.DrawLines(pen1, DrawBezier(p1, p2, p3, p4, n));

            float r = 10;

            //g.DrawEllipse(pen2, p2.X - r, p2.Y - r, 2 * r, 2 * r);
            //g.DrawEllipse(pen2, p3.X - r, p3.Y - r, 2 * r, 2 * r);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            pictureBox1.Refresh();
            int n = GetPointsAmount();

            var p1 = new PointF(100, 100);
            var p2 = new PointF(150, 500);
            var p3 = new PointF(250, 600);
            var p4 = new PointF(600, 100);
            var p5 = new PointF(150, 200);
            var p6 = new PointF(50, 220);
            var p7 = new PointF(900, 600);

            PointF[] tab = { p1, p2, p3, p4, p5, p6, p7 };


            g.DrawLines(pen1, DrawBSpline(tab, n));
        }
    }
}
