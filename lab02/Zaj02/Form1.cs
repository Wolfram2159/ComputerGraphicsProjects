using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Zaj02
{
    public partial class Form1 : Form
    {
        private System.Drawing.Graphics g;
        private System.Drawing.Pen pen = new System.Drawing.Pen(Color.Red, 1);
        PointF[] points = new PointF[300];
        double kat = 0;
        double theta = (2 * Math.PI) / 300;
        public Form1()
        {
            InitializeComponent();
            g = pictureBox1.CreateGraphics();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            g.Clear(Color.White);
            theta = (2 * Math.PI) / 300;
            for (int i = 0; i < 300; i++)
            {               
                float x = 150 * (float)Math.Cos(kat)+150;
                float y = 150 * (float)Math.Sin(kat)+150;
                points[i] = new PointF(x,y);
                kat += theta;            
            }
            g.DrawLines(pen, points);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            g.Clear(Color.White);
            theta = (2 * Math.PI) / 300;
            for (int i = 0; i < 300; i++)
            {
                double x = 150 * Math.Cos(kat) + 150;
                double y = 150 * Math.Sin(kat) + 150;
                points[i] = new Point((int)x, (int)y);
                kat += 95*theta;
            }
            g.DrawLines(pen, points);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            g.Clear(Color.White);
            kat = 0;
            button1_Click(sender, e);
            int x = 0;
            int y = 50;
            int w = 300;
            int h = 200;

            g.DrawEllipse(pen, x, y, w, h);
            g.DrawEllipse(pen, y, x, h, w);
            for(int i = 0; i < 5; i++)
            {
                
                x = 150 - (h / 2);
                w = h;
                h = 2 * w / 3;
                y = 150 - (h / 2);
                

                g.DrawEllipse(pen, x, y, w, h);
                g.DrawEllipse(pen, y, x, h, w);
            }
            

        }

        private void button4_Click(object sender, EventArgs e)
        {
            g.Clear(Color.White);
            int n = 3;
            int r = 150;
            float alfa = 0;
            float dalfa = 0.0628F;            
            int nn = 100 * n;
            PointF[] pointsSpiral = new PointF[nn];
            float rr = r / nn;
            pointsSpiral[0] = new PointF(200,200);
            for(int i = 1; i < nn; i++)
            {
                alfa += dalfa;
                float rb = 0.6F * i;
                float x = rb * (float)Math.Cos(alfa)+200;
                float y = rb * (float)Math.Sin(alfa)+200;
                pointsSpiral[i] = new PointF(x, y);
            }
            g.DrawLines(pen, pointsSpiral);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            g.Clear(Color.White);
            int n = 3;
            int r = 150;
            float alfa = 0;
            float dalfa = 0.0628F;
            int nn = 100 * n;            
            PointF[] points1 = new PointF[nn];
            PointF[] points2 = new PointF[nn];
            PointF[] points3 = new PointF[nn];
            PointF[] points4 = new PointF[nn];
            float rr = r / nn;
            int center = 200;            
            points1[0] = new PointF(center, center);
            points2[0] = new PointF(center, center);
            points3[0] = new PointF(center, center);
            points4[0] = new PointF(center, center);

            for (int i = 1; i < nn; i++)
            {
                alfa += dalfa;
                float rb = 0.6F * i;                
                float x1 = rb * (float)Math.Cos(Math.PI + alfa) + center;
                float y1 = rb * (float)Math.Sin(Math.PI + alfa) + center;
                float x2 = rb * (float)Math.Cos(0.5*Math.PI + alfa) + center;
                float y2 = rb * (float)Math.Sin(0.5*Math.PI + alfa) + center;
                float x3 = rb * (float)Math.Cos(1.5 * Math.PI + alfa) + center;
                float y3 = rb * (float)Math.Sin(1.5 * Math.PI + alfa) + center;
                float x4 = rb * (float)Math.Cos(alfa) + center;
                float y4 = rb * (float)Math.Sin(alfa) + center;
                points1[i] = new PointF(x1, y1);
                points2[i] = new PointF(x2, y2);
                points3[i] = new PointF(x3, y3);
                points4[i] = new PointF(x4, y4);
            }
            float rx = points4[nn - 1].X - center;
            float ry = points4[nn - 1].Y - center;
            float prom = (float)Math.Sqrt(rx * rx + ry * ry);
           
            g.DrawLines(pen, points1);
            g.DrawLines(pen, points2);
            g.DrawLines(pen, points3);
            g.DrawLines(pen, points4);
            kat = 0;
            theta = (2 * Math.PI) / nn;
            for (int i = 0; i < nn; i++)
            {
                float x = prom * (float)Math.Cos(kat) + center;
                float y = prom * (float)Math.Sin(kat) + center;
                points4[i] = new PointF(x, y);
                kat += theta;
            }
            g.DrawLines(pen, points4);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            g.Clear(Color.White);
            int ile = 20;
            Point[] pointsAll = new Point[ile];
            kat = 0;
            theta = 2 * Math.PI / ile;
            for (int i = 0; i < ile; i++)
            {
                double x = 150 * Math.Cos(kat) + 150;
                double y = 150 * Math.Sin(kat) + 150;
                pointsAll[i] = new Point((int)x, (int)y);
                kat += theta;
            }
            for(int i = 0; i < ile; i++)
            {
                for(int j = 0; j< ile; j++)
                {
                    if (i != j)
                    {
                        g.DrawLine(pen, pointsAll[j], pointsAll[i]);
                    }
                }
            }
            g.DrawLines(pen, pointsAll);
        }
    }
}
