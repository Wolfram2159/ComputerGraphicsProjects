using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gklab5
{    
    public partial class Form1 : Form
    {
        private System.Drawing.Graphics g;
        private System.Drawing.Pen pen = new System.Drawing.Pen(Color.White, 2);
        private PointF LineA;
        private PointF LineB;
        private PointF SegmentA;
        private PointF SegmentB;

        public Form1()
        {
            InitializeComponent();
            g = pictureBox1.CreateGraphics();
            LineA = new PointF(0, 400);
            LineB = new PointF(pictureBox1.Width, 100);
            SegmentA = new PointF(100, 100);
            SegmentB = new PointF(400, 400);
        }

        public void showMessage(String message)
        {
            MessageBoxButtons buttons = MessageBoxButtons.OK;

            MessageBox.Show(message, "Informacja", buttons);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            g.Clear(Color.Black);
            PointF A = new PointF(float.Parse(textBox1.Text), float.Parse(textBox2.Text));
            Circle c = new Circle(A);
            g.DrawLines(pen, c.drawCircle());
            g.DrawLine(pen, LineA, LineB);
            LineSegment straight = new LineSegment(LineA, LineB);         
            float y = straight.calculateValue(A.X);
            String message;
            if (A.Y > y) { message = "Punkt leży pod prostą"; }
            else if(A.Y == y) { message = "Punkt leży na prostej"; }
            else { message = "Punkt leży nad prostą"; }
            showMessage(message);
        }
        

        private void button2_Click(object sender, EventArgs e)
        {
            g.Clear(Color.Black);
            PointF A = new PointF(float.Parse(textBox1.Text), float.Parse(textBox2.Text));
            PointF B = new PointF(float.Parse(textBox3.Text), float.Parse(textBox4.Text));          
            
            g.DrawLines(pen, new Circle(A).drawCircle());
            g.DrawLines(pen, new Circle(B).drawCircle());
            g.DrawLine(pen, LineA, LineB);
            LineSegment straight = new LineSegment(LineA, LineB);
            String message;
            if (straight.isTwoPointsOnSameWay(A, B)) { message = "Leżą po tej samej stronie prostej"; }
            else { message = "Nie leża po tej samej stronie prostej"; }
            showMessage(message);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            g.Clear(Color.Black);
            PointF A = new PointF(float.Parse(textBox1.Text), float.Parse(textBox2.Text));           
            g.DrawLine(pen, SegmentA, SegmentB);
            g.DrawLines(pen, new Circle(A).drawCircle());
            LineSegment lineSegment = new LineSegment(SegmentA, SegmentB);
            String message;
            if (lineSegment.isOnSegment(A)) { message = "Punkt leży na odcinku"; }
            else { message = "Punkt nie leży na odcinku"; }
            showMessage(message);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            g.Clear(Color.Black);
            LineSegment lineSegmentA = new LineSegment(SegmentA, SegmentB);
            g.DrawLine(pen, SegmentA, SegmentB);
            PointF A = new PointF(float.Parse(textBox1.Text), float.Parse(textBox2.Text));
            PointF B = new PointF(float.Parse(textBox3.Text), float.Parse(textBox4.Text));
            g.DrawLine(pen, A, B);
            LineSegment lineSegmentB = new LineSegment(A, B);
            String message;
            if (lineSegmentA.isSegmentCrosses(lineSegmentB)) { message = "Odcinki się przecinają"; }
            else { message = "Odcinki się nie przecinają"; }
            showMessage(message);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            g.Clear(Color.Black);
            PointF A = new PointF(110, 10);
            PointF B = new PointF(210, 30);
            PointF C = new PointF(230, 310);
            PointF D = new PointF(110, 330);
            PointF E = new PointF(120, 160);
            PointF F = new PointF(10, 180);
            PointF G = new PointF(30, 110);
            PointF H = new PointF(120, 90);
            LineSegment[] lineSegArr = {
            new LineSegment(A, B),
            new LineSegment(B, C),
            new LineSegment(D, C),
            new LineSegment(D, E),
            new LineSegment(F, E),
            new LineSegment(F, G),
            new LineSegment(G, H),
            new LineSegment(A, H)
            };
            PointF X = new PointF(float.Parse(textBox1.Text), float.Parse(textBox2.Text));
            g.DrawLines(pen, new Circle(X).drawCircle());
            LineSegment straight = new LineSegment(X, new PointF(pictureBox1.Width, pictureBox1.Height));           
            PointF[] polygon = {
                A,
                B,              
                C,
                D,
                E,
                F,
                G,
                H,
                A
                    };
            g.DrawLines(pen, polygon);
            int i = 0;
            foreach(LineSegment seg in lineSegArr)
            {
                if (seg.isSegmentCrosses(straight)) {
                    i++;
                }
            }
            String message;
            if (i % 2 == 0) { message = "Punkt nie należy do wielokąta"; }
            else { message = "Punkt należy do wielokąta"; }
            showMessage(message);
        }
    }
    public class Circle
    {
        private PointF S;
        private float r = 3;
        private float angle = 0;
        private int n = 50;
        private float add_angle;
        public Circle(PointF S)
        {
            this.S = S;
            add_angle = (float)(2 * Math.PI) / n;
        }
        public PointF[] drawCircle()
        {
            PointF[] points = new PointF[n];
            for (int i = 0; i < n; i++)
            {
                float x = (float)(r * Math.Cos(angle) + S.X);
                float y = (float)(r * Math.Sin(angle) + S.Y);
                points[i] = new PointF(x, y);
                angle += add_angle;
            }
            return points;
        }
    }
    public class LineSegment
    {
        private PointF A;
        private PointF B;

        public PointF getA() { return A; }
        public PointF getB() { return B; }

        public LineSegment(PointF A, PointF B)
        {
            this.A = A;
            this.B = B;
        }
        public float calculateARatio()
        {
            return (A.Y-B.Y) / (A.X-B.X);
        }
        public float calculateBRatio()
        {
            return (A.Y-((A.Y-B.Y) / (A.X-B.X))*A.X);
        }
        public float calculateValue(float x)
        {
            return x * calculateARatio() + calculateBRatio();
        }
        public bool isTwoPointsOnSameWay(PointF A, PointF B)
        {
            float yA = calculateValue(A.X);
            float yB = calculateValue(B.X);
            if(yA>A.Y && yB < B.Y) { return false; }
            else { return true; }
        }
        public bool isOnSegment(PointF A)
        {
            if(A.X >= this.A.X && A.X <= B.X)
            {
                if (calculateValue(A.X) == A.Y) { return true; }
            }
            return false;
        }
        public bool isSegmentCrosses(LineSegment lineSegment)
        {
            float x = (lineSegment.calculateBRatio() - calculateBRatio()) / (calculateARatio() - lineSegment.calculateARatio());
            PointF crossA = new PointF(x, calculateValue(x));
            PointF crossB = new PointF(x, lineSegment.calculateValue(x));
            if (isOnSegment(crossA) && lineSegment.isOnSegment(crossB)) { return true; }
            else { return false; }
        }
    }
}