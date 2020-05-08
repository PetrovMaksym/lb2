using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArraysOfObjectsNet
{
    class Point
    {
        String name;
        int x;
        int y;
        public int X { get => x; set => x = (value >= 0 ? value : 0); }
        public int Y { get => y; set => y = (value >= 0 ? value : 0); }
        public string Name { get => name; set => name = value; }

        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        public Point(String name, int x, int y) : this(x, y)
        {
            this.name = name;
        }
        public Point() : this(0, 0)
        {
        }

        public override string ToString()
        {
            return this.name + " (" + this.x + ", " + this.y + ")";
        }
    }
}
