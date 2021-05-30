using System;

namespace progressions
{
    class Program
    {
        #region Описание задания 4

        // Задание 4. Написать метод принимающий некоторое количесво чисел, выяснить
        // является заданная последовательность элементами арифметической или геометрической прогрессии
        // 
        // Примечание
        //             http://ru.wikipedia.org/wiki/Арифметическая_прогрессия
        //             http://ru.wikipedia.org/wiki/Геометрическая_прогрессия

        #endregion

        /// <summary>
        /// Метод для проверки корректности ввода чисел
        /// </summary>
        /// <param name="str">Не конвертированная введенная строка с числом</param>
        /// <param name="negative">Отображает может ли быть число отрицательным</param>
        /// <returns></returns>
        static double CheckNumber(string str)
        {
            bool isNum = double.TryParse(str, out double num);
            while (true)
            {
                if (!isNum)
                {
                    Console.Write($"Некорректные данные. Введите число: ");
                    str = Console.ReadLine();
                    isNum = double.TryParse(str, out num);
                }
                else return num;
            }
        }

        /// <summary>
        /// Метод для определения является ли исходная последовательность арифметической прогрессией
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
        static bool CheckArithProgression(double[] array)
        {
            double d = Math.Round(array[1] - array[0], 2);
            bool isProgress = true;

            for (int i = 1; i < array.Length; i++)
            {
                isProgress &= Math.Round(array[i] - array[i - 1], 2) == d;
            }
            if (isProgress) Console.WriteLine($"Разность d: {d}");
            return isProgress;
        }

        /// <summary>
        /// Метод для определения является ли исходная последовательность геометрической прогрессией
        /// </summary>
        /// <param name="array">Исходная последовательность</param>
        /// <returns></returns>
        static bool CheckGeomProgression(double[] array)
        {
            if (array[0] == 0 || array[1] == 0) return false;
            double q = Math.Round(array[1] / array[0], 2);
            bool isProgress = true;

            for (int i = 1; i < array.Length; i++)
            {
                if (array[i - 1] == 0) return false;
                isProgress &= (Math.Round(array[i] / array[i - 1], 2) == q);
            }
            if (isProgress) Console.WriteLine($"Знаменатель q: {q}");
            return isProgress;
        }

        /// <summary>
        /// Метод, с которого начинается выполнение
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Console.SetCursorPosition(Console.WindowWidth / 2 - 20, 1);
            Console.WriteLine("Анализатор чисел \n");

            Console.WriteLine("Введите последовательность чисел через пробел: ");

            string numsStr = Console.ReadLine(); // Вводим последовательность
            // Массив разделителей (постаралась выделить побольше, но не все)
            char[] symb = new char[] { ' ', '/', '\\', '|', '>', '<', '?', '!', '#', '+' };
            string[] nums = numsStr.Split(symb, StringSplitOptions.RemoveEmptyEntries); // Массив чисел из текста

            // Проверка на пустоту строки, что она не null, не "" и не состоит только из разделителей
            while (String.IsNullOrWhiteSpace(numsStr) || nums.Length == 0)
            {
                Console.WriteLine("Вы не ввели последовательность. Попробуйте снова ???: ");
                numsStr = Console.ReadLine();
                nums = numsStr.Split(symb, StringSplitOptions.RemoveEmptyEntries);
            }

            double[] numArray = new double[nums.Length]; //Сама последовательность
            for (int i = 0; i < nums.Length; i++)
            {
                numArray[i] = CheckNumber(nums[i]); // Конвертируем
            }

            Console.Write("Исходная последовательность: ");
            for (int i = 0; i < numArray.Length; i++)
            {
                Console.Write($"{numArray[i]} ");
            }

            Console.WriteLine();

            // Если массив из менее чем двух чисел, то это никакая прогрессия 
            if (numArray.Length > 2)
            {
                if (CheckArithProgression(numArray))
                    Console.WriteLine("Эта последовательность является арифметической прогрессией!");
                else if (CheckGeomProgression(numArray))
                    Console.WriteLine("Эта последовательность является геометрической прогрессией!");
                else Console.WriteLine("Эта последовательность не является ни арифметической прогрессией, ни геометрической прогрессией!");
            }
            else
            {
                Console.WriteLine("Эта последовательность не является ни арифметической прогрессией, ни геометрической прогрессией!");
            }

            Console.ReadKey();
        }
    }
}
