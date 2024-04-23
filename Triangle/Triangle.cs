using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TriangleN
{ //автор
    /// <summary>
    /// класс для работы с треугольником (для поиска углов, периметра , сторон и площади)
    /// </summary>
    public class Triangle
    {
 
            /// <summary>
            /// перепенные для координат точек Х1(x1;y1) X2(x2;y2) X3(x3;y3)
            /// </summary>
            private double x1, y1, x2, y2, x3, y3;

            // Конструкторы
            /// <summary>
            /// Устанавливаем начальные значения координат
            /// </summary>
            public Triangle()
            {
                x1 = y1 = x2 = y2 = x3 = y3 = 0.0;
            }


            /// <summary>
            /// Конструктор объекта для класса Triangle с параметрами
            /// </summary>
            /// <param name="x1"> координата первой вершины по оси X</param>
            /// <param name="y1"> координата первой вершины по оси Y</param>
            /// <param name="x2"> координата второй вершины точки по оси X</param>
            /// <param name="y2"> координата второй вершины точки по оси Y</param>
            /// <param name="x3"> координата третьей вершины точки по оси X</param>
            /// <param name="y3"> координата третьей вершины точки по оси Y</param>
            public Triangle(double x1, double y1, double x2, double y2, double x3, double y3)
            {
                this.x1 = x1;
                this.y1 = y1;
                this.x2 = x2;
                this.y2 = y2;
                this.x3 = x3;
                this.y3 = y3;
            }


            /// <summary>
            /// Метод который возвращает значение первой вершины по оси x
            /// </summary>
            /// <returns>Возращается значение типа double: "значение первой координаты по оси х " </returns>
            public double GetX1() { return x1; }
            /// <summary>
            /// Метод который возвращает значение первой вершины по оси y
            /// </summary>
            /// <returns>Возращается значение типа double: "значение первой координаты по оси y " </returns>
            public double GetY1() { return y1; }
            /// <summary>
            /// Метод который возвращает значение второй вершины по оси x
            /// </summary>
            /// <returns>Возращается значение типа double: "значение второй координаты по оси х " </returns>
            public double GetX2() { return x2; }
            /// <summary>
            /// Метод который возвращает значение второй вершины по оси y
            /// </summary>
            /// <returns>Возращается значение типа double: "значение второй координаты по оси y " </returns>
            public double GetY2() { return y2; }
            /// <summary>
            /// Метод который возвращает значение третьей вершины по оси x
            /// </summary>
            /// <returns>Возращается значение типа double: "значение третьей координаты по оси х " </returns>
            public double GetX3() { return x3; }
            /// <summary>
            /// Метод который возвращает значение третьей вершины по оси y
            /// </summary>
            /// <returns>Возращается значение типа double: "значение третьей координаты по оси y" </returns>
            public double GetY3() { return y3; }


            /// <summary>
            /// Методы для нахождения стороны А треугольника 
            /// </summary>
            /// <returns>Возращается значение типа double: "сторона А" </returns>
            public double CalculateSideA()
            {
                return Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));
            }

            /// <summary>
            /// Методы для нахождения стороны В треугольника 
            /// </summary>
            /// <returns>Возращается значение типа double: "сторона B" </returns>
            public double CalculateSideB()
            {
                return Math.Sqrt(Math.Pow(x3 - x2, 2) + Math.Pow(y3 - y2, 2));
            }

            /// <summary>
            /// Методы для нахождения стороны C треугольника 
            /// </summary>
            /// <returns>Возращается значение типа double: "сторона C" </returns>
            public double CalculateSideC()
            {
                return Math.Sqrt(Math.Pow(x3 - x1, 2) + Math.Pow(y3 - y1, 2));
            }



            /// <summary>
            /// Нахождение угла треугольника А  
            /// </summary>
            /// <returns> Возращается значение типа double: "угол А" </returns>
            public double CornerTrA()
            {//поиск сторон треугольника для нахождения угла
                double a = CalculateSideA();
                double b = CalculateSideB();
                double c = CalculateSideC();
                double angleA = Math.Acos((Math.Pow(b, 2) + Math.Pow(c, 2) - Math.Pow(a, 2)) / (2 * b * c));

                // Перевод из радиан в градусы
                return angleA * (180 / Math.PI);
            }

            /// <summary>
            /// Нахождение угла треугольника B 
            /// </summary>
            /// <returns> Возращается значение типа double: "угол B" </returns>
            public double CornerTrB()
            {
                //поиск сторон треугольника для нахождения угла
                double a = CalculateSideA();
                double b = CalculateSideB();
                double c = CalculateSideC();

                double angleB = Math.Acos((Math.Pow(a, 2) + Math.Pow(c, 2) - Math.Pow(b, 2)) / (2 * a * c));

                // Перевод из радиан в градусы
                return angleB * (180 / Math.PI);
            }

            /// <summary>
            /// Нахождение угла треугольника C 
            /// </summary>
            /// <returns> Возращается значение типа double: "угол C" </returns>
            public double CornerTrC()
            {
                //поиск сторон треугольника для нахождения угла
                double a = CalculateSideA();
                double b = CalculateSideB();
                double c = CalculateSideC();

                double angleC = Math.Acos((Math.Pow(a, 2) + Math.Pow(b, 2) - Math.Pow(c, 2)) / (2 * a * b));

                // Перевод из радиан в градусы
                return angleC * (180 / Math.PI);
            }

            /// <summary>
            /// Метод для нахождения периметра треугольника
            /// </summary>
            /// <returns> Возращается значение типа double: "Перимерт треугольника"</returns>
            public double CalculatePerimeter()
            {
                double a = CalculateSideA();
                double b = CalculateSideB();
                double c = CalculateSideC();
                return a + b + c;
            }

            /// <summary>
            ///  Метод для нахождения площади треугольника
            /// </summary>
            /// <returns>Возращается значение типа double: "Площадь треугольника"</returns>
            public double CalculateArea()
            {
                double a = CalculateSideA();
                double b = CalculateSideB();
                double c = CalculateSideC();
                //находим полупериметр треугольника
                double semiPerimeter = CalculatePerimeter() / 2;
                return Math.Sqrt(semiPerimeter * (semiPerimeter - a) * (semiPerimeter - b) * (semiPerimeter - c));
            }



        /// <summary>
        /// Виды треугольников
        /// </summary>
        public enum TriangleType
        {
            Equilateral,    // Равносторонний треугольник
            Isosceles,      // Равнобедренный треугольник
            Right,          // Прямоугольный треугольник
            Scalene,        // Произвольный треугольник
            Invalid         // Треугольник не существует
        }

        /// <summary>
        /// Метод для определения типа треугольника
        /// </summary>
        /// <returns> Возвращается значение из перечисления TriangleType </returns>
        /// <summary>
        /// Метод для определения типа треугольника
        /// </summary>
        /// <returns> Возвращается значение из перечисления TriangleType </returns>
        public TriangleType GetTriangleType()
        {
            double a = CalculateSideA();
            double b = CalculateSideB();
            double c = CalculateSideC();

            if (a == b && b == c)
            {
                return TriangleType.Equilateral;
            }
            else if (a == b || b == c || c == a)
            {
                return TriangleType.Isosceles;
            }
            else if (Math.Pow(a, 2) + Math.Pow(b, 2) == Math.Pow(c, 2) ||
                     Math.Pow(b, 2) + Math.Pow(c, 2) == Math.Pow(a, 2) ||
                     Math.Pow(c, 2) + Math.Pow(a, 2) == Math.Pow(b, 2))
            {
                return TriangleType.Right;
            }
            else if (a + b <= c || b + c <= a || c + a <= b)
            {
                return TriangleType.Invalid;
            }
            else
            {
                return TriangleType.Scalene;
            }
        }
        //ту стринг


        /// <summary>
        /// Сохранение данных (координат точек) в бинарном файле
        /// </summary>
        /// <param name="filename"> Имя файла для сохранения</param>
        public void SavePoint(string filename)
            {

                using (BinaryWriter writer = new BinaryWriter(File.Open(filename, FileMode.Create)))
                {
                    writer.Write(GetX1());
                    writer.Write(GetY1());
                    writer.Write(GetX2());
                    writer.Write(GetY2());
                    writer.Write(GetX3());
                    writer.Write(GetY3());
                }
            }

            // File.Open(filename, FileMode.Create)
            //используется для открытия файла с именем
            //filename в режиме записи. Если файл не существует, он будет создан.
            //Если файл существует, его содержимое будет удалено, и файл будет открыт для записи с нуля

            // Внутри блока using создается объект BinaryWriter, который позволяет
            // записывать двоичные данные в указанный поток (в данном случае - файл).
            // Он принимает поток данных, над которыми будет выполняться запись, в данном случае - результат вызова File.Open.
        }
    }


