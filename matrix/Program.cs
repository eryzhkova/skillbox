using System;

namespace matrix
{
    class Program
    {
        #region Описание задания 1

        // Задание 1.
        // Воспользовавшись решением задания 3 четвертого модуля
        // 1.1. Создать метод, принимающий число и матрицу, возвращающий матрицу умноженную на число
        // 1.2. Создать метод, принимающий две матрицы, возвращающий их сумму
        // 1.3. Создать метод, принимающий две матрицы, возвращающий их произведение

        #endregion


        /// <summary>
        /// Метод для проверки корректности ввода чисел
        /// </summary>
        /// <param name="str">Не конвертированная введенная строка с числом</param>
        /// <param name="negative">Отображает может ли быть число отрицательным</param>
        /// <returns></returns>
        static int CheckNumber(string str, bool negative)
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
                else if (num < 1 && !negative)
                {
                    Console.Write($"Некорректные данные. Введите положительное число: ");
                    str = Console.ReadLine();
                    isNum = int.TryParse(str, out num);
                }
                else return num;
            }
        }

        /// <summary>
        /// Метод для заполнения матрицы
        /// </summary>
        /// <param name="row">Количество строк</param>
        /// <param name="col">Количество столбцов</param>
        /// <returns></returns>
        static int[,] CreateMatrix(int row, int col)
        {
            Random random = new Random();
            int[,] matrix = new int[row, col];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = random.Next(-10, 10);
                }
                Console.WriteLine();
            }
            return matrix;
        }

        /// <summary>
        /// Метод для умножения матрицы на число
        /// </summary>
        /// <param name="matrix">Матрица</param>
        /// <param name="num">Число, на которое умножаем</param>
        static void MultiMatrixToNum(int[,] matrix, int num)
        {
            int row = matrix.GetLength(0);
            int col = matrix.GetLength(1);

            Console.WriteLine($"Матрица после умножения на {num}: ");
            int[,] numMultiMatrix = new int[row, col];
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    numMultiMatrix[i, j] = num * matrix[i, j];
                    Console.Write($"{numMultiMatrix[i, j],5} ");
                }
                Console.WriteLine();
            }
        }

        /// <summary>
        /// Метод для печати матрицы
        /// </summary>
        /// <param name="matrix">Матрица</param>
        /// <param name="matrixStr">Текст описывающий матрицу</param>
        static void PrintMatrix(int[,] matrix, string matrixStr)
        {
            Console.WriteLine($"{matrixStr}: ");
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write($"{matrix[i, j],5} ");
                }
                Console.WriteLine();
            }
        }

        /// <summary>
        ///  Метод для сложения двух матриц, результат записывается во второе слагаемое
        /// </summary>
        /// <param name="firstMatrix">Первое слагаемое-матрица</param>
        /// <param name="secondMatrix">Второе слагаемое-матрица</param>
        static void SummaMatrix(int[,] firstMatrix, int[,] secondMatrix)
        {
            Console.WriteLine("Сумма двух матриц: ");
            for (int i = 0; i < firstMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < firstMatrix.GetLength(1); j++)
                {
                    secondMatrix[i, j] += firstMatrix[i, j];
                    Console.Write($"{secondMatrix[i, j],5} ");
                }
                Console.WriteLine();
            }
        }

        /// <summary>
        /// Метод для вычитания двух матриц, результат записывается во второе слагаемое
        /// </summary>
        /// <param name="firstMatrix">Уменьшаемое - первая матрица</param>
        /// <param name="secondMatrix">Вычитаемое - вторая матрица</param>
        static void SubtractMatrix(int[,] firstMatrix, int[,] secondMatrix)
        {
            Console.WriteLine("Частное двух матриц: ");
            for (int i = 0; i < firstMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < firstMatrix.GetLength(1); j++)
                {
                    secondMatrix[i, j] = firstMatrix[i, j] - secondMatrix[i, j];
                    Console.Write($"{secondMatrix[i, j],5} ");
                }
                Console.WriteLine();
            }
        }

        /// <summary>
        /// Метод для умножения двух матриц, результат записывается в отдельную матрицу
        /// </summary>
        /// <param name="firstMatrix">Первый множитель - матрица</param>
        /// <param name="secondMatrix">Второй множитель - матрица</param>
        static void MultiMatrix(int[,] firstMatrix, int[,] secondMatrix)
        {
            int row = firstMatrix.GetLength(0);   // Строки для матрицы результата
            int col = secondMatrix.GetLength(1);  // Столбцы для матрицы результата
            int[,] resMultiMatrix = new int[row, col];

            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    int sum = 0;
                    for (int r = 0; r < firstMatrix.GetLength(1); r++)
                    {
                        sum += firstMatrix[i, r] * secondMatrix[r, j];
                    }
                    resMultiMatrix[i, j] = sum;
                }
            }
            //Вывод
            PrintMatrix(resMultiMatrix, "Произведение матриц");
        }

        /// <summary>
        /// Главный метод, с которого начинается выполнение программы
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Console.SetCursorPosition(Console.WindowWidth / 2 - 20, 1);
            Console.WriteLine("Арифметические действия над матрицами \n");

            Console.Write("Введите количество строк в матрице:");
            string rowStr = Console.ReadLine();        // Количество строк
            int row = CheckNumber(rowStr, false);      // Проверяем корректность ввода

            Console.Write("Введите количество столбцов в матрице:");
            string colStr = Console.ReadLine();        // Количество столбцов
            int col = CheckNumber(colStr, false);      // Проверяем корректность ввода

            int[,] mainMatrix = CreateMatrix(row, col);
            PrintMatrix(mainMatrix, "Исходная матрица");

            #region Умножение матрицы на число
            Console.WriteLine("\nУмножение матрицы на число. \n");

            // Число на которое нужно умножить
            Console.Write("Введите число, на которое нужно умножить:");
            string numStr = Console.ReadLine();    // Число, на которое умножаем
            int num = CheckNumber(numStr, true);   // Проверяем корректность ввода

            MultiMatrixToNum(mainMatrix, num);
            #endregion

            #region Сложение матриц

            Console.WriteLine($"\nСложение матриц размерностью {row}x{col}.");

            int[,] plusMatrix = CreateMatrix(row, col);
            PrintMatrix(mainMatrix, "Первое слагаемое");
            PrintMatrix(plusMatrix, "Второе слагаемое");

            SummaMatrix(mainMatrix, plusMatrix);

            #endregion

            #region Вычитание матриц

            Console.WriteLine($"\nВычитание матриц размерностью {row}x{col}.");

            int[,] minusMatrix = CreateMatrix(row, col);
            PrintMatrix(mainMatrix, "Уменьшаемое");
            PrintMatrix(minusMatrix, "Вычитаемое");

            SubtractMatrix(mainMatrix, minusMatrix);

            #endregion

            #region Умножение матриц

            Console.WriteLine("\nУмножение матриц.");

            Console.Write("Введите количество строк во второй матрице: ");
            string secondRowStr = Console.ReadLine();         // Количество строк во второй матрице (должно быть равно столбцам первой)
            int secondRow = CheckNumber(secondRowStr, false); // Проверяем корректность ввода

            // Проверка на соответствие правилам
            while (true)
            {
                if (secondRow != col)
                {
                    Console.Write($"Некорректные данные. Введите число равное количеству стоблцов первой матрицы: ");
                    secondRowStr = Console.ReadLine();
                    secondRow = CheckNumber(secondRowStr, false);
                }
                else break;
            }

            Console.Write("Введите количество столбцов в матрице: ");
            string secondColStr = Console.ReadLine();          // Количество столбцов
            int secondCol = CheckNumber(secondColStr, false);  // Проверяем корректность ввода

            int[,] multiMatrix = CreateMatrix(secondRow, secondCol); // Инициализация второй матрицы

            PrintMatrix(mainMatrix, "Первый множитель");
            PrintMatrix(multiMatrix, "Второй множитель");

            MultiMatrix(mainMatrix, multiMatrix);

            #endregion

            Console.ReadKey();

        }
    }
}
