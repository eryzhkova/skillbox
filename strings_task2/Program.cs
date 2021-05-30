using System;

namespace strings_task2
{
    class Program
    {
        #region Описание задания 3

        // Задание 3. Создать метод, принимающий текст. 
        // Результатом работы метода должен быть новый текст, в котором
        // удалены все кратные рядом стоящие символы, оставив по одному 
        // Пример: ПППОООГГГООООДДДААА >>> ПОГОДА
        // Пример: Ххххоооорррооошшшиий деееннннь >>> хороший день

        #endregion

        /// <summary>
        /// Метод для удаления кратных рядом стоящих символов
        /// </summary>
        /// <param name="text">Исходный текст</param>
        /// <returns></returns>
        static string DeleteRepeat(string text)
        {
            for (int i = 1; i < text.Length; i++)
            {
                while (text[i - 1] == text[i])
                {
                    text = text.Remove(i, 1);
                    if (i >= text.Length) break;
                    //Console.WriteLine(text.Remove(i, 1));
                }
            }
            return text;
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
            string text = Console.ReadLine(); // Вводим текст

            //Проверка на пустоту строки, что она не null, не "" и не состоит только из пробелов
            while (String.IsNullOrWhiteSpace(text))
            {
                Console.WriteLine("Вы не ввели текст. Попробуйте снова: ");
                text = Console.ReadLine();
            }

            Console.WriteLine();
            string newText = DeleteRepeat(text); //Удаляем повторения

            Console.WriteLine("После удаления повторений: ");
            Console.WriteLine($"{text} >>> {newText}");

            Console.ReadKey();
        }
    }
}
