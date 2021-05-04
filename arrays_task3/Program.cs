using System;

namespace Homework_Module04_task3
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Описание задания 3

            // * Задание 3.1
            // Заказчику требуется приложение позволяющщее умножать математическую матрицу на число
            // Справка https://ru.wikipedia.org/wiki/Матрица_(математика)
            // Справка https://ru.wikipedia.org/wiki/Матрица_(математика)#Умножение_матрицы_на_число
            // Добавить возможность ввода количество строк и столцов матрицы и число,
            // на которое будет производиться умножение.
            // Матрицы заполняются автоматически. 
            // Если по введённым пользователем данным действие произвести невозможно - сообщить об этом
            //
            // Пример
            //
            //      |  1  3  5  |   |  5  15  25  |
            //  5 х |  4  5  7  | = | 20  25  35  |
            //      |  5  3  1  |   | 25  15   5  |
            //
            //
            // ** Задание 3.2
            // Заказчику требуется приложение позволяющщее складывать и вычитать математические матрицы
            // Справка https://ru.wikipedia.org/wiki/Матрица_(математика)
            // Справка https://ru.wikipedia.org/wiki/Матрица_(математика)#Сложение_матриц
            // Добавить возможность ввода количество строк и столцов матрицы.
            // Матрицы заполняются автоматически
            // Если по введённым пользователем данным действие произвести невозможно - сообщить об этом
            //
            // Пример
            //  |  1  3  5  |   |  1  3  4  |   |  2   6   9  |
            //  |  4  5  7  | + |  2  5  6  | = |  6  10  13  |
            //  |  5  3  1  |   |  3  6  7  |   |  8   9   8  |
            //  
            //  
            //  |  1  3  5  |   |  1  3  4  |   |  0   0   1  |
            //  |  4  5  7  | - |  2  5  6  | = |  2   0   1  |
            //  |  5  3  1  |   |  3  6  7  |   |  2  -3  -6  |
            //
            // *** Задание 3.3
            // Заказчику требуется приложение позволяющщее перемножать математические матрицы
            // Справка https://ru.wikipedia.org/wiki/Матрица_(математика)
            // Справка https://ru.wikipedia.org/wiki/Матрица_(математика)#Умножение_матриц
            // Добавить возможность ввода количество строк и столцов матрицы.
            // Матрицы заполняются автоматически
            // Если по введённым пользователем данным действие произвести нельзя - сообщить об этом
            //  
            //  |  1  3  5  |   |  1  3  4  |   | 22  48  57  |
            //  |  4  5  7  | х |  2  5  6  | = | 35  79  95  |
            //  |  5  3  1  |   |  3  6  7  |   | 14  36  45  |
            //
            //  
            //                  | 4 |   
            //  |  1  2  3  | х | 5 | = | 32 |
            //                  | 6 |  

            #endregion

            Console.SetCursorPosition(Console.WindowWidth / 2 - 20, 1);
            Console.WriteLine("Арифметические действия над матрицами \n");

            #region Объявление и создание матрицы

            Console.Write("Введите количество строк в матрице:");
            string rowStr = Console.ReadLine(); // Количество строк
            bool isNum = int.TryParse(rowStr, out int row);

            #region Проверка корректности ввода

            while (true)
            {
                if (!isNum)
                {
                    Console.Write($"Некорректные данные. Введите число: ");
                    rowStr = Console.ReadLine();
                    isNum = int.TryParse(rowStr, out row);
                }
                else
                {
                    if (row < 1)
                    {
                        Console.Write($"Некорректные данные. Введите положительное число: ");
                        rowStr = Console.ReadLine();
                        isNum = int.TryParse(rowStr, out row);
                    }
                    else break;
                }
            }

            #endregion

            Console.Write("Введите количество столбцов в матрице:");
            string colStr = Console.ReadLine(); // Количество столбцов
            isNum = int.TryParse(colStr, out int col);

            #region Проверка корректности ввода

            while (true)
            {
                if (!isNum)
                {
                    Console.Write($"Некорректные данные. Введите число: ");
                    colStr = Console.ReadLine();
                    isNum = int.TryParse(colStr, out col);
                }
                else
                {
                    if (col < 1)
                    {
                        Console.Write($"Некорректные данные. Введите положительное число: ");
                        colStr = Console.ReadLine();
                        isNum = int.TryParse(colStr, out col);
                    }
                    else break;
                }
            }

            #endregion

            Random random = new Random();
            int[,] matrix = new int[row, col]; // Инициализация исходного массива

            // Генерация и вывод исходной матрицы
            Console.WriteLine("Матрица: ");
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = random.Next(-10, 10);
                    Console.Write($"{matrix[i, j],3} ");
                }
                Console.WriteLine();
            }

            #endregion

            #region 3.1. Умножение матрицы на число

            Console.WriteLine("\nУмножение матрицы на число. \n");

            // Число на которое нужно умножить
            Console.Write("Введите число, на которое нужно умножить:");
            string numStr = Console.ReadLine();
            isNum = int.TryParse(numStr, out int num);

            #region Проверка корректности ввода

            while (true)
            {
                if (!isNum)
                {
                    Console.Write($"Некорректные данные. Введите число: ");
                    numStr = Console.ReadLine();
                    isNum = int.TryParse(numStr, out num);
                }
                else break;
            }

            #endregion

            // Умножение и вывод итоговой матрицы
            Console.WriteLine($"Матрица после умножения на {num}: ");
            int[,] numMultiMatrix = new int[row, col];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    numMultiMatrix[i, j] = num * matrix[i, j];
                    Console.Write($"{numMultiMatrix[i, j],3} ");
                }
                Console.WriteLine();
            }

            #endregion

            #region 3.2. Сложение и вычитание матриц

            #region Сложение матриц

            Console.WriteLine($"\nСложение матриц размерностью {row}x{col}. \n");

            int[,] plusMatrix = new int[row, col]; // Инициализация второй матрицы

            // Генерация и вывод матриц для сложения
            Console.WriteLine("Первое слагаемое: ");
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write($"{matrix[i, j],3} ");
                }
                Console.WriteLine();
            }
            Console.WriteLine("Второе слагаемое: ");
            for (int i = 0; i < plusMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < plusMatrix.GetLength(1); j++)
                {
                    plusMatrix[i, j] = random.Next(-10, 10);
                    Console.Write($"{plusMatrix[i, j],3} ");
                }
                Console.WriteLine();
            }
            // Сложение матриц
            Console.WriteLine("Сумма двух матриц: ");
            for (int i = 0; i < plusMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < plusMatrix.GetLength(1); j++)
                {
                    plusMatrix[i, j] += matrix[i, j];
                    Console.Write($"{plusMatrix[i, j],3} ");
                }
                Console.WriteLine();
            }

            #endregion

            #region Вычитание матриц

            Console.WriteLine($"\nВычитание матриц размерностью {row}x{col}. \n");

            int[,] minusMatrix = new int[row, col]; // Инициализация второй матрицы

            // Генерация и вывод матриц для вычитания
            Console.WriteLine("Уменьшаемое: ");
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write($"{matrix[i, j],3} ");
                }
                Console.WriteLine();
            }
            Console.WriteLine("Вычитаемое: ");
            for (int i = 0; i < minusMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < minusMatrix.GetLength(1); j++)
                {
                    minusMatrix[i, j] = random.Next(-10, 10);
                    Console.Write($"{minusMatrix[i, j],3} ");
                }
                Console.WriteLine();
            }
            // Вычитание матриц
            Console.WriteLine("Частное двух матриц: ");
            for (int i = 0; i < minusMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < minusMatrix.GetLength(1); j++)
                {
                    minusMatrix[i, j] = matrix[i, j] - minusMatrix[i, j];
                    Console.Write($"{minusMatrix[i, j],3} ");
                }
                Console.WriteLine();
            }

            #endregion

            #endregion

            #region 3.3. Умножение матриц

            Console.WriteLine($"\nУмножение матриц \n");

            // Вывод первой матрицы
            Console.WriteLine("Первый множитель множитель: ");
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write($"{matrix[i, j],3} ");
                }
                Console.WriteLine();
            }

            #region Генерация новой матрицы

            Console.Write($"Введите количество строк во второй матрице:");
            string secondRowStr = Console.ReadLine(); // Количество строк
            isNum = int.TryParse(secondRowStr, out int secondRow);

            #region Проверка корректности ввода

            while (true)
            {
                if (!isNum)
                {
                    Console.Write($"Некорректные данные. Введите число: ");
                    secondRowStr = Console.ReadLine();
                    isNum = int.TryParse(secondRowStr, out secondRow);
                }
                else
                {
                    if (secondRow != col)
                    {
                        Console.Write($"Некорректные данные. Введите число равное количеству стоблцов первой матрицы: ");
                        secondRowStr = Console.ReadLine();
                        isNum = int.TryParse(secondRowStr, out secondRow);
                    }
                    else break;
                }
            }

            #endregion

            Console.Write("Введите количество столбцов в матрице:");
            string secondColStr = Console.ReadLine(); // Количество столбцов
            isNum = int.TryParse(secondColStr, out int secondCol);

            #region Проверка корректности ввода

            while (true)
            {
                if (!isNum)
                {
                    Console.Write($"Некорректные данные. Введите число: ");
                    secondColStr = Console.ReadLine();
                    isNum = int.TryParse(secondColStr, out secondCol);
                }
                else
                {
                    if (secondCol < 1)
                    {
                        Console.Write($"Некорректные данные. Введите положительное число: ");
                        secondColStr = Console.ReadLine();
                        isNum = int.TryParse(secondColStr, out secondCol);
                    }
                    else break;
                }
            }

            #endregion

            int[,] multiMatrix = new int[secondRow, secondCol]; // Инициализация второй матрицы

            // Генерация и вывод второй матрицы
            Console.WriteLine("Второй множитель: ");
            for (int i = 0; i < multiMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < multiMatrix.GetLength(1); j++)
                {
                    multiMatrix[i, j] = random.Next(-10, 10);
                    Console.Write($"{multiMatrix[i, j],3} ");
                }
                Console.WriteLine();
            }

            #endregion

            int[,] resMultiMatrix = new int[row, secondCol]; // Инициализация матрицы для произведения

            //Умножение двух матриц
            for (int i = 0; i < resMultiMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < resMultiMatrix.GetLength(1); j++)
                {
                    int sum = 0;
                    for (int r = 0; r < matrix.GetLength(1); r++)
                    {
                        sum += matrix[i, r] * multiMatrix[r, j];
                    }
                    resMultiMatrix[i, j] = sum;
                }
            }

            // Вывод произведения
            Console.WriteLine("Произведение матриц: ");
            for (int i = 0; i < resMultiMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < resMultiMatrix.GetLength(1); j++)
                {
                    Console.Write($"{resMultiMatrix[i, j],3} ");
                }
                Console.WriteLine();
            }

            #endregion

            Console.ReadKey();
        }
    }
}
