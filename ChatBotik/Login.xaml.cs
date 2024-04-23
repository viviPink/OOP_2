using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
//Пинчукова Гера ивт-22
namespace ChatBot
{
 //класс для ввода имени пользователя 
    public partial class Login : Window
    {
        //имя пользователя, которое будет введено в форме Login
        //публичный геттер и приватный сеттер, что означает,
        //что значение можно получить извне, но изменить его можно только внутри класса
        public string UserName { get; private set; }
        public Login()
        {
            //конструктор класса Login
            //Он вызывается при создании экземпляра класса Login и инициализирует компоненты формы
            InitializeComponent();
        }



        // Обработчик нажатия на кнопку
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //проверяет, является ли поле ввода txtUsername пустым или содержит только
            //пробелы. Если это так, то метод просто возвращает управление и ничего не делает
            if (string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                return;
            }
            //имя пользователя
            UserName = txtUsername.Text;
            DialogResult = true;
            Close();

        }

    
    }
}
