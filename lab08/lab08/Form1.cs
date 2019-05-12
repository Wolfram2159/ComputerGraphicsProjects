using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab08
{
    public partial class Form1 : Form
    {
        private System.Drawing.Graphics g;
        private System.Drawing.Pen pen = new System.Drawing.Pen(Color.Red, 1);
        public Form1()
        {
            InitializeComponent();
            g = pictureBox1.CreateGraphics();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            g.Clear(Color.White);
            
            Point[] points = new Point[7];
            points[0] = new Point(100, 400);
            points[1] = new Point(300, 400);
            points[2] = new Point(200, 200);
            points[3] = new Point(300, 200);
            points[4] = new Point(400, 100);
            points[5] = new Point(100, 100);
            points[6] = new Point(400, 400);
            foreach (Point point in points)
            {
                Circle c = new Circle(point);
                g.DrawLines(pen, c.drawCircle());
            }
            int n = points.Length;
            JarvisScan js = new JarvisScan();
            Point[] newPoints = js.convexHull(points, n);
            g.DrawLines(pen, newPoints);
            g.DrawLine(pen, newPoints[0], newPoints[newPoints.Length - 1]);
        }      

        private void button2_Click(object sender, EventArgs e)
        {
            g.Clear(Color.White);

            GrahamScan gh = new GrahamScan();
            List<Point> lista = new List<Point>();
            lista.Add(new Point(0, 300));
            lista.Add(new Point(100, 100));
            lista.Add(new Point(200, 200));
            lista.Add(new Point(400, 400));
            lista.Add(new Point(0, 0));
            lista.Add(new Point(100, 200));
            lista.Add(new Point(300, 100));
            lista.Add(new Point(300, 300));
            foreach(Point point in lista)
            {
                Circle c = new Circle(point);
                g.DrawLines(pen, c.drawCircle());
            }
            Point[] newPoints = gh.convexHull(lista);
            g.DrawLines(pen, newPoints);
            g.DrawLine(pen, newPoints[0], newPoints[newPoints.Length - 1]);
        }
}
}
public class Circle
{
    private Point S;
    private float r = 4;
    private float angle = 0;
    private int n = 50;
    private float add_angle;
    public Circle(Point S)
    {
        this.S = S;
        add_angle = (float)(2 * Math.PI) / n;
    }
    public Point[] drawCircle()
    {
        Point[] points = new Point[n];
        for (int i = 0; i < n; i++)
        {
            int x = (int)(r * Math.Cos(angle) + S.X);
            int y = (int)(r * Math.Sin(angle) + S.Y);
            points[i] = new Point(x, y);
            angle += add_angle;
        }
        return points;
    }
}
public class JarvisScan
{
    public int orientation(Point p, Point q, Point r)
    {
        int val = (q.Y - p.Y) * (r.X - q.X) -
                  (q.X - p.X) * (r.Y - q.Y);

        if (val == 0) return 0;  // collinear 
        return (val > 0) ? 1 : 2; // clock or counterclock wise 
    }

    // Prints convex hull of a set of n points. 
    public Point[] convexHull(Point[] points, int n)
    {
        // There must be at least 3 points 
        if (n < 3) return null;

        // Initialize Result           
        List<Point> hull = new List<Point>();
        // Vector<Point> hull = new Vector<Point>();

        // Find the leftmost point 
        int l = 0;
        for (int i = 1; i < n; i++)
            if (points[i].X < points[l].X)
                l = i;

        // Start from leftmost point, keep moving  
        // counterclockwise until reach the start point 
        // again. This loop runs O(h) times where h is 
        // number of points in result or output. 
        int p = l, q;
        do
        {
            // Add current point to result 
            hull.Add(points[p]);

            // Search for a point 'q' such that  
            // orientation(p, x, q) is counterclockwise  
            // for all points 'x'. The idea is to keep  
            // track of last visited most counterclock- 
            // wise point in q. If any point 'i' is more  
            // counterclock-wise than q, then update q. 
            q = (p + 1) % n;

            for (int i = 0; i < n; i++)
            {
                // If i is more counterclockwise than  
                // current q, then update q 
                if (orientation(points[p], points[i], points[q])
                                                    == 2)
                    q = i;
            }

            // Now q is the most counterclockwise with 
            // respect to p. Set p as q for next iteration,  
            // so that q is added to result 'hull' 
            p = q;

        } while (p != l);  // While we don't come to first  
                           // point 

        // Print Result 
        //foreach (Point temp in hull)
        //    MessageBox.Show($"({temp.X},{temp.Y})");
        return hull.ToArray();
    }
}
public class GrahamScan
{
    public int turn(Point p, Point q, Point r)
    {
        return ((q.X - p.X) * (r.Y - p.Y) - (r.X - p.X) * (q.Y - p.Y)).CompareTo(0);
    }

    public void keepLeft(List<Point> hull, Point r)
    {
        while (hull.Count > 1 && turn(hull[hull.Count - 2], hull[hull.Count - 1], r) != 1)
        {
            hull.RemoveAt(hull.Count - 1);
        }
        if (hull.Count == 0 || hull[hull.Count - 1] != r)
        {
            hull.Add(r);
        }
    }

    public double getAngle(Point p1, Point p2)
    {
        float xDiff = p2.X - p1.X;
        float yDiff = p2.Y - p1.Y;
        return Math.Atan2(yDiff, xDiff) * 180.0 / Math.PI;
    }

    public List<Point> MergeSort(Point p0, List<Point> arrPoint)
    {
        if (arrPoint.Count == 1)
        {
            return arrPoint;
        }
        List<Point> arrSortedInt = new List<Point>();
        int middle = (int)arrPoint.Count / 2;
        List<Point> leftArray = arrPoint.GetRange(0, middle);
        List<Point> rightArray = arrPoint.GetRange(middle, arrPoint.Count - middle);
        leftArray = MergeSort(p0, leftArray);
        rightArray = MergeSort(p0, rightArray);
        int leftptr = 0;
        int rightptr = 0;
        for (int i = 0; i < leftArray.Count + rightArray.Count; i++)
        {
            if (leftptr == leftArray.Count)
            {
                arrSortedInt.Add(rightArray[rightptr]);
                rightptr++;
            }
            else if (rightptr == rightArray.Count)
            {
                arrSortedInt.Add(leftArray[leftptr]);
                leftptr++;
            }
            else if (getAngle(p0, leftArray[leftptr]) < getAngle(p0, rightArray[rightptr]))
            {
                arrSortedInt.Add(leftArray[leftptr]);
                leftptr++;
            }
            else
            {
                arrSortedInt.Add(rightArray[rightptr]);
                rightptr++;
            }
        }
        return arrSortedInt;
    }

    public Point[] convexHull(List<Point> points)
    {
        Point p0 = new Point(0, 0);
        Boolean first = true;
        foreach (Point value in points)
        {
            if (first){
                p0 = value;
                first = false;
            }
            else
            {
                if (p0.Y > value.Y)
                    p0 = value;
            }
        }
        List<Point> order = new List<Point>();
        foreach (Point value in points)
        {
            if (p0 != value)
                order.Add(value);
        }

        order = MergeSort(p0, order);

        List<Point> result = new List<Point>();
        result.Add(p0);
        result.Add(order[0]);
        result.Add(order[1]);
        order.RemoveAt(0);
        order.RemoveAt(0);

        foreach (Point value in order)
        {
            keepLeft(result, value);
        }
        return result.ToArray();
    }
}