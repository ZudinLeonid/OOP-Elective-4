using System;
using System.Diagnostics;

namespace Server
{
    class Program
    {
        static void Main(string[] args)
        {
            var sw = new Stopwatch(); // Старт секундомера для счёта длительности сессии
            sw.Start();

            Dialog.ClearHistory(); // Очистка файла с историей сообщений для новых сообщений

            string user_phrase;
            string bot_phrase;

            bot_phrase = "Введите слово \"Помощь\" для отображения списка действий";
            Console.WriteLine($"{bot_phrase}");
            Dialog.WritetoHistory(bot_phrase); // Запись в файл с иторией сообщение бота

            do
            {
                user_phrase = Console.ReadLine();
                Dialog.WritetoHistory(user_phrase); // Запись в файл с историей сообщение пользователя

                switch (user_phrase)
                {
                    case "Помощь":
                        Dialog.HelpMenu(); // Отображение меню "Помощь"
                        bot_phrase = "* Показано меню Помощь *\n";
                        break;
                    case "Сколько сейчас времени?":
                        bot_phrase = ChatBot.GetTime(); // Отображение системного времени
                        break;
                    case "Как тебя зовут?":
                        bot_phrase = ChatBot.GetName(); // Отображение имени чат-бота
                        break;
                    case "Как дела?":
                        bot_phrase = ChatBot.GetMood(); // Отображение настроения бота
                        break;
                    case "Сколько времени ты работаешь?":
                        sw.Stop();
                        long session_time_msec = sw.ElapsedMilliseconds; // Отображение длительности сессии
                        sw.Start();
                        bot_phrase = ChatBot.GetSessionTime(session_time_msec);
                        break;
                    case "Покажи нашу переписку":
                        bot_phrase = "* Показана история сообщений *\n";
                        Dialog.ShowHistory(); // Отображение истории сообщений
                        break;
                    case "Очисти экран":
                        bot_phrase = "* Экран был отчищен *\n";
                        Console.Clear(); // Очистка экрана
                        break;
                    case "Выход":
                        bot_phrase = "* Выход из приложения *\n"; // Выход из программы
                        break;
                    default:
                        bot_phrase = "Я вас не понял\n"; // Реакция на неизвестную команду
                        Console.WriteLine($"{bot_phrase}");
                        break;
                }

                Dialog.WritetoHistory(bot_phrase); // Запись ответа бота в историю

            } while (user_phrase != "Выход");
        }
    }
}
