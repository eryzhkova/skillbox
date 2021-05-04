using System;

namespace Homework_Module04_task2
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Описание задания 2

            // * Задание 2
            // Заказчику требуется приложение строящее первых N строк треугольника паскаля. N < 25
            // 
            // При N = 9. Треугольник выглядит следующим образом:
            //                                 1
            //                             1       1
            //                         1       2       1
            //                     1       3       3       1
            //                 1       4       6       4       1
            //             1       5      10      10       5       1
            //         1       6      15      20      15       6       1
            //     1       7      21      35      35       21      7       1
            //                                                              
            //                                                              
            // Простое решение:                                                             
            // 1
            // 1       1
            // 1       2       1
            // 1       3       3       1
            // 1       4       6       4       1
            // 1       5      10      10       5       1
            // 1       6      15      20      15       6       1
            // 1       7      21      35      35       21      7       1
            // 
            // Справка: https://ru.wikipedia.org/wiki/Треугольник_Паскаля

            #endregion

            Console.SetCursorPosition(Console.WindowWidth / 2 - 15, 1);
            Console.WriteLine("Треугольник Паскаля \n");

            Console.Write("Сколько строк треугольника Паскаля построить? (N < 25) ");
            string nStr = Console.ReadLine(); // Количество строк
            bool isNum = int.TryParse(nStr, out int n);

            #region Проверка корректности ввода

            while (true)
            {
                if (!isNum)
                {
                    Console.Write($"Некорректные данные. Введите число: ");
                    nStr = Console.ReadLine();
                    isNum = int.TryParse(nStr, out n);
                }
                else
                {
                    if (n < 1 || n >= 25)
                    {
                        Console.Write($"Некорректные данные. Введите число больше 1 и меньше 25: ");
                        nStr = Console.ReadLine();
                        isNum = int.TryParse(nStr, out n);
                    }
                    else break;
                }
            }

            #endregion

            int[][] trianglePascal = new int[n][];

            // Создание треугольника
            // В первой и второй строке всегда единицы
            trianglePascal[0] = new int[1];
            trianglePascal[0][0] = 1;
            if (n >= 2)
            {
                trianglePascal[1] = new int[2];
                trianglePascal[1][0] = 1;
                trianglePascal[1][1] = 1;
                // Начиная со второй строки вычисляем значиния
                for (int i = 2; i < trianglePascal.Length; i++)
                {
                    trianglePascal[i] = new int[i + 1]; // Инициализация массива
                    trianglePascal[i][0] = 1; // Первый элемент в строке = 1
                    trianglePascal[i][i] = 1; // Последний элемент в строке = 1

                    // Создание массива для строки
                    for (int j = 1; j < trianglePascal[i].Length - 1; j++)
                    {
                        trianglePascal[i][j] = trianglePascal[i - 1][j - 1] + trianglePascal[i - 1][j];
                    }
                }
            }

            // Красивый вывод треугольника Паскаля
            Console.WriteLine("Треугольника Паскаля: ");
            for (int i = 0; i < trianglePascal.Length; i++)
            {
                for (int j = 0; j < trianglePascal[n - 1 - i].Length; j++)
                {
                    Console.Write("{0,3}", " ");
                }
                for (int j = 0; j < trianglePascal[i].Length; j++)
                {
                    Console.Write($"{trianglePascal[i][j],6}");
                }
                Console.WriteLine();
            }

            Console.WriteLine("\nПростой вывод треугольника Паскаля: ");
            for (int i = 0; i < trianglePascal.Length; i++)
            {
                for (int j = 0; j < trianglePascal[i].Length; j++)
                {
                    Console.Write($"{trianglePascal[i][j],6}");
                }
                Console.WriteLine();
            }

            Console.ReadKey();
        }
    }
}
