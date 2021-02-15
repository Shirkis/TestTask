using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTask
{
    public class Сalculation
    {

        FileWork _fileWork;
        public Сalculation()
        {
            _fileWork = new FileWork();
        }
        public static double eps = 5;
        public Point start;
        public Bitmap bmp, bmp2, bmp3;
        public Image orig;
        public List<PointF> coordsim = new List<PointF>();

        public Bitmap Main()
        {
            int i = 0;
            var text = _fileWork.ReadFile();
            var firstString = text.FirstOrDefault().Split(",");
            var d1 = new Distance
            {
                X = double.Parse(firstString[0], CultureInfo.InvariantCulture),
                Y = double.Parse(firstString[1], CultureInfo.InvariantCulture)
            };
            var d2 = new Distance
            {
                X = double.Parse(firstString[2], CultureInfo.InvariantCulture),
                Y = double.Parse(firstString[3], CultureInfo.InvariantCulture)
            };
            var d3 = new Distance
            {
                X = double.Parse(firstString[4], CultureInfo.InvariantCulture),
                Y = double.Parse(firstString[5], CultureInfo.InvariantCulture)
            };
            text.RemoveAt(0);
            bmp = new Bitmap(700, 500);
            bmp2 = new Bitmap(700, 500);
            bmp3 = new Bitmap(700, 500);
            Graphics graph = Graphics.FromImage(bmp);
            Pen pen = new Pen(Color.Black);
            Pen pen2 = new Pen(Color.Blue);
            pen2.Width = (float)2;
            graph.TranslateTransform(700 / 2, 500 / 2);
            PointF bpoint = new PointF();
            foreach (var signals in text)
            {
                var signalArr = signals.Split(",");
                d1.R = double.Parse(signalArr[0], CultureInfo.InvariantCulture);
                d2.R = double.Parse(signalArr[1], CultureInfo.InvariantCulture);
                d3.R = double.Parse(signalArr[2], CultureInfo.InvariantCulture);
                var point = Draw(d1, d2, d3, graph, pen);
                if (i == 0)
                {
                    string pointT = point.X.ToString() + " " + point.Y.ToString();
                    _fileWork.WriteFile(pointT, false, false);
                }
                else
                {
                    string pointT = point.X.ToString() + " " + point.Y.ToString();
                    _fileWork.WriteFile(pointT, true, false);
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
            return bmp;
        }

        //public List<string> ReadFile()
        //{
        //    try
        //    {
        //        string path = @"..\..\..\..\input.txt";

        //        List<string> res = new List<string>();
        //        using (StreamReader sr = new StreamReader(path, System.Text.Encoding.Default))
        //        {
        //            string line;
        //            while ((line = sr.ReadLine()) != null)
        //            {
        //                res.Add(line);
        //            }
        //        }
        //        return res;
        //    }
        //    catch(Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        //async public Task WriteFile(string poinT, bool IsNew, bool IsSimul)
        //{
        //    try
        //    {
        //        string writePath;
        //        if (IsSimul)
        //        {
        //            writePath = @"..\..\..\..\output_sim.txt";
        //        }
        //        else
        //        {
        //            writePath = @"..\..\..\..\output.txt";
        //        }
        //        using (StreamWriter sw = new StreamWriter(writePath, IsNew, System.Text.Encoding.Default))
        //        {
        //            await sw.WriteLineAsync(poinT);
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine(e.Message);
        //    }
        //}

        private PointF Draw(Distance d1, Distance d2, Distance d3, Graphics graph, Pen pen)
        {
            var peresek = calculateThreeCircleIntersection(d1.X, d1.Y, (d1.R * 1000000), d2.X, d2.Y, (d2.R * 1000000), d3.X, d3.Y, (d3.R * 1000000));
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
            if (d > ((r0 + r1) * 1.05))
            {
                /* no solution. circles do not intersect. */
                throw new Exception("false");
            }
            if (d < Math.Abs(r0 - r1) * 0.95)
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
                PointF res = new PointF
                {
                    X = (float)intersectionPoint1_x,
                    Y = (float)intersectionPoint1_y
                };
                return res;
            }
            else if (Math.Abs(d2 - r2) < eps)
            {
                PointF res = new PointF
                {
                    X = (float)intersectionPoint2_x,
                    Y = (float)intersectionPoint2_y
                };
                return res;
            }
            else
            {
                PointF res = new PointF();
                return res;
            }
        }

    }
}
