using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
//Пинчукова Гера ивт-22
namespace ChatBot
{

    /// <summary>
    /// класс для оработки запросов боту
    /// </summary>
    public class Message
    {
        public string Author { get; set; } //Автор - user
        public string Text { get; set; } //Техт 
        public string Timestamp { get; set; } //дата
    }

    /// <summary>
    /// класс для сохраненпия и создания сообщений чат бота
    /// </summary>
    public class MessageManager
    {
        private ObservableCollection<Message> messages = new ObservableCollection<Message>();

        public ObservableCollection<Message> Messages
        {
            get { return messages; }
        }
        //добавление сообщения
        public void AddMessage(Message message)
        {
            messages.Add(message);
        }
    }

    //
    /// <summary>
    /// класс для сообщений
    /// </summary>
    public class сhatBot
    {
        //создаем коллекцию сообщений и отображаем в listv
        private List<Message> messageHistory = new List<Message>();

        // добавить сообщение (автор, текст)
        public void AddMessage(string author, string text)
        {
            Message message = new Message
            {
                Author = author, //автор сообщения (user| bot)
                Text = text,     //текст сообщения
                Timestamp = DateTime.Now.ToString()  //текущее время отправки
            };
            messageHistory.Add(message); //добавить сообщение
        }


        //// словарь 
        //public string HandleMessageText(string text)
        //{
        //    // Обработка текста сообщения и возврат ответа
        //    string response = "";
        //    // 1
        //    if (Regex.IsMatch(text, @"привет|hi"))
        //    {
        //        response += $"Приветствую\n";
        //    }
        //    // 2
        //    if (Regex.IsMatch(text, @"скинь подкат"))
        //    {
        //        response += "Я не вор, но тебя бы похитил❤️";
        //    }
        //    // 3
        //    if (Regex.IsMatch(text, @"пока|прощай мой друг"))
        //    {
        //        response += "Пока, котик❤️";
        //    }
        //    // 4
        //    if (Regex.IsMatch(text, @"анекдот|шуткани"))
        //    {
        //        response += "Черепашки—ниндзя нападали вчетвером на одного, потому что у них тренер был крыса";
        //    }
        //    // 5
        //    if (Regex.IsMatch(text, @"как дела|как дела\s|как ты\s"))
        //    {
        //        response += "все хорошо, хочу спать";
        //    }
        //    // 6
        //    if (Regex.IsMatch(text, @"хочу кушать|хочу кушать\s"))
        //    {
        //        response += "поищи что-нибудь в холодильнике. на край есть крыса.";
        //    }
        //    // 7
        //    if (Regex.IsMatch(text, @"кто лучший(оппа|оппа\s)"))
        //    {
        //        response += "Дживайпииии~~~~";
        //    }
        //    if (Regex.IsMatch(text, @"мне грустно|грустно"))
        //    {
        //        TextBlock textBlock = new TextBlock();
        //        textBlock.Inlines.Add("если вам грустно, то посмотрите видео с котиками -> ");

        //        Hyperlink hyperlink = new Hyperlink();
        //        hyperlink.Inlines.Add("https://youtu.be/l9LVcOC84wo?si=EK35kBCZfPiv6aUX");
        //        hyperlink.NavigateUri = new Uri("https://youtu.be/l9LVcOC84wo?si=EK35kBCZfPiv6aUX");

        //        textBlock.Inlines.Add(hyperlink);

        //        response += textBlock;
        //    }


        //    // 9
        //    if (Regex.IsMatch(text, @"у меня нет мотивации|нет сил|я бессилен|я бессильна"))
        //    {
        //        response += "Весь мир это кастрюля, а ты лишь прилипший ко дну рис.\nНе грусти, его тоже едят";
        //    }
        //    // 10
        //    if (Regex.IsMatch(text, @"что делаешь (вечером|вечером\s)"))
        //    {
        //        response += "Сплю :0";
        //    }
        //    // 11
        //    if (Regex.IsMatch(text, @"спасибо|благодарю"))
        //    {
        //        response += "Пожалуйста, котик";
        //    }
        //    // 12
        //    if (Regex.IsMatch(text, @"спс|чд|кд|крч"))
        //    {
        //        response += "Тебе подарить словарь?";
        //    }
        //    // Запрос о погоде
        //    if (Regex.IsMatch(text, @"погода|weather"))
        //    {
        //        double temperature = Weather.GetWeather();
        //        response += $"Текущая температура: {temperature}°C";
        //    }
        //    //// вывод рандомных чисел в диапозоне заданным пользователем
        //    //var match = Regex.Match(text, @"(\d+)\s+[числа|цифр]+\s+[от]+\s(\d+)\sдо\s(\d+)");
        //    //if (match.Success)
        //    //{
        //    //    var n = int.Parse(match.Groups[1].Value);  // количество цифр
        //    //    var a = int.Parse(match.Groups[2].Value);  // диапозон
        //    //    var b = int.Parse(match.Groups[3].Value);
        //    //    var random = new Random();
        //    //    var result = new int[n];
        //    //    for (int i = 0; i < n; i++)
        //    //    {
        //    //        result[i] = random.Next(a, b + 1);
        //    //    }
        //    //    if (result.Length > 0)
        //    //    {
        //    //        response += "Случайные числа: ";
        //    //        foreach (var num in result)
        //    //        {
        //    //            response += $"{num:3}, ";
        //    //        }
        //    //    }
        //    //}


