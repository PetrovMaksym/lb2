using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShuviNaiTblEblan
{
       class Quad : Point
    {
        private Point vertex1;
        private Point vertex2;
        private Point vertex3;
        private Point vertex4;

        public Quad()
        {
            vertex1 = new Point();
            vertex2 = new Point();
            vertex3 = new Point();
            vertex4 = new Point();

            List<Point> vertexes = new List<Point>(4) { vertex1, vertex2, vertex3, vertex4 };
            double x, y;
            for (int i = 0; i < 4; i++)
            {

                while (true)
                {
                    try
                    {
                        Console.WriteLine("Введите координату точки по Х \t");
                        x = double.Parse(Console.ReadLine());
                        Console.WriteLine("Введите координату точки по Y \t");
                        y = double.Parse(Console.ReadLine());
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Неверный ввод. Попробуйте еще раз \n");
                        continue;
                    }
                    break;
                }
                vertexes[i].SetX(x);
                vertexes[i].SetY(y);
            }
        }

        public Quad(Point p1, Point p2, Point p3, Point p4)
        {

            vertex1 = p1;
            vertex2 = p2;
            vertex3 = p3;
            vertex4 = p4;

        }
        /// <summary>
        /// Проверяет можно ли построить четырехугольник по точкам (в том порядке в котором их вводили) четырехугольником. 
        /// Возвращает TRUE Если построение успешно.
        /// </summary>
        /// <returns></returns>
        public bool IsQuad() // ВОТ И НАДО ОНО МНЕ БЫЛО!!!?????
        {
            bool result = true;

            if (VertexOnLine())
            {
                Console.WriteLine("Одна или более вершин находятся на одной прямой");
                return false;
            }

            Point tmpPoint = IntersectionPoint(vertex1, vertex2, vertex3, vertex4);
            Point nextTmpPoint = IntersectionPoint(vertex2, vertex3, vertex4, vertex1);

            if (tmpPoint == null)
            { }

            else if (IsPointOnSide(tmpPoint, vertex1, vertex2) && IsPointOnSide(tmpPoint, vertex3, vertex4))
            {
                Console.WriteLine("Боюсь в нашем случае самопересекающиеся четырехугольники не прокатывают:)");
                result = false; // - Это не четырехугольник
            }
            else if (nextTmpPoint == null)
            {

            }
            else if (IsPointOnSide(nextTmpPoint, vertex2, vertex3) && IsPointOnSide(nextTmpPoint, vertex4, vertex1))
            {
                Console.WriteLine("Нарисуйте свою фигуру на плоскости по точкам в той же последовательности в которой ввели. А теперь скажите, что у вашей фигуры на плоскости только 4 угла и 4 стороны:)");
                result = false;
            }

            return result;

        }

        /// <summary>
        /// Определяет существуют ли 3 точки на одной прямой. Возвращает FAlSE если нет.
        /// </summary>
        /// 
        private bool VertexOnLine()
        {
            bool result = false;
            if (this.PointOnLine(vertex1, vertex2, vertex3))
            {

                result = true;
            }

            else if (this.PointOnLine(vertex1, vertex3, vertex4))
            {


                result = true;
            }

            else if (this.PointOnLine(vertex3, vertex1, vertex4))
            {

                result = true;
            }
            else if (this.PointOnLine(vertex3, vertex1, vertex2))
            {
                result = true;
            }
            return result;

        }
        /// <summary>
        /// Проверяет пересекаются ли прямые построенные через стороны p1-p2 и р3-р4. Возвращает точку пересечения type- Point либо null если прямые параллельны. 
        /// </summary>
        /// <param name="p1">точка начала 1-ой стороны</param>
        /// <param name="p2">точка конца 1-ой стороны</param>
        /// <param name="p3">точка начала 2-ой стороны</param>
        /// <param name="p4">точка конца 2-ой стороны</param>
        /// <returns></returns>
        private Point IntersectionPoint(Point p1, Point p2, Point p3, Point p4)// передаются точки начала и конца противолежащих сторон
        {

            double a1, b1, c1, a2, b2, c2, x, y;//переменные для текущих вычислений

            //значения для первой прямой
            a1 = p1.GetY() - p2.GetY();
            b1 = p2.GetX() - p1.GetX();
            c1 = p1.GetX() * p2.GetY() - p2.GetX() * p1.GetY();
            //значения для второй  прямой
            a2 = p3.GetY() - p4.GetY();
            b2 = p4.GetX() - p3.GetX();
            c2 = p3.GetX() * p4.GetY() - p4.GetX() * p3.GetY();

            if ((a1 * b2) == (b1 * a2))
                return null;
            //находи точку пересечения
            x = (b1 * c2 - c1 * b2) / (b2 * a1 - b1 * a2);
            y = -(c2 + a2 * x) / b2;
            return new Point(x, y);

        }
        ///<summary>
        /// Проверяет находится ли точка Р на прямой,
        ///  
        /// построенной через вершины(точки) vert1,vert2.
        /// 
        /// Возвращает true если  точка находится на линии.
        /// 
        /// </summary>
        /// <param name="p"> Искомая точка</param>
        /// 
        /// <param name="vert1" >первая точка для построения линии</param>
        /// <param name="vert2">вторая точка для построения линии</param>
        /// 
        ///  
        private bool PointOnLine(Point p, Point vert1, Point vert2)

        {
            bool result;

            if (
                Math.Abs((vert1.GetY() - vert2.GetY()) * p.GetX() + (vert2.GetX() - vert1.GetX()) * p.GetY() - vert2.GetX() * vert1.GetY() + vert1.GetX() * vert2.GetY()) - 0.00000001 < 0
                )
            {
                Console.WriteLine("Найдена точка на линии");
                result = true;
            }

            else
            {
                Console.WriteLine("Точка не  находится на линии");
                result = false;
            }
            return result;

        }

        ///<summary>
        /// Проверка находится ли точка Р на стороне прямоугольника между точками pBegin, pEnd.
        /// Возвращает true если точка расположена на стороне между pBegin и pEnd
        /// 
        /// </summary> 
        /// <param name="p">проверяемая точка</param>  
        /// <param name="pBegin">Вершина(точка) начала стороны</param>
        /// <param name="pEnd">Вершина(точка) конца стороны</param>
        private bool IsPointOnSide(Point p, Point pBegin, Point pEnd)

        {
            bool result = false;
            if (!PointOnLine(p, pBegin, pEnd))
                result = false;
            else if (IsPointOnSideAxis(p.GetX(), pBegin.GetX(), pEnd.GetX()) && IsPointOnSideAxis(p.GetY(), pBegin.GetY(), pEnd.GetY()))
            {
                result = true;
                Console.WriteLine("Найдена точка на стороне");
            }

            return result;

        }
        /// <summary>
        ///  проверяет расположена ли значение проекции точки Р на ось координат в интервале[SideP1, SideP2] 
        ///  (проекции стороны, на ту же ось) 
        /// 
        /// </summary>
        ///
        /// <param name="P">значение проверяемой точки на выбранной оси</param>
        /// <param name="SideP1">значение начало стороны по той же оси</param>
        /// <param name="SideP2">значение конца стороны по той же оси</param>
        /// 

        private bool IsPointOnSideAxis(double P, double SideP1, double SideP2)
        {
            if (SideP1 <= SideP2)
            {
                if (P >= SideP1 && P <= SideP2)
                    return true;
            }
            else if (P < SideP1 && P > SideP2)
                return true;
            return false;

        }

        /// <summary>
        /// Получает длину стороны построенной между двумя вершинами. Принимает номер стороны(1-4) четырехугольника.
        /// Возвращает ее длину типа double округленный до 6 знаков после запятой. 
        /// В случае неверного вода возвращает 0;
        /// </summary>
        /// <param name="numSide">int номер запрошенной стороны</param>
        /// <returns>double</returns>
        public double Side(int numSide)
        {
            double sideSize;
            switch (numSide)
            {
                case 1:
                    sideSize = vertex1.Length(vertex2);
                    break;
                case 2:
                    sideSize = vertex2.Length(vertex3);
                    break;
                case 3:
                    sideSize = vertex3.Length(vertex4);
                    break;
                case 4:
                    sideSize = vertex4.Length(vertex1);
                    break;
                default:
                    sideSize = 0;
                    break;

            };
            return Math.Round(sideSize, 6);

        }

        /// <summary>
        /// Получает длину диагонали построенной между двумя вершинами. Принимает номер диагонали(1-2) четырехугольника.
        /// Возвращает ее длину типа double округленный до 6 знаков после запятой. 
        /// В случае неверного вода возвращает 0;
        /// </summary>
        /// <param name="numSide">int номер запрошенной стороны</param>
        /// <returns>double</returns>
        public double Diagonal(int num)
        {
            double diagonalSize = 0;
            if (num == 1)
                diagonalSize = vertex1.Length(vertex3);
            else if (num == 2)
                diagonalSize = vertex2.Length(vertex4);
            return Math.Round(diagonalSize, 6);
        }

        /// <summary>
        /// Рассчитывает и возвращает периметр четырехугольника. Округление до 6 знаков после запятой.
        /// </summary>
        /// <returns></returns>
        public double Perimeter()
        {
            double perimetr = 0;
            for (int i = 1; i <= 4; i++)
                perimetr += Side(i);
            return Math.Round(perimetr, 6);
        }

        /// <summary>
        /// Рассчитывает и возвращает площадь четырехугольника. Округление до 6 знаков после запятой.
        /// </summary>
        /// <returns></returns>

        public double Square()
        {
            double square = (Math.Abs(0.5 * (vertex1.GetX() * vertex2.GetY() + vertex2.GetX() * vertex3.GetY() + vertex3.GetX() * vertex4.GetY() + vertex4.GetX() * vertex1.GetY() - (vertex2.GetX() * vertex1.GetY() + vertex3.GetX() * vertex2.GetY() + vertex4.GetX() * vertex3.GetY() + vertex1.GetX() * vertex4.GetY()))));
            return square; // Площадь произвольного не самопересекающегося четырёхугольника, заданного на плоскости координатами своих вершин 
        }

        /// <summary>
        /// Получение информации о четырехугольнике. Возвращает строку со всей информацией.
        /// </summary>
        /// <returns></returns>
        public String GetInfo()
        {
            string info = String.Format("Информация о четырехугольнике:\n\nСторона а =\t {0}\nСторона b =\t {1}\nСторона c =\t {2}\nСторона d =\t {3}\nДиагональ1 D1 =\t {4}\nДиагональ2 D2 =\t {5}\nПериметр четырехугольника P = \t{6}\nПлощадь четырехугольника S= \t{7}\n ",
                                            Math.Round(this.Side(1), 3),
                                            Math.Round(this.Side(2), 3),
                                            Math.Round(this.Side(3), 3),
                                            Math.Round(this.Side(4), 3),
                                            Math.Round(this.Diagonal(1), 3),
                                            Math.Round(this.Diagonal(2), 3),
                                            Math.Round(this.Perimeter(), 3),
                                            Math.Round(this.Square(), 3)
                                            );

            return info;

        }
    }
}