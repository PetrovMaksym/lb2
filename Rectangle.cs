using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShuviNaiTblEblan
{
    class Rectangle : Quad
    {
        /// <summary>
        /// Конструктор класса вызывает базовый конструктор
        /// </summary>
        /// <param name="p1">вершина 1 четырехугольника</param>
        /// <param name="p2">вершина 2 четырехугольника</param>
        /// <param name="p3">вершина 3 четырехугольника</param>
        /// <param name="p4">вершина 4 четырехугольника</param>
        public Rectangle(Point p1, Point p2, Point p3, Point p4) : base(p1, p2, p3, p4)
        {

        }
        /// <summary>
        /// Проверяет является ли фигура построенная по четырем точукам прямоугольником.
        /// </summary>
        /// <returns></returns>
        public bool IsRectangle()
        {
            bool result;
            if (!this.IsQuad())
            {
                Console.WriteLine("Это даже не четырехугольник!!!");
                result = false;
            }
            else if (this.Diagonal(1) != this.Diagonal(2))
                result = false;
            else if (this.Side(1) != this.Side(3))
                result = false;
            else if (this.Side(2) != this.Side(4))
                result = false;
            else
                result = true;
            return result;
        }
    }
}
