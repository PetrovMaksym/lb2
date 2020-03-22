using System;

namespace ShuviNaiTblEblan
{
    class Point
    {
        private double x;
        private double y;

        public Point()
        {


        }


        public Point(double x, double y)
        {
            this.x = x;
            this.y = y;

        }
        /// <summary>
        /// Получение значение точки по оси X (или просто поле х класса Point)
        /// </summary>
        /// <returns></returns>
        public double GetX()
        {
            return x;

        }
        /// <summary>
        /// Получение значение точки по оси Y (или просто поле y класса Point)
        /// </summary>
        /// <returns></returns>
        public double GetY()
        {
            return y;

        }
        /// <summary>
        /// Инициализация (обновление) значения точки по оси X (или просто поле х класса Point)
        /// </summary>
        /// <returns></returns>
        public void SetX(double value)
        {
            x = value;

        }
        /// <summary>
        /// Инициализация (обновление) значения точки по оси Y (или просто поле y класса Point)
        /// </summary>
        /// <returns></returns>
        public void SetY(double value)
        {
            y = value;

        }

        /// <summary>
        /// Расчет расстояния между двумя точками (длинны отрезка).
        /// </summary>
        /// <param name="p">точка до которой строится отрезка</param>
        /// <returns></returns>
        public double Length(Point p)
        {
            return Math.Abs(Math.Sqrt(Math.Pow((p.GetX() - this.x), 2) + Math.Pow((p.GetY() - this.y), 2)));

        }

        /// <summary>
        /// Проверка на существование точек с одними и теми же координатами 
        /// </summary>
        ///<remarks>(нигде не используется, но можно добавить при вводе координат вершин нового четырехугольника)</remarks>
        /// <param name="p"></param>
        /// <returns></returns>
        public bool Equals(params Point[] p)
        {

            for (int i = 0; i < p.Length; i++)
            {
                int count = 0;
                for (int j = i; j < p.Length; j++)
                    if (p[i].x == p[j].x)
                        if (p[i].y == p[j].y)
                            count++;

                if (count >= 2)
                    return true;

            }
            return false;

        }
    }
}