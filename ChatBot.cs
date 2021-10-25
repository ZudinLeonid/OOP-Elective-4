using System;

namespace Server
{
    class ChatBot
    {
        private static string name = "Роберт"; // Имя бота
        
        // Вывод времени в "Кратком" формате (HH:mm)
        public static string GetTime()
        {
            string buff = $"Сейчас {DateTime.Now.ToString("t")}\n";
            Console.WriteLine($"{buff}");
            return buff;
        }

        // Вывод имени чат-бота
        public static string GetName()
        {
            string buff = $"Меня зовут {name}\n";
            Console.WriteLine($"{buff}");
            return buff;
        }

        // Вывод настроения бота
        public static string GetMood()
        {
            string buff;

            Random rnd = new Random();
            int value = rnd.Next();

            if (value % 2 == 0) // Настроение зависит от чётности рандомного числа
                buff = "Всё отлично!\n";
            else
                buff = "Дела неважно(\n";

            Console.WriteLine($"{buff}");
            return buff;
        }

        // Вывод длительности сессии
        public static string GetSessionTime(long session_time_msec)
        {
            string buff;
            // session_time_msec - время прошедшее с начала работы программы в мсек
            long session_time_sec = session_time_msec / 1000; // Перевод мсек в сек
            int session_time_min = 0;

            if (session_time_sec > 59)
            {
                session_time_min = (int)session_time_sec / 60; // Перевод сек в минуты
                session_time_sec = session_time_sec % 60;
            }

            buff = $"Я работаю уже {session_time_min} мин. {session_time_sec} сек.\n";
            Console.WriteLine($"{buff}");

            return buff;
        }
    }
}
