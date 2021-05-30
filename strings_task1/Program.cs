using System;

namespace strings_task1
{
    class Program
    {
        #region Описание задания 2

        // Задание 2.
        // 1. Создать метод, принимающий  текст и возвращающий слово, содержащее минимальное количество букв
        // 2.* Создать метод, принимающий  текст и возвращающий слово(слова) с максимальным количеством букв 
        // Примечание: слова в тексте могут быть разделены символами (пробелом, точкой, запятой) 
        // Пример: Текст: "A ББ ВВВ ГГГГ ДДДД  ДД ЕЕ ЖЖ ЗЗЗ"
        // 1. Ответ: А
        // 2. ГГГГ, ДДДД

        #endregion

        /// <summary>
        /// Метод для поиска слова с минимальным количеством букв
        /// </summary>
        /// <param name="text">Исходный массив слов без разделителей</param>
        static void MinString(string[] strings)
        {
            int minStr = strings[0].Length;
            int minStrIndex = 0;

            for (int i = 0; i < strings.Length; i++)
            {
                if (minStr > strings[i].Length)
                {
                    minStr = strings[i].Length;
                    minStrIndex = i;
                }
            }
            Console.Write($"Слово, содержащее минимальное количество букв: {strings[minStrIndex]} ");
        }

        /// <summary>
        /// Метод для поиска слов с максимальным количеством букв
        /// </summary>
        /// <param name="text">Исходный массив слов без разделителей</param>
        static void MaxString(string[] strings)
        {
            int maxStr = strings[0].Length;

            for (int i = 0; i < strings.Length; i++)
            {
                if (maxStr < strings[i].Length)
                    maxStr = strings[i].Length;
            }
            Console.Write($"Слова, содержащее максимальное количество букв: ");
            foreach (string str in strings)
            {
                if (str.Length == maxStr)
                {
                    Console.Write(str + " ");
                }
            }
        }

        /// <summary>
        /// Метод, с которого начинается выполнение программы
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Console.SetCursorPosition(Console.WindowWidth / 2 - 20, 1);
            Console.WriteLine("Анализатор текста \n");

            Console.WriteLine("Введите текст: ");
            string text = Console.ReadLine();

            char[] symb = new char[3] { ' ', '.', ',' }; // Массив разделителей
            string[] strings = text.Split(symb, StringSplitOptions.RemoveEmptyEntries); // Массив слов из текста

            // Проверка на пустоту строки, что она не null, не "" и не состоит только из разделителей
            while (String.IsNullOrWhiteSpace(text) || strings.Length == 0)
            {
                Console.WriteLine("Вы не ввели текст. Попробуйте снова: ");
                text = Console.ReadLine();
                strings = text.Split(symb, StringSplitOptions.RemoveEmptyEntries);
            }

            MinString(strings);
            Console.WriteLine();
            MaxString(strings);

            Console.ReadKey();
        }
    }
}