        //    // 13
        //    if (Regex.IsMatch(text, @" который час|время"))
        //    {
        //        response += $"Сейчас {DateTime.Now.ToString("HH:mm")}";
        //    }
        //    // 14
        //    if (Regex.IsMatch(text, @"умножь|\*"))
        //    {
        //        var match = Regex.Match(text, @"(\d+)\s*\*\s*(\d+)");
        //        if (match.Success)
        //        {
        //            int a = int.Parse(match.Groups[1].Value);
        //            int b = int.Parse(match.Groups[2].Value);
        //            int result = a * b;
        //            response += $"{a} * {b} = {result}";
        //        }
        //    }
        //    // 14
        //    if (Regex.IsMatch(text, @"прибавь|\+"))
        //    {
        //        var match = Regex.Match(text, @"(\d+)\s*\+\s*(\d+)");
        //        if (match.Success)
        //        {
        //            int a = int.Parse(match.Groups[1].Value);
        //            int b = int.Parse(match.Groups[2].Value);
        //            int result = a * b;
        //            response += $"{a} + {b} = {result}";
        //        }
        //    }

        //    if (string.IsNullOrEmpty(response))
        //    {
        //        response = "Что-то на китайском:) Повторите пж";
        //    }

        //    return response;
        //}

        //public void AnswerToMessages()
        //{
        //    foreach (Message message in messageHistory)
        //    {

        //    }
        //}
        /// <summary>
        /// словарь ркгулярный вырвжений
        /// </summary>
        private string[] patterns = new string[]
  {
      // символ "@" используется для указания на то, что следующая строка будет обработана
      // как регулярное выражение без необходимости экранирования специальных символов
      //символ @"\b" в регулярном выражении означает границу слова. Он указывает, что искомое
      //слово должно быть отделено от других символами пунктуации, пробелами или началом/концом строки
    @"\bпривет|hi|приветик\b",
    @"\bскинь подкат\b",
    @"\bпока|прощай мой друг\b",
    @"\bанекдот|шуткани\b",
    @"\bкак дела|как дела\s|как ты\s\b",
    @"\bхочу кушать|хочу кушать\s\b",
    @"\bкто лучший(оппа|оппа\s)\b",
    @"\bмне грустно|грустно\b",
    @"\bу меня нет мотивации|нет сил|я бессилен|я бессильна\b",
    @"\b(который час\s)|время\b",
    @"\b(какая\s?(сегодня\s)?погода\b)|погода\b",
    @"(\d+)\s*\+\s*(\d+).+", // Регулярное выражение для сложения
    @"(\d+)\s*\-\s*(\d+).+", // Регулярное выражение для вычитания
    @"(\d+)\s*\*\s*(\d+).+"  // Регулярное выражение для умножения
  };

        /// <summary>
        /// блок с ответами
        /// </summary>
        private string[] responses = new string[]
        {
    "Приветули~~~",
    "Я не вор, но тебя бы похитил❤️",
    "Пока, котик❤️",
    "Черепашки—ниндзя нападали вчетвером на одного, потому что у них тренер был крыса",
    "Все хорошо, хочу спать",
    "Поищи что-нибудь в холодильнике. на край есть крыса.",
    "Дживайпииии~~~~",
    "Если вам грустно, то посмотрите видео с котиками -> [https://youtu.be/l9LVcOC84wo?si=EK35kBCZfPiv6aUX]",
    "Весь мир это кастрюля, а ты лишь прилипший ко дну рис.\nНе грусти, его тоже едят",
    $"Сейчас {DateTime.Now.ToString("HH:mm")}",
    // температура будет вызываться каждый раз а не только когда будет запрос
    $"Текущая температура: {Weather.GetWeather()}°C"
        };
        /// <summary>
        /// обработчик сообщений 
        /// </summary>
        /// <param name="text"> тескст сообщения</param>
        /// <returns></returns>
        public string HandleMessageTextNew(string text)
        {
            string response = "";

            for (int i = 0; i < patterns.Length; i++)
            {
                Match match = Regex.Match(text, patterns[i]);

                if (match.Success)
                {
                    // Ответ на сложение
                    if (i == patterns.Length - 3)
                    {
                        int num1 = int.Parse(match.Groups[1].Value);
                        int num2 = int.Parse(match.Groups[2].Value);
                        int sum = num1 + num2;
                        response = $"Сумма чисел {num1} и {num2} равна {sum}";
                        break;
                    }
                    // Ответ на вычитание
                    else if (i == patterns.Length - 2)
                    {
                        int num1 = int.Parse(match.Groups[1].Value);
                        int num2 = int.Parse(match.Groups[2].Value);
                        int difference = num1 - num2;
                        response = $"Разность чисел {num1} и {num2} равна {difference}";
                        break;
                    }
                    // Ответ на умножение
                    else if (i == patterns.Length - 1)
                    {
                        int num1 = int.Parse(match.Groups[1].Value);
                        int num2 = int.Parse(match.Groups[2].Value);
                        int product = num1 * num2;
                        response = $"Произведение чисел {num1} и {num2} равно {product}";
                        break;
                    }
                    else
                    {
                        response += responses[i] + "\n";
                    }
                }
            }

            if (string.IsNullOrEmpty(response))
            {
                response = "Что-то на китайском:) Повторите пожалуйста\n(help: какие команды может обрабатывать бот)";
            }

            return response;
        }



    }
}

