using System;
using System.IO;

namespace Server
{
    class Dialog
    {
        // Путь к файлу, в котором сохраняетя история сообщений 
        private static string path = "history.txt";
        // @"C:\Users\User\Documents\ТУСУР\ЭЛКОМ+\OOP Elective 3\Chat\Server\history.txt";

        // Вывод меню "Помощь"
        public static void HelpMenu()
        {
            string buff;
            buff = "\nЯ умею отвечать на вопросы\\команды:\n";
            buff += "\t\"Сколько сейчас времени?\"\n";
            buff += "\t\"Как тебя зовут?\"\n";
            buff += "\t\"Как дела?\"\n";
            buff += "\t\"Сколько времени ты работаешь?\"\n";
            buff += "\t\"Покажи нашу переписку\"\n";
            buff += "\t\"Очисти экран\"\n";
            buff += "\t\"Выход\"\n";

            Console.WriteLine($"{buff}");
        }

        // Запись в файл фразы пользователя или бота
        public static void WritetoHistory(string user_or_bot_phrase)
        {
            using (StreamWriter sw = new StreamWriter(path, true))
            {
                sw.WriteLine($"{user_or_bot_phrase}");
            }
        }

        // Очистка файла, хранящего историю переписки
        public static void ClearHistory()
        {
            StreamWriter sw = new StreamWriter(path, false);
            sw.Close();
        }

        // Вывод истории сообщений
        public static void ShowHistory()
        {
            Console.WriteLine($"История сообщений:\n");
            using (StreamReader sr = new StreamReader(path))
            {
                Console.WriteLine(sr.ReadToEnd());
            }
            Console.WriteLine("\n");
        }
    }
}
