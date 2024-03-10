using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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
        private bool isDragging = false;
        private PointF draggedPoint;
        int?  correctMode;
         public int choosedCorrectPoint;
         
         
         
         public List<double> recorderPointsWithStepT = new List<double>();
         public List<PointF> recorderPointsWithStepDots = new List<PointF>();
         public double step;
         public float start;
         public float end;
         
         public int findPointBool;
        public Form1()
        {
            InitializeComponent();
            InitializeGrid();
            InitializeGraphics();
            InitializePoints();
            panel1.MouseClick += Panel1_MouseClick;
            
        }
        
       
        private void Panel1_MouseClick(object sender, MouseEventArgs e)
        {
            Point clickLocation = e.Location;
            
            // Check if the mouse click is near any existing point
            for (int i = 0; i < points.Count; i++)
            {
                PointF point = points[i];
                float distance = (float)Math.Sqrt(Math.Pow(e.X - point.X, 2) + Math.Pow(e.Y - point.Y, 2));
                if (distance <= 5) // Adjust the radius as needed
                {
                    if (correctMode == 0)
                    {
                        // Remove the point from the list
                        points.RemoveAt(i); //version 1
                        // Redraw the panel
                        panel1.Invalidate(); //version 1
                    }

                    if (correctMode == 1)
                    {
                        textBox1.Text = ((points[i].X - 225) / 25).ToString();
                        textBox2.Text = ((points[i].Y - 225) / 25).ToString();
                        choosedCorrectPoint = i;
                    }

                    

                    // Exit the method since we found and removed the point
                    return;
                }
            }
            
            // Add the click location to the list of control points
            points.Add(clickLocation);

            // Redraw the panel
            panel1.Invalidate();
            
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
            
            recorderPointsWithStepT.Clear();
            recorderPointsWithStepDots.Clear();
            
            
            if (points.Count == 0)
            {
                return;
            }
            
            Graphics g = panel1.CreateGraphics();
            int n = controlPoints.Count;
            PointF previousPoint = new PointF(225, 225);
            double previousPointForStep = 0;

            double[,] matrix = BezierMatrix(controlPoints);

            for (double t = 0; t <= 1; t += 0.001)
            {
                List<double> T = new List<double>();
                for (int k = n - 1; k >= 0; k--)
                {
                    T.Add(Math.Pow(t, k));
                }

                PointF p = new PointF(0, 0);
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
                if (t == 0)
                {
                    using (Pen pen = new Pen(Color.Red))
                    {
                        g.DrawLine(pen, controlPoints[0], p);
                    }
                }
                else
                {
                    using (Pen pen = new Pen(Color.Red))
                    {
                        g.DrawLine(pen, p, previousPoint);
                    }
                }

                previousPoint = p;
                
                if (findPointBool == 1 && Math.Abs(t - end) > 0.0005)
                {
                    if (t == start)
                    {
                        recorderPointsWithStepT.Add(t);
                        
                        PointF final = new PointF((p.X - 225) / 25 , ((p.Y - 225) / 25) * -1);
                        
                        recorderPointsWithStepDots.Add(final);
                    }
                    else if (Math.Abs(t - (recorderPointsWithStepT[recorderPointsWithStepT.Count - 1] + step)) < 0.0005)
                    {
                        recorderPointsWithStepT.Add(t);
                        
                        DrawCircle(g, p);
                        PointF final = new PointF((p.X - 225) / 25 , ((p.Y - 225) / 25)  * -1);
                        
                        recorderPointsWithStepDots.Add(final);
                    }
                }
            }
           
            string filePath = "D:\\term4\\CG\\cg_lab2_0002\\cg_lab2_0002\\matrix.txt";

            SaveMatrixToFile(matrix, filePath);
            findPointBool = 0;
            
        }

        public static void SaveMatrixToFile(double[,] matrix, string filePath)
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                int rows = matrix.GetLength(0);
                int cols = matrix.GetLength(1);

                int valueWidth = 8; // Adjust as needed

                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < cols; j++)
                    {
                        string formattedValue = matrix[i, j].ToString("F2").PadLeft(valueWidth);

                        writer.Write(formattedValue);

                        if (j < cols - 1)
                        {
                            writer.Write("\t");
                        }
                    }

                    writer.WriteLine();
                }
            }
        }


      
        private void DrawCircle(Graphics g, PointF point)
        {
            // Calculate the rectangle to draw the circle
            float circleRadius = 3;
            RectangleF circleRect = new RectangleF(point.X - circleRadius, point.Y - circleRadius, 2 * circleRadius, 2 * circleRadius);

            // Draw the circle
            g.FillEllipse(Brushes.Blue, circleRect);
        }
        
        private void DrawLines(Graphics g, PointF points, PointF pointSecond)
        {
            if (points == null || pointSecond == null){ return; }
            
                
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
            Graphics c = panel1.CreateGraphics();
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
            
            drawLines(points);
            BazierCurveMatrix(points);
            
            // Draw points as filled ellipses
            foreach (PointF point in points)
            {
                e.Graphics.FillEllipse(Brushes.Black, point.X - 5, point.Y - 5, 10, 10);
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
            panel1.Invalidate();
            points.Clear();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label3.Hide();
            label6.Hide();
        }

        private void panen(object sender, MouseEventArgs e)
        {
        }

        private void panel1_Paint_1(object sender, PaintEventArgs e)
        {
            
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (correctMode == 0)
            {
                correctMode = 2;
                label6.Hide();
            }
            else
            {
                correctMode = 0;
                label6.Show();
                label3.Hide();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            
            if (correctMode == 1)
            {
                correctMode = 2;
                label3.Hide();
            }
            else
            {
                correctMode = 1;
                label3.Show();
                label6.Hide();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            PointF point = points[choosedCorrectPoint];
            float xPoint = Convert.ToSingle(textBox1.Text);
            float yPoint = Convert.ToSingle(textBox2.Text);

            point.X = xPoint * gridSize + 225;
            point.Y = 225 - yPoint * gridSize ;
            points[choosedCorrectPoint] = point;
            
            panel1.Invalidate(); //version 1
        }


        private void button4_Click(object sender, EventArgs e)
        {
            
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            findPointBool = 1;
            if (string.IsNullOrWhiteSpace(textBox5.Text) || string.IsNullOrWhiteSpace(textBox4.Text) || string.IsNullOrWhiteSpace(textBox3.Text))
            {
                MessageBox.Show("Please enter values in all text boxes.", "Missing Values", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; 
            }
            panel1.Invalidate();
            
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (float.TryParse(textBox3.Text, out float result))
            {
                start = result;
            }
            else
            {
                // Handle invalid input, such as displaying an error message
                MessageBox.Show("Invalid input. Please enter a valid number.");
                // You may also choose to reset the value to a default or previous value
                // start = DefaultValue; // Adjust DefaultValue as needed
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            if (float.TryParse(textBox4.Text, out float result))
            {
                end = result;
            }
            else
            {
                MessageBox.Show("Invalid input. Please enter a valid number.");
                // Optionally handle the error by resetting to a default or previous value
                // end = DefaultValue; // Adjust DefaultValue as needed
            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            if (float.TryParse(textBox5.Text, out float result))
            {
                step = result;
            }
            else
            {
                MessageBox.Show("Invalid input. Please enter a valid number.");
                // Optionally handle the error by resetting to a default or previous value
                // step = DefaultValue; // Adjust DefaultValue as needed
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            // Create a StringBuilder to construct the message
            
           
            
            
            StringBuilder messageBuilder = new StringBuilder();

            // Iterate through the list of points
            foreach (PointF point in recorderPointsWithStepDots)
            {
                // Append the coordinates of each point to the message
                messageBuilder.AppendLine($"X: {point.X}, Y: {point.Y}");
            }

            // Display the message box with the points
            MessageBox.Show(messageBuilder.ToString(), "Points Information");
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }
    }
}
