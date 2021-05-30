using System;

namespace recursion
{
    class Program
    {
        #region Описание задания 5

        // Задание 5
        // Вычислить, используя рекурсию, функцию Аккермана:
        // A(2, 5), A(1, 2)
        // A(n, m) = m + 1, если n = 0,
        //         = A(n - 1, 1), если n <> 0, m = 0,
        //         = A(n - 1, A(n, m - 1)), если n> 0, m > 0.

        #endregion

        /// <summary>
        /// Метод для проверки корректности ввода чисел
        /// </summary>
        /// <param name="str">Не конвертированная введенная строка с числом</param>
        /// <param name="negative">Отображает может ли быть число отрицательным</param>
        /// <returns></returns>
        static int CheckNumber(string str)
        {
            bool isNum = int.TryParse(str, out int num);
            while (true)
            {
                if (!isNum)
                {
                    Console.Write($"Некорректные данные. Введите число: ");
                    str = Console.ReadLine();
                    isNum = int.TryParse(str, out num);
                }
                else if (num < 0)
                {
                    Console.Write($"Некорректные данные. Введите положительное число: ");
                    str = Console.ReadLine();
                    isNum = int.TryParse(str, out num);
                }
                else return num;
            }
        }

        /// <summary>
        /// Метод, для вычисления значения функции Аккермана
        /// </summary>
        /// <param name="n">Первый параметр</param>
        /// <param name="m">Второй параметр</param>
        /// <returns></returns>
        static int AkkerFunc(int n, int m)
        {
            if (n == 0) return m + 1;
            if (m == 0) return AkkerFunc(n - 1, 1);
            return AkkerFunc(n - 1, AkkerFunc(n, m - 1));
        }

        /// <summary>
        /// Метод, с которого начинается выполнение программы
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Console.SetCursorPosition(Console.WindowWidth / 2 - 20, 1);
            Console.WriteLine("Вычисление функции Аккермана \n");

            // Вывод для задания
            Console.WriteLine($"A(2, 5) = {AkkerFunc(2, 5)}");
            Console.WriteLine($"A(1, 2) = {AkkerFunc(1, 2)}");

            #region Делаем приложение универсальным

            Console.Write("\nВведите n: ");
            string nStr = Console.ReadLine();   // n
            int n = CheckNumber(nStr);          // Проверяем корректность ввода

            Console.Write("Введите m: ");
            string mStr = Console.ReadLine();   // m
            int m = CheckNumber(mStr);          // Проверяем корректность ввода

            Console.WriteLine($"A({n}, {m}) = {AkkerFunc(n, m)}\n");

            #endregion

            Console.ReadKey();
        }
    }
}
