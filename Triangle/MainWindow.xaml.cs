using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static TriangleN.Triangle;

namespace TriangleN
{
    /// <summary> контроллер
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        //метод ConvertBitmapToBitmapImage, который преобразует объект Bitmap в объект BitmapImage.
        //Bitmap - это класс из пространства имен System.Drawing, который представляет изображение в формате растрового изображения.
        //BitmapImage - это класс из пространства имен System.Windows.Media.Imaging, который представляет изображение в формате WPF.
        //Метод ConvertBitmapToBitmapImage принимает объект Bitmap в качестве аргумента и использует MemoryStream для сохранения изображения в формате PNG.
        //Затем создается объект BitmapImage, и его свойства инициализируются с использованием сохраненного изображения в MemoryStream.
        //Наконец, метод возвращает объект BitmapImage.
        private BitmapImage ConvertBitmapToBitmapImage(Bitmap bitmap)
        {
            using (var memory = new System.IO.MemoryStream())
            {
                bitmap.Save(memory, System.Drawing.Imaging.ImageFormat.Png);
                memory.Position = 0;
                var bitmapImage = new BitmapImage();
                bitmapImage.BeginInit();
                //Получает или задает BitmapCacheOption для использования данным экземпляром BitmapImage
                bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                bitmapImage.StreamSource = memory;
                bitmapImage.EndInit();
                return bitmapImage;
            }
        }


        private void CalculateTriangle()
        {
            //double.TryParse(textBoxX1.Text, out double x1) пытается проанализировать текст в textBoxX1 как значение double
            //и присваивает проанализированное значение переменной x1. Если синтаксический анализ завершен успешно,
            //метод возвращает true, а значение x1 устанавливается равным проанализированному (может ли текст в текстовых полях ввода быть успешно преобразован в двойные значения)
            double a, b, c;

            if (double.TryParse(BoxX1.Text, out double x1) &&
                double.TryParse(BoxY1.Text, out double y1) &&
                double.TryParse(BoxX2.Text, out double x2) &&
                double.TryParse(BoxY2.Text, out double y2) &&
                double.TryParse(BoxX3.Text, out double x3) &&
                double.TryParse(BoxY3.Text, out double y3))
            {
                Triangle triangle = new Triangle(x1, y1, x2, y2, x3, y3);

                a = triangle.CalculateSideA();
                b = triangle.CalculateSideB();
                c = triangle.CalculateSideC();

                if (a + b > c && b + c > a && c + a > b)
                {
                    //размеры для объекта рисования
                    int width = 120;
                    int height = 120;

                    //создание объекта для рисования
                    Bitmap triangleBitmap = PictureTr.DrawTriangle(x1, y1, x2, y2, x3, y3, width, height);
                    //вывод изображения
                    Picture.Source = ConvertBitmapToBitmapImage(triangleBitmap);

                    but_Per.Text = "Площадь равна: " + Math.Round(triangle.CalculateArea(), 2).ToString() + "\n" +
                                  "Периметр равен: " + Math.Round(triangle.CalculatePerimeter(), 2).ToString() + "\n" +
                                    "Стороны:\n" +
                                    "сторона A: " + Math.Round(triangle.CalculateSideA(), 2).ToString() + "\n" +
                                    "сторона B: " + Math.Round(triangle.CalculateSideB(), 2).ToString() + "\n" +
                                    "сторона C: " + Math.Round(triangle.CalculateSideC(), 2).ToString() + "\n" +
                    "Вид треугольника: " + triangle.GetTriangleType() + "\n" +
                    "Угол A: " + Math.Round(triangle.CornerTrA(), 2).ToString() + "\n" +
                     "Угол B: " + Math.Round(triangle.CornerTrB(), 2).ToString() + "\n" +
                    "Угол C: " + Math.Round(triangle.CornerTrC(), 2).ToString();

                }
                //проверка на то что треугольник существует
                else
                {
                    but_Per.Text = "Такого треугольника не существует";
                }
            }
        }

        // когда происходит изменение значения свойств (координаты точек), вызывается метод CalculateTriangle()
        private void ChangeValueSolve(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            CalculateTriangle();
        }
    }
}

//mouse active - режим mouse over
