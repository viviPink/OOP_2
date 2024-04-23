using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using Newtonsoft.Json;
//Пинчукова Гера ивт-22
namespace ChatBot
{
    // класс для парсинга погоды с помощью API (возращает nan в случае ошибки)
    internal class Weather
    {
        public static double GetWeather()
        {
            // обработка исключений, которые могут
            // возникнуть при загрузке данных из API (json)
            try
            {

                // после использования этого блока ресурсы будут автоматически очищены
                //создает экземпляр WebClient, который будет использоваться для выполнения запроса к API погоды
                using (var client = new WebClient())
                {
                    //определяется URL-адрес для вызова API погоды с установленными параметрами, включая город Chita, API ключ и единицы измерения (метрическая система)
                    string url = "https://api.openweathermap.org/data/2.5/weather?q=Chita&appid=876f9b02c8b78fa64b611c823251e1ff&units=metric";
                    // отправляет GET-запрос к заданному URL и сохраняет полученный JSON-ответ в переменной response
                    string response = client.DownloadString(url);
                    // JSON-ответ распаковывается из строки в объект dynamic, используя библиотеку Json.NET (Newtonsoft.Json)
                    dynamic data = JsonConvert.DeserializeObject(response);

                    // строка проверяет, что объект data не равен null и содержит подобъекты main и temp, чтобы извлечь данные о температуре
                    if (data != null && data.main != null && data.main.temp != null)
                    {
                        //Здесь температура доступа из объекта data и сохраняется в переменной temp
                        double temp = data.main.temp;
                        return temp;
                    }
                    else
                    {
                        // Если данные не соответствуют ожидаемой структуре, можно вернуть значение по умолчанию или бросить исключение
                        throw new Exception("Invalid data format");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while fetching weather data: " + ex.Message);
                return double.NaN; // возвращаем nan в случае ошибки
            }
        }
    }


}

