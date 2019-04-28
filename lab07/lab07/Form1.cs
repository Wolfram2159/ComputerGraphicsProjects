using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab07
{
    public partial class Form1 : Form
    {
        private System.Drawing.Graphics g;
        private System.Drawing.Pen pen = new System.Drawing.Pen(Color.Red, 1);
        public Form1()
        {
            InitializeComponent();
            g = pictureBox1.CreateGraphics();
            trackBar1.ValueChanged += new System.EventHandler(TrackBar1_ValueChanged);
            trackBar2.ValueChanged += new System.EventHandler(TrackBar2_ValueChanged);
            trackBar3.ValueChanged += new System.EventHandler(TrackBar3_ValueChanged);
        }
        private void TrackBar1_ValueChanged(object sender, System.EventArgs e)
        {
            label1.Text = trackBar1.Value.ToString();
        }
        private void TrackBar2_ValueChanged(object sender, System.EventArgs e)
        {
            label2.Text = trackBar2.Value.ToString();
        }
        private void TrackBar3_ValueChanged(object sender, System.EventArgs e)
        {
            label3.Text = trackBar3.Value.ToString();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            drawFirst(100);
        }
        public void drawFirst(int warunek)
        {
            g.Clear(Color.White);
            for (int i = 0; i <= warunek; i++)
            {
                for (int j = 0; j <= warunek; j++)
                {
                    int u = (int)(i * 255.0 / warunek);
                    int v = (int)(j * 255.0 / warunek);
                    pen.Color = Color.FromArgb(255, 255-v, u);
                    g.DrawRectangle(pen, warunek + i, j, 1, 1);
                    pen.Color = Color.FromArgb(255, 255 - v, u);
                    g.DrawRectangle(pen, warunek + i, j, 1, 1);
                    pen.Color = Color.FromArgb(255 - v, 255 - u, 0);
                    g.DrawRectangle(pen, i, warunek + j, 1, 1);
                    pen.Color = Color.FromArgb(255 - v, 0, u);
                    g.DrawRectangle(pen, warunek + i, warunek + j, 1, 1);
                    pen.Color = Color.FromArgb(255 - v, u, 255);
                    g.DrawRectangle(pen, 2*warunek + i, warunek + j, 1, 1);
                    pen.Color = Color.FromArgb(0, v, u);
                    g.DrawRectangle(pen, warunek + i, 2*warunek + j, 1, 1);
                    pen.Color = Color.FromArgb(v, 255, u);
                    g.DrawRectangle(pen, warunek + i, 3* warunek + j, 1, 1);                   
                }
            }           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            g.Clear(Color.White);
            int red = trackBar1.Value;
            int green = trackBar2.Value;
            int blue = trackBar3.Value;          
            for (int i = 0; i <= 75; i++)
            {
                for (int j = 0; j <= 75; j++)
                {
                    int u = (int)(i * 255.0/75);
                    int v = (int)(j * 255.0/75);
                    pen.Color = Color.FromArgb(red, green, blue);
                    g.DrawRectangle(pen, i, j, 1, 1);
                }
            }
            makeVisible();
            calculateRGB(red, green, blue);
            calculateCMY(red, green, blue);
            calculateHSV(red, green, blue);
        }
        public void calculateRGB(int r, int g, int b)
        {
            label7.Text = r.ToString();
            label8.Text = g.ToString();
            label9.Text = b.ToString();
        }
        public void calculateCMY(int r, int g, int b)
        {
            double c = Math.Round(r / 255.0, 3);
            double m = Math.Round(g / 255.0, 3);
            double y = Math.Round(b / 255.0, 3);
            label10.Text = c.ToString();
            label11.Text = m.ToString();
            label12.Text = y.ToString();
        }
        public void calculateHSV(int r, int g, int b)
        {
            double r1 = Math.Round(r / 255.0, 3);
            double g1 = Math.Round(g / 255.0, 3);
            double b1 = Math.Round(b / 255.0, 3);
            double cmin = r1 < g1 ? (r1 < b1 ? r1 : b1) : (g1 < b1 ? g1 : b1);
            double cmax = r1 > g1 ? (r1 > b1 ? r1 : b1) : (g1 > b1 ? g1 : b1);
            double s = 0;
            if(cmax != 0)
            {
                s = (cmax - cmin) / cmax;
            }           
            System.Drawing.Color color = System.Drawing.Color.FromArgb(r, g, b);
            float hue = color.GetHue();
            float saturation = color.GetSaturation();
            float lightness = color.GetBrightness();
            label13.Text = hue.ToString();
            label14.Text = s.ToString();
            label15.Text = cmax.ToString();
        }
        public void makeVisible()
        {
            label7.Visible = true;
            label8.Visible = true;
            label9.Visible = true;
            label10.Visible = true;
            label11.Visible = true;
            label12.Visible = true;
            label13.Visible = true;
            label14.Visible = true;
            label15.Visible = true;
        }
    }
}
