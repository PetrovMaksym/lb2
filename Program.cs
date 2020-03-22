using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
/*
 Создать класс квадрат, члены класса – координаты 4-х точек.Предусмотреть в классе методы вычисления и вывода сведений о 
 фигуре – длины сторон, диагоналей,
 периметр, площадь.Создать производный класс – ромб, предусмотреть в классе проверку, является ли фигура ромбом. 
 Написать программу, демонстрирующую работу с этими классами: дано N четырехугольников и M ромбов, найти четырехугольник с
 минимальным периметром и среднюю площадь ромбов
     */
namespace ShuviNaiTblEblan
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Quad> quadsList = new List<Quad>();

            Quad quad;
            int choise;
            string menu = "\t\t\tМЕНЮ:\n\t(Введите номер выбранного пункта)\n\n\n\n1)\tДобавить новый четырехугольник\n2)\tДобавить 3 четырехугольника автоматически\n3)\tПолучить информацию о четырехугольнике\n4)\tПолучить площадь четырехугольника\n5)\t найти кол-во четырехугольников, у которых площадь меньше средней площади четырехугольников\n6)\tСреднюю площадь прямоугольников\n0)Выход\n";

            do
            {
                Console.WriteLine("\n\n(На данный момент построено " + quadsList.Count + " четырехугольников)\n\n");
                Console.WriteLine(menu);

                try
                {
                    choise = int.Parse(Console.ReadLine());
                }
                catch (Exception)

                {
                    Console.WriteLine("Неверный ввод!");
                    continue;
                }
                int answer;
                switch (choise)
                {
                    case 0:
                        return;

                    case 1:

                        do
                        {
                            Console.WriteLine("\n\n\nВведите координаты вершин четырехугольника:\n");
                            quad = new Quad();
                            Console.Clear();
                            Console.Write("\nПробую построить четырехугольник по заданным точкам");
                            for (int i = 0; i <= 5; i++)
                            {
                                Thread.Sleep(250);
                                Console.Write(".");
                            }

                        } while (!quad.IsQuad());

                        Console.WriteLine("\n\nЧетырехугольник построен!\n");
                        quadsList.Add(quad);



                        break;
                    case 2:
                        quadsList.Add(new Rectangle(new Point(3, 4), new Point(0, -2), new Point(5, 13), new Point(6, 2)));

                        quadsList.Add(new Rectangle(new Point(0, 1), new Point(5, -3), new Point(6, -1), new Point(15, 3)));

                        quadsList.Add(new Rectangle(new Point(1, -1), new Point(5, -8), new Point(6, -5), new Point(7, 3)));

                        quadsList.Add(new Rectangle(new Point(-1, -1), new Point(1, 8), new Point(3, 8), new Point(-1, -8)));

                        quadsList.Add(new Rectangle(new Point(1, -1), new Point(-1, -1), new Point(-1, 1), new Point(1, 1)));
                        quadsList.Add(new Rectangle(new Point(2, -2), new Point(-2, -2), new Point(-2, 2), new Point(2, 2)));


                        foreach (Quad item in quadsList)
                        {
                            item.IsQuad();
                            Console.WriteLine(String.Format("\nЧетырехугольник {0} построен!\n", quadsList.IndexOf(item) + 1));

                        }
                        break;
                    case 3:
                        Console.Clear();
                        Console.WriteLine("\n Введите порядковый номер четырехугольника информацию о котором вы хотите получить. \n (без проверки вводимой информации)");
                        answer = int.Parse(Console.ReadLine());
                        Console.Clear();
                        Console.WriteLine("\n" + quadsList.ElementAtOrDefault(answer - 1).GetInfo());
                        break;
                    case 4:
                        Console.Clear();
                        Console.WriteLine("\n Введите порядковый номер четырехугольника площадь которого вы хотите узнать. \n (без проверки вводимой информации)");
                        answer = int.Parse(Console.ReadLine());
                        Console.Clear();
                        Console.WriteLine("\n" + quadsList.ElementAtOrDefault(answer - 1).Square());
                        break;
                    case 5:
                        Console.Clear();
                        double Square = 0;
                        foreach (Quad item in quadsList)
                            Square += item.Square();
                        double avgSquare = Square / quadsList.Count();
                        int count = 0;
                        foreach (Quad item in quadsList)
                            if (item.Square() < avgSquare)
                            {
                                count++;
                            }
                        Console.WriteLine("Количество четырехугольников у которых площадь меньше средней площади всех четырехугольников =\t" + count);
                        break;
                    case 6:
                        double avgSquareRect = 0;
                        int countRect = 0;
                        foreach (Quad item in quadsList)
                            if ((item as Rectangle).IsRectangle())
                            {
                                avgSquareRect += item.Square();
                                ++countRect;
                            }
                        avgSquareRect = avgSquareRect / (double)countRect;
                        Console.WriteLine("средняя площадь всех прямоугольников = \t" + avgSquareRect);
                        break;
                    default:
                        continue;

                }

                Console.WriteLine("\n\n Для продолжения нажмите AnyKey\n\n");
                Console.ReadKey();
                Console.Clear();


            } while (true);
        }
    }
}
