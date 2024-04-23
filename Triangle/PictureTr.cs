using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

//Класс для работы с графическим изображением треугольника по  точкам
namespace TriangleN
{
    internal class PictureTr
    {
        //Объявление метода DrawTriangle с параметрами x1, y1, x2, y2, x3, y3, width, height типа double и int и возвращаемым типом Bitmap
        //(bitmap) - это статический метод класса Graphics, который создает новый объект Graphics, связанный с указанным объектом Bitmap
        public static Bitmap DrawTriangle(double x1, double y1, double x2, double y2, double x3, double y3, int width, int height)
        {
            //Создание объекта bitmap типа Bitmap(width height- размеры)
            Bitmap bitmap = new Bitmap(width, height);
            //создается объект g типа Graphics, который используется для рисования на изображении,
            //представленном объектом bitmap. Блок using гарантирует, что ресурсы, связанные с объектом g, будут
            //автоматически освобождены после завершения работы с ним, что помогает избежать утечек памяти
            using (Graphics g = Graphics.FromImage(bitmap))
            {
                //содъздаем объект которым будем рисовать (цвет можно выбирать)
                Pen pen = new Pen(Color.Black);

                // Нарисовать линии треугольника
                g.DrawLine(pen, (int)(x1), (int)(y1), (int)(x2), (int)(y2));
                g.DrawLine(pen, (int)(x2), (int)(y2), (int)(x3), (int)(y3));
                g.DrawLine(pen, (int)(x3), (int)(y3), (int)(x1), (int)(y1));

                // Нарисовать оси координат
                g.DrawLine(pen, 0, height / 2, width, height / 2); // Горизонтальная ось
                g.DrawLine(pen, width / 2, 0, width / 2, height); // Вертикальная ось

                //горизонтальную ось координат, проходящую по середине изображения по горизонтали,
                //и вертикальную ось координат, проходящую по середине изображения по вертикали
            }

            return bitmap;
        }
       

    }
}