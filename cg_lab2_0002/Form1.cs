using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cg_lab2_0002
{
    public partial class Form1 : Form
    {
        private Graphics graphics;
        private List<PointF> points = new List<PointF>();
        private int centerX;
        private int centerY;
        private const int gridSize = 25;
        public int panelWidth = 250;
        public int panelHeight = 250;
        private PointF startPoint;
        public Form1()
        {
            InitializeComponent();
            InitializeGrid();
            InitializeGraphics();
            InitializePoints();
        }
        private void InitializeGrid()
        {
            // Встановлюємо розміри панелі
            panel1.Size = new Size(450, 450);
            // Додавання обробника події Paint для малювання сітки
            panel1.Paint += Panel1_Paint;
           
           
            panelWidth = panel1.Width;
            panelHeight = panel1.Height;
            startPoint = new PointF(panelWidth / 2, panelHeight / 2);

        }
        
        private void InitializePoints()
        {
            PointF p0 = new PointF(-5, -5);
            PointF p1 = new PointF(5, -5);
            PointF p2 = new PointF(2, 3);
            PointF p3 = new PointF(4, 3);
            PointF p4 = new PointF(5, 3);
            

            points.Add(p0);
            points.Add(p1);
            points.Add(p2);
            points.Add(p3);
            points.Add(p4);
            
            for (int i = 0; i < points.Count; i++)
            {
                points[i] = ToggleCoord(points[i]);
            }
        }

        private void InitializeGraphics()
        {
            graphics = panel1.CreateGraphics();
            centerX = panel1.Width / 2;
            centerY = panel1.Height / 2;
        }

        private PointF ToggleCoord(PointF point)
        {
            // Create a new PointF with modified coordinates and return it
            return new PointF(centerX + point.X * gridSize, centerY - point.Y * gridSize);
        }


        public static double Factorial(int n)
        {
            if (n < 0) return -1;
            if (n == 0) return 1;
            else return n * Factorial(n - 1);
        }

        public static double NCi(int n, int i)
        {
            return Factorial(n) / (Factorial(i) * Factorial(n - i));
        }
        
        
        
        static public double[,] BezierMatrix(List<PointF> controlPoint)
        {
            int n = controlPoint.Count;
            
            double[,] M = new double[n, n];

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (i <= j)
                    {
                        M[i, j] = Math.Pow(-1, j - i) * NCi(n - 1, i) * NCi(n - i - 1, j - i);
                    }
                    else
                    {
                        M[i, j] = 0;
                    }
                }
            }

            double[,] newMatrix = new double[n, n];

            newMatrix = ReverseMatrixRows(M);
            
            return newMatrix;
        }
        
        static public double[,] ReverseMatrixRows(double[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            double[,] reversedMatrix = new double[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    reversedMatrix[i, j] = matrix[i, cols - j - 1];
                }
            }

            return reversedMatrix;
        }
        public void BazierCurveMatrix(List<PointF> controlPoints)
        {
            Graphics g = panel1.CreateGraphics();
            int n = controlPoints.Count;

            double[,] matrix = BezierMatrix(controlPoints);

            for (double t = 0; t <= 1; t += 0.001)
            {
                List<double> T = new List<double>();
                for (int k = n - 1; k >= 0; k--)
                {
                    T.Add(Math.Pow(t, k));
                }

                PointF p = new Point(0, 0);
                for (int i = 0; i < T.Count; i++)
                {
                    double factor = 0;
                    for (int j = 0; j < n; j++)
                    {
                        factor += T[j] * matrix[i, j];
                    }
            
                    p.X += (float)(controlPoints[i].X * factor);
                    p.Y += (float)(controlPoints[i].Y * factor);
                }

                // Use the calculated point p to draw the Bezier curve
                g.FillRectangle(Brushes.Orange, p.X, p.Y, 1, 1); // Example drawing, adjust as needed
            }
        }

        private void DrawCircle(Graphics g, PointF point)
        {
            // Calculate the rectangle to draw the circle
            float circleRadius = 2;
            RectangleF circleRect = new RectangleF(point.X - circleRadius, point.Y - circleRadius, 2 * circleRadius, 2 * circleRadius);

            // Draw the circle
            g.FillEllipse(Brushes.Red, circleRect);
        }
        
        private void DrawLines(Graphics g, PointF points, PointF pointSecond)
        {
            if (points == null || pointSecond == null){
                return;
            }
                g.DrawLine(Pens.Black, points, pointSecond);
        }
        
        public void drawLines(List<PointF> controlPoints)
        {
            Graphics g = panel1.CreateGraphics();

            for (int i = 0; i < controlPoints.Count; i++)
            {
                DrawCircle(g, controlPoints[i]);
                if (i == controlPoints.Count - 1)
                {
                    return;
                }
                else
                    DrawDashedLine(g, controlPoints[i], controlPoints[i + 1]);
            }
            
            
        }
        
        private void DrawDashedLine(Graphics g, PointF startPoint, PointF endPoint)
        {
            Pen dashedPen = new Pen(Color.Black);
            dashedPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;

            dashedPen.DashPattern = new float[] { 10, 5 }; 
            
            g.DrawLine(dashedPen, startPoint, endPoint);
        }

      

        private void Panel1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            for (int x = 0; x <= panelWidth; x += gridSize)
            {
                if (panelWidth / 2 == x)
                    g.DrawLine(Pens.Black, x, 0, x, panelHeight);
                else
                    g.DrawLine(Pens.Gainsboro, x, 0, x, panelHeight);

                if (x % 25 == 0)
                {
                    string label = ((x - panelWidth / 2) / gridSize).ToString();
                    g.DrawString(label, DefaultFont, Brushes.Black, new PointF(x, panelHeight / 2));
                }
            }

            for (int y = 0; y <= panelHeight; y += gridSize)
            {
                // Draw horizontal lines
                if (panelHeight / 2 == y)
                    g.DrawLine(Pens.Black, 0, y, panelWidth, y);
                else
                    g.DrawLine(Pens.Gainsboro, 0, y, panelWidth, y);

                // Draw y-axis labels
                if (y % 25 == 0)
                {
                    string label = ((panelHeight / 2 - y) / gridSize).ToString();
                    g.DrawString(label, DefaultFont, Brushes.Black, new PointF(panelWidth / 2, y));
                }
            }
        }

       

        private void btnBezierMatrix_Click(object sender, EventArgs e)
        {
        }

        private void buttobtnBezierCurven1_Click(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            drawLines(points);
            BazierCurveMatrix(points);
           
        }

        private void buttobtnBezierCurven1_Click_1(object sender, EventArgs e)
        {
        }
    }
}
