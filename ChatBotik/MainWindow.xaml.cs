//Пинчукова Гера ивт-22

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;




namespace ChatBot
{
    // класс главного окна чат-бота
    public partial class ChatBotik : Window
    {
        private string userName; // объявляем переменную userName в классе ChatBotik
        private сhatBot ChatBot = new сhatBot(); //экземпляр класса для работы с чат ботом

        //Эта строка объявляет приватное поле messages типа ObservableCollection<Message>
        //Это коллекция, которая будет содержать сообщения


        private MessageManager messageManager = new MessageManager(); // Создаем экземпляр класса MessageManager

        //Эта строка объявляет приватное поле messages типа ObservableCollection<Message>
        //Это коллекция, которая будет содержать сообщения
        private ObservableCollection<Message> messages;

        public ObservableCollection<Message> Messages
        {
            get { return messageManager.Messages; }
        }


        


        ////Эта строка объявляет событие PropertyChanged, которое будет вызываться при изменении свойства
        //public event PropertyChangedEventHandler PropertyChanged;
        ////это публичное свойство типа ObservableCollection<Message>,
        ////которое предоставляет доступ к приватному полю messages
        //private ObservableCollection<Message> messages;

        //public ObservableCollection<Message> Messages
        //{
        //    get { return messages; }
        //    set
        //    {
        //        //get { return messages; } - это геттер свойства, который возвращает значение поля messages
        //        //set { messages = value; OnPropertyChanged("Messages"); }
        //        //-это сеттер свойства, который устанавливает значение поля messages
        //        //равным переданному значению value. Затем он вызывает метод OnPropertyChanged("Messages"),
        //        //который уведомляет об изменении свойства Messages, чтобы связанные элементы управления или
        //        //другие объекты могли обновиться
        //        messages = value;
        //        OnPropertyChanged("Messages");
        //    }
        //}
        //Это конструктор класса ChatBotik. Он вызывает метод
        ///InitializeComponent(), который инициализирует компоненты окна.
        ///Затем он устанавливает DataContext текущего окна равным самому окну (this).
        ///Далее он создает новый экземпляр ObservableCollection<Message> и присваивает его свойству 
        ///Messages. Наконец, он добавляет обработчик события Loaded, который будет вызывать метод 
        ///MainWindow_Loaded при загрузке окна
        public ChatBotik()
        {
            InitializeComponent();
            DataContext = this;
            messages = messageManager.Messages; // Присваиваем messages коллекцию из messageManager
            Loaded += MainWindow_Loaded;
        }
        //передает имя измененного свойства в качестве аргумента
        //Этот метод используется для уведомления об изменении свойств
        //и обновления связанных элементов управления или других объектов
        protected virtual void OnPropertyChanged(string propertyName)
        {
           // PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        //метод MainWindow_Loaded, который вызывается при загрузке окна
        //Внутри метода создается экземпляр класса Login и отображается 
        //с помощью метода ShowDialog()
        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            Login loginForm = new Login();
            loginForm.ShowDialog();

            // проверяем случвй когда форма была закрыта без ввода имени 
            // в этом случае закрываем и форму бота
            if (loginForm.DialogResult == false)
            {
                Close();
            }

            if (loginForm.DialogResult == true)
            {
                // сохраняем значение из формы login в переменную userName
                userName = loginForm.UserName;

                // Создание экземпляра класса DialogSaver с именем пользователя
                DialogSaver dialogSaver = new DialogSaver(userName);

                // Загрузка истории сообщений в список из сообщений
                List<Message> history = dialogSaver.LoadHistory();

                // Добавление истории в коллекцию сообщений
                foreach (Message message in history)
                {
                    Messages.Add(new Message { Author = message.Author, Text = message.Text, Timestamp = message.Timestamp });
                }
            }
        }



        //обработчик события нажатия на кнопку "отправить сообщение"
        private void butSend_Click(object sender, RoutedEventArgs e)
        {
            string author = userName; // имя пользователя
            string text = text_mess.Text; //текст сообщения
            string timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"); //время отправки(текущее год-месяц-день время)
            //добавить сообщение
            Messages.Add(new Message { Author = author, Text = text, Timestamp = timestamp });

            // Отправить запрос к классу ChatBot
            string response = ChatBot.HandleMessageTextNew(text);

            // Добавить ответ от ChatBot в коллекцию сообщений
            Messages.Add(new Message { Author = "ЧатикБотик", Text = response, Timestamp = timestamp });

            // Создание экземпляра класса DialogSaver с именем пользователя
            DialogSaver dialogSaver = new DialogSaver(author);

            // Сохранение сообщения в диалоге
            dialogSaver.SaveMessage(author, text, timestamp);

            // Сохранение ответа бота в диалоге
            dialogSaver.SaveMessage("ЧатикБотик", response, timestamp);

            // Очистка поля ввода
            text_mess.Text = "";

            
            }


        }

}