using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
//Пинчукова Гера ивт-22
namespace ChatBot
{

    // класс отвечает за сохранение и загрузку диалоговых сообщений
    // Он содержит приватные поля userName и filePath.
    ///userName - это имя пользователя, для которого сохраняется диалог.
    ///filePath - это путь к файлу, в котором будет сохраняться диалог
    ///(формируется на основе текущей директории и имени пользователя)

    //класс, отвечающий за сохранение и загрузку диалоговых сообщений
    public class DialogSaver
    {
        private string userName;
        private string filePath;//путь к файлу, в котором хранятся сообщения пользователя



        private static ObservableCollection<Message> messages = new ObservableCollection<Message>();
        /// <summary>
        /// конструктор для сообщений
        /// </summary>
        public static ObservableCollection<Message> Messages
        {
            get { return messages; }
        }
        /// <summary>
        /// сохранение сообщений сохраняется в файл {userName}_dialog.json
        /// </summary>
        /// <param name="userName"> имя пользователя</param>
        public DialogSaver(string userName)
        {
            
                DialogSaver.messages = messages;
                this.userName = userName;
                string fileName = $"{userName}_dialog.json";
                filePath = Path.Combine(Environment.CurrentDirectory, fileName);
            
        }




        /// <summary>
        /// для сохранения сообщения. 
        /// </summary>
        /// <param name="author">author (автор сообщения)</param>
        /// <param name="text"> text (текст сообщения) </param>
        /// <param name="timestamp">timestamp (временная метка сообщения)</param>
        public void SaveMessage(string author, string text, string timestamp)
        {
            Message message = new Message
            {
                Author = author,
                Text = text,
                Timestamp = timestamp
            };

            try
            {//метод для сериализации объекта в формат JSON.
                string jsonMessage = JsonConvert.SerializeObject(message);
                File.AppendAllText(filePath, jsonMessage + Environment.NewLine);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving message: {ex.Message}");
            }
        }

        //коллекция сообщений
        public List<Message> LoadHistory()
        {
            List<Message> history = new List<Message>();

            try
            {
                if (File.Exists(filePath))
                {
                    string[] jsonMessages = File.ReadAllLines(filePath);
                    foreach (string jsonMessage in jsonMessages)
                    {
                        Message message = JsonConvert.DeserializeObject<Message>(jsonMessage);
                        history.Add(message);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading history: {ex.Message}");
            }

            return history;
        }
    }

}
