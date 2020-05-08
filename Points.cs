using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArraysOfObjectsNet
{
    class Points
    {
        Point[] points;
        int lastPointNumber;

        public Point GetPointAt(int i) { return points[i]; }

        public Points()
        {
            points = new Point[0];
            lastPointNumber = -1;
        }

        public Points(int N)
        {
            points = new Point[N];
            lastPointNumber = -1;
        }

        public void init()
        {
            Random r = new Random();
            for (int i = 0; i < points.Length; i++)
            {
                points[i] = new Point(r.Next(0, 10), r.Next(0, 10));
              }
        }
        public int getPointsNumber()
        {
            return points.Length;
        }

        public bool addPoint(Point point)
        {
            if (lastPointNumber + 1 < points.Length)
            {
                points[++lastPointNumber] = point;
                return true;
            }
            else
                resize(points.Length + 1);

            return false;
        }

        private void resize(int n)
        {
            /*
            Point[] newArray = new Point[n];

            for (int i = 0; i < points.Length; i++)
            {
                newArray[i] = points[i];
            }

            points = newArray;
            */

            Array.Resize(ref points, points.Length + 1);
        }
        public override string ToString()
        {
            String result = "";

            for (int i = 0; i < points.Length; i++)
            {
                result += points[i].ToString() + Environment.NewLine;
            }
            return result;
        }

        public int findNearestToZero()
        {
            int k = 0;
            double distance = Math.Sqrt(GetPointAt(0).X + GetPointAt(0).Y);

            for (int i = 0; i < getPointsNumber(); i++)
            {
                if (Math.Sqrt(GetPointAt(i).X + GetPointAt(i).Y) < distance)
                {
                    distance = Math.Sqrt(GetPointAt(i).X + GetPointAt(i).Y);
                    k = i;
                }
            }

            return k;
        }
    }
}