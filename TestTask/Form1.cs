using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestTask
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Main();
        }

        private static double eps = 5;
        private Point start;
        Bitmap bmp, bmp2, bmp3;
        private Image orig;
        private List<PointF> coordsim = new List<PointF>();
        async public void Main()
        {
            int i = 0;
            float f1, f2, f3;
            var text = await ReadFile();
            var firstString = text.FirstOrDefault().Split(",");
            double x1 = double.Parse(firstString[0], CultureInfo.InvariantCulture);
            double y1 = double.Parse(firstString[1], CultureInfo.InvariantCulture);
            double x2 = double.Parse(firstString[2], CultureInfo.InvariantCulture);
            double y2 = double.Parse(firstString[3], CultureInfo.InvariantCulture);
            double x3 = double.Parse(firstString[4], CultureInfo.InvariantCulture);
            double y3 = double.Parse(firstString[5], CultureInfo.InvariantCulture);
            text.RemoveAt(0);
            bmp = new Bitmap(pictureBox.Width, pictureBox.Height);
            bmp2 = new Bitmap(pictureBox.Width, pictureBox.Height);
            bmp3 = new Bitmap(pictureBox.Width, pictureBox.Height);
            Graphics graph = Graphics.FromImage(bmp);
            Pen pen = new Pen(Color.Black);
            Pen pen2 = new Pen(Color.Blue);
            pen2.Width = (float)2;
            graph.TranslateTransform(pictureBox.Width / 2, pictureBox.Height / 2);
            //graph.ScaleTransform(5, 5);
            PointF bpoint = new PointF();
            foreach (var signals in text)
            {
                var signalArr = signals.Split(",");
                f1 = float.Parse(signalArr[0], CultureInfo.InvariantCulture);
                f2 = float.Parse(signalArr[1], CultureInfo.InvariantCulture);
                f3 = float.Parse(signalArr[2], CultureInfo.InvariantCulture);
                var point = Draw(x1, y1, x2, y2, x3, y3, f1, f2, f3, graph ,pen);
                if (i == 0)
                {
                    string pointT = point.X.ToString() + " " + point.Y.ToString();
                    await WriteFile(pointT, false, false);
                }
                else
                {
                    string pointT = point.X.ToString() + " " + point.Y.ToString();
                    await WriteFile(pointT, true, false);
                }
                if (i != 0 && i != text.Count())
                {
                    graph.DrawLine(pen2, point, bpoint);
                    bpoint = point;
                    i++;
                }
                else if (i == 0)
                {
                    bpoint = point;
                    i++;
                }
            }
            pictureBox.Image = bmp;
        }

        async public Task<List<string>> ReadFile()
        {
            string path = @"..\..\..\..\input.txt";

            List<string> res = new List<string>();
            // асинхронное чтение
            using (StreamReader sr = new StreamReader(path, System.Text.Encoding.Default))
            {
                string line;
                while ((line = await sr.ReadLineAsync()) != null)
                {
                    res.Add(line);
                }
            }
            return res;
        }

        static async Task WriteFile(string poinT, bool IsNew, bool IsSimul)
        {
            try
            {
                string writePath;
                if (IsSimul)
                {
                    writePath = @"..\..\..\..\output_sim.txt";
                }
                else
                {
                    writePath = @"..\..\..\..\output.txt";
                }
                using (StreamWriter sw = new StreamWriter(writePath, IsNew, System.Text.Encoding.Default))
                {
                    await sw.WriteLineAsync(poinT);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private PointF Draw(double x1, double y1, double x2, double y2, double x3, double y3, float f1, float f2, float f3, Graphics graph, Pen pen)
        {
            var peresek = calculateThreeCircleIntersection(x1, y1, ((float)(f1 * 1000000)), x2, y2, ((float)(f2 * 1000000)), x3, y3, ((float)(f3 * 1000000)));
            graph.DrawEllipse(pen, peresek.X, peresek.Y, (float)4, (float)4);
            return peresek;
        }

        private PointF calculateThreeCircleIntersection(double x0, double y0, double r0, double x1, double y1, double r1, double x2, double y2, double r2)
        {
            double a, dx, dy, d, h, rx, ry;
            double point2_x, point2_y;

        /* dx and dy are the vertical and horizontal distances between
        * the circle centers.
        */
            dx = x1 - x0;
            dy = y1 - y0;

            /* Determine the straight-line distance between the centers. */
            d = Math.Sqrt((dy * dy) + (dx * dx));

            /* Check for solvability. */
            if (d > ((r0 + r1)* 1.05))
            {
                /* no solution. circles do not intersect. */
                throw new Exception("false");
            }
            if (d < Math.Abs(r0 - r1)*0.95)
            {
                /* no solution. one circle is contained in the other */
                throw new Exception("false");
            }

            /* 'point 2' is the point where the line through the circle
            * intersection points crosses the line between the circle
            * centers.
            */

            /* Determine the distance from point 0 to point 2. */
            a = ((r0 * r0) - (r1 * r1) + (d * d)) / (2.0 * d);

            /* Determine the coordinates of point 2. */
            point2_x = x0 + (dx * a / d);
            point2_y = y0 + (dy * a / d);

            /* Determine the distance from point 2 to either of the
            * intersection points.
            */
            if (r0 > a)
            {
                h = Math.Sqrt((r0 * r0) - (a * a));
            }
            else
            {
                h = Math.Sqrt((r0 * r0 * 1.05) - (a * a));
            }

            /* Now determine the offsets of the intersection points from
            * point 2.
            */
            rx = -dy * (h / d);
            ry = dx * (h / d);

            /* Determine the absolute intersection points. */
            double intersectionPoint1_x = point2_x + rx;
            double intersectionPoint2_x = point2_x - rx;
            double intersectionPoint1_y = point2_y + ry;
            double intersectionPoint2_y = point2_y - ry;


            /* Lets determine if circle 3 intersects at either of the above intersection points. */
            dx = intersectionPoint1_x - x2;
            dy = intersectionPoint1_y - y2;
            double d1 = Math.Sqrt((dy * dy) + (dx * dx));

            dx = intersectionPoint2_x - x2;
            dy = intersectionPoint2_y - y2;
            double d2 = Math.Sqrt((dy * dy) + (dx * dx));

            if (Math.Abs(d1 - r2) < eps)
            {
                ErrLabel.Text = ("INTERSECTION Circle1 AND Circle2 AND Circle3:" + "(" + intersectionPoint1_x + "," + intersectionPoint1_y + ")");
                PointF res = new PointF
                {
                    X = (float)intersectionPoint1_x,
                    Y = (float)intersectionPoint1_y
                };
                return res;
            }
            else if (Math.Abs(d2 - r2) < eps)
            {
                ErrLabel.Text = ("INTERSECTION Circle1 AND Circle2 AND Circle3:" + "(" + intersectionPoint2_x + "," + intersectionPoint2_y + ")"); //here was an error
                PointF res = new PointF
                {
                    X = (float)intersectionPoint2_x,
                    Y = (float)intersectionPoint2_y
                };
                return res;
            }
            else
            {
                ErrLabel.Text = ("INTERSECTION Circle1 AND Circle2 AND Circle3:" + "NONE");
                PointF res = new PointF();
                return res;
            }
        }

        private bool drawing = false;
        int deltaX = 0;
        int deltaY = 0;

        Rectangle rect = new Rectangle(0, 0, 10, 10);

        private void pictureBox2_MouseUp(object sender, MouseEventArgs e)
        {
            var finish = new Point(e.X, e.Y);
            var g = Graphics.FromImage(bmp3);
            var pen = new Pen(Color.Black, 1f);
            g.DrawLine(pen, start, finish);
            g.Save();
            drawing = false;
            g.Dispose();
            pictureBox2.Invalidate();

            PointF xy = new PointF
            {
                X = rect.X - (pictureBox2.Width / 2),
                Y = rect.Y - (pictureBox2.Height / 2)
            };
            coordsim.Add(xy);
        }

        private void pictureBox2_MouseDown(object sender, MouseEventArgs e)
        {
            start = new Point(e.X, e.Y);
            orig = bmp3;
            if ((e.X < rect.X + rect.Width) && (e.X > rect.X))
                if ((e.Y < rect.Y + rect.Height) && (e.Y > rect.Y))
                {
                    drawing = true;
                    deltaX = e.X - rect.X;
                    deltaY = e.Y - rect.Y;
                }

            if (coordsim.Count == 0)
            {
                PointF xy = new PointF
                {
                    X = rect.X - (pictureBox2.Width / 2),
                    Y = rect.Y - (pictureBox2.Height / 2)
                };
                coordsim.Add(xy);
            }
        }
        bool first = true;
        private void pictureBox2_Paint(object sender, PaintEventArgs e)
        {
            Pen pen = new Pen(Color.Black);
            if (first)
            {
                rect.X = pictureBox2.Width / 2;
                rect.Y = pictureBox2.Height / 2;
                first = false;
            }
            e.Graphics.DrawRectangle(pen, rect);
        }

        private void pictureBox2_MouseMove(object sender, MouseEventArgs e)
        {
            if (!drawing) return;
            var finish = new Point(e.X, e.Y);
            bmp2 = new Bitmap(bmp3);
            pictureBox2.Image = bmp2;
            var pen = new Pen(Color.Black, 1f);
            var g = Graphics.FromImage(bmp2);
            g.DrawLine(pen, start, finish);
            g.Dispose();
            rect.X = e.X - deltaX;
            rect.Y = e.Y - deltaY;
            pictureBox2.Invalidate();
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            List<string> file = new List<string>();
            double x1 = double.Parse(f1X.Text, CultureInfo.InvariantCulture);
            double y1 = double.Parse(f1Y.Text, CultureInfo.InvariantCulture);
            double x2 = double.Parse(f2X.Text, CultureInfo.InvariantCulture);
            double y2 = double.Parse(f2Y.Text, CultureInfo.InvariantCulture);
            double x3 = double.Parse(f3X.Text, CultureInfo.InvariantCulture);
            double y3 = double.Parse(f3Y.Text, CultureInfo.InvariantCulture);
            file.Add(x1.ToString("0.00000000", System.Globalization.CultureInfo.InvariantCulture) + "," + y1.ToString("0.00000000", System.Globalization.CultureInfo.InvariantCulture) + "," + x2.ToString("0.00000000", System.Globalization.CultureInfo.InvariantCulture) + "," + y2.ToString("0.00000000", System.Globalization.CultureInfo.InvariantCulture) + "," + x3.ToString("0.00000000", System.Globalization.CultureInfo.InvariantCulture) + "," + y3.ToString("0.00000000", System.Globalization.CultureInfo.InvariantCulture));
            WriteFile(file.FirstOrDefault(), false, true);
            foreach (var point in coordsim)
            {
                float rasst1 = (float)(Math.Sqrt(Math.Pow(point.X - x1, 2) + Math.Pow(point.Y - y1, 2)) / 1000000);
                float rasst2 = (float)(Math.Sqrt(Math.Pow(point.X - x2, 2) + Math.Pow(point.Y - y2, 2)) / 1000000);
                float rasst3 = (float)(Math.Sqrt(Math.Pow(point.X - x3, 2) + Math.Pow(point.Y - y3, 2)) / 1000000);
                WriteFile((rasst1.ToString("0.00000000", System.Globalization.CultureInfo.InvariantCulture) + "," + rasst2.ToString("0.00000000", System.Globalization.CultureInfo.InvariantCulture) + "," + rasst3.ToString("0.00000000", System.Globalization.CultureInfo.InvariantCulture)), true, true);
            }
        }

    }
}
