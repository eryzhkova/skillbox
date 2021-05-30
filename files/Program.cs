using System;
using System.IO;
using System.IO.Compression;
using System.Text;


namespace files
{
    class Program
    {
        #region Описание задания

        /// Домашнее задание
        ///
        /// Группа начинающих программистов решила поучаствовать в хакатоне с целью демонстрации
        /// своих навыков. 
        /// 
        /// Немного подумав они вспомнили, что не так давно на занятиях по математике
        /// они проходили тему "свойства делимости целых чисел". На этом занятии преподаватель показывал
        /// пример с использованием фактов делимости. 
        /// Пример заключался в следующем: 
        /// Написав на доске все числа от 1 до N, N = 50, преподаватель разделил числа на несколько групп
        /// так, что если одно число делится на другое, то эти числа попадают в разные руппы. 
        /// В результате этого разбиения получилось M групп, для N = 50, M = 6
        /// 
        /// N = 50
        /// Группы получились такими: 
        /// 
        /// Группа 1: 1
        /// Группа 2: 2 3 5 7 11 13 17 19 23 29 31 37 41 43 47
        /// Группа 3: 4 6 9 10 14 15 21 22 25 26 33 34 35 38 39 46 49
        /// Группа 4: 8 12 18 20 27 28 30 42 44 45 50
        /// Группа 5: 16 24 36 40
        /// Группа 6: 32 48
        /// 
        /// M = 6
        /// 
        /// ===========
        /// 
        /// N = 10
        /// Группы получились такими: 
        /// 
        /// Группа 1: 1
        /// Группа 2: 2 7 9
        /// Группа 3: 3 4 10
        /// Группа 4: 5 6 8
        /// 
        /// M = 4
        /// 
        /// Участники хакатона решили эту задачу, добавив в неё следующие возможности:
        /// 1. Программа считыват из файла (путь к которому можно указать) некоторое N, 
        ///    для которого нужно подсчитать количество групп
        ///    Программа работает с числами N не превосходящими 1 000 000 000
        ///   
        /// 2. В ней есть два режима работы:
        ///   2.1. Первый - в консоли показывается только количество групп, т е значение M
        ///   2.2. Второй - программа получает заполненные группы и записывает их в файл используя один из
        ///                 вариантов работы с файлами
        ///            
        /// 3. После выполения пунктов 2.1 или 2.2 в консоли отображается время, за которое был выдан результат 
        ///    в секундах и миллисекундах
        /// 
        /// 4. После выполнения пунта 2.2 программа предлагает заархивировать данные и если пользователь соглашается -
        /// делает это.
        /// 
        /// Попробуйте составить конкуренцию начинающим программистам и решить предложенную задачу
        /// (добавление новых возможностей не возбраняется)
        ///
        /// * При выполнении текущего задания, необходимо документировать код 
        ///   Как пометками, так и xml документацией
        ///   В обязательном порядке создать несколько собственных методов
        ///   кол-во групп - двоичный логарифм от N (целое число)
        ///   группы: два цикла - один пробегается по всему массиву, второй только по половине от проверяемого числа)


        #endregion

        /// <summary>
        /// Метод для архивирорания файла сданными
        /// </summary>
        /// <param name="N">Исходный файл</param>
        static void zipData(string source)
        {
            string compressed = "groups.zip";
            using (FileStream sourceFile = new FileStream(String.Concat(source, ".gz"), FileMode.OpenOrCreate))
            {
                using (FileStream ts = File.Create(compressed))   //поток для записи сжатого файла
                {
                    // поток архивации
                    using (GZipStream compFile = new GZipStream(ts, CompressionMode.Compress))
                    {
                        sourceFile.CopyTo(compFile); // копируем байты из одного потока в другой
                        Console.WriteLine($"Сжатие файла {source} завершено. Было: {sourceFile.Length}  стало: {ts.Length}.");
                        Console.WriteLine($"Название архива: {compressed}");
                    }
                }
            }
        }

        /// <summary>
        /// Метод для подсчета количества групп, которые можно разделить N-чисел
        /// </summary>
        /// <param name="N">Количество чисел</param>
        static void FirstGameMode(int N)
        {
            DateTime date = DateTime.Now;
            double M = Math.Truncate(Math.Log2(N));
            Console.WriteLine($"Количество групп: {M + 1} ");
            TimeSpan ts = DateTime.Now.Subtract(date);
            Console.WriteLine($"Время, потраченное на выполнение: {ts.TotalSeconds}");
        }

        /// <summary>
        /// Метод для разбиения N-чисел по группам
        /// </summary>
        /// <param name="N">Количество чисел</param>
        static void SecondGameMode(int N)
        {
            DateTime date = DateTime.Now;

            int M = (int)Math.Truncate(Math.Log2(N)) + 1;
            string[] groups = new string[M - 1];

            //заполнение первыми элементами
            for (int i = 0; i < groups.Length; i++)
            {
                groups[i] = $"{Math.Pow(2, i + 1)}";
            }

            //основное заполнение групп
            for (int i = 3; i <= N; i++)
            {
                int j = 0;
                while (j < groups.Length)
                {
                    string[] group = groups[j].Split(' ');
                    int k = 0;
                    while (k < group.Length)
                    {
                        if (i % Convert.ToInt32(group[k]) == 0 || i < Convert.ToInt32(group[k]))
                        {
                            k = group.Length;
                            j++;
                        }
                        else if (i == Convert.ToInt32(group[k]))
                        {
                            k = group.Length;
                            j = groups.Length;
                        }
                        else if (Convert.ToInt32(group[k]) > i / 2)
                        {
                            groups[j] = string.Concat(groups[j], $" {i}");
                            j = groups.Length;
                            k = group.Length;
                        }
                        else k++;
                    }
                }
            }

            string source = "groups.csv";
            using (StreamWriter file = new StreamWriter(source, false, Encoding.Unicode))
            {
                file.WriteLine($"Количество чисел: {N}");
                file.WriteLine($"Количество групп: {M}");
                file.WriteLine("Группы получились такими:");
                file.WriteLine("Группа 1: 1");
                for (int i = 0; i < groups.Length; i++)
                {
                    file.WriteLine($"Группа {i + 2}: {groups[i]}");
                }
            }

            Console.WriteLine($"Данные записы в файл {source}. Количество получившихся групп: {M}.");
            TimeSpan ts = DateTime.Now.Subtract(date);
            Console.WriteLine($"Время, потраченное на выполнение: {ts.TotalSeconds}.");

            Console.WriteLine("Хотите заархивировать данные? ");
            Console.WriteLine("(1) Да");
            Console.WriteLine("(2) Нет");
            Console.Write("Ваш выбор? (1/2) ");
            string user = Console.ReadLine();
            if (user == "1") zipData(source);
            else Console.WriteLine("Завершение программы.");

        }

        /// <summary>
        /// Метод для разбиения N-чисел по группам с моментальной записью в файл
        /// </summary>
        /// <param name="N">Количество чисел</param>
        static void SecondGameMode_V2(int N)
        {
            DateTime date = DateTime.Now;

            int M = (int)Math.Truncate(Math.Log2(N)) + 1;
            string[] groups = new string[M - 1];

            string source = "groups.csv";
            using (StreamWriter file = new StreamWriter(source, true, Encoding.Unicode))
            {
                file.WriteLine($"Количество чисел: {N}");
                file.WriteLine($"Количество групп: {M}");
                file.WriteLine("Группы получились такими:");

                int currentNum = N;

                for (int i = groups.Length - 1; i >= 0; i--)
                {
                    file.Write($"Группа {i + 2}:");
                    for (int j = currentNum / 2 + 1; j <= currentNum; j++)
                    {
                        file.Write($" {j}");
                    }
                    currentNum /= 2;
                    file.WriteLine();
                }

                file.WriteLine("Группа 1: 1");
            }

            Console.WriteLine($"Данные записы в файл {source}. Количество получившихся групп: {M}.");
            TimeSpan ts = DateTime.Now.Subtract(date);
            Console.WriteLine($"Время, потраченное на выполнение: {ts.TotalSeconds}.");

            Console.WriteLine("Хотите заархивировать данные? ");
            Console.WriteLine("(1) Да");
            Console.WriteLine("(2) Нет");
            Console.Write("Ваш выбор? (1/2) ");
            string user = Console.ReadLine();
            if (user == "1") zipData(source);
            else Console.WriteLine("Завершение программы.");
        }

        static void Main(string[] args)
        {
            int N;

            StreamReader file = new StreamReader("file.txt");

            bool isNum = int.TryParse(file.ReadLine(), out int num);

            if (!isNum)
            {
                Console.Write($"Некорректные данные. Должно быть число число.");
                return;
            }
            else if (num < 2 || num > 1_000_000_000)
            {
                Console.Write($"Некорректные данные. Должно быть положительное число и меньше 1 000 000 000.");
                return;
            }
            else
            {
                N = num;
                Console.WriteLine($"Количество чисел от 1 до {N}");
            }

            file.Close();

            Console.WriteLine("В каком режиме хотите работать: ");
            Console.WriteLine("(1) Первый - в консоли показывается только количество групп;");
            Console.WriteLine("(2) Второй - программа получает заполненные группы и записывает их в файл;");
            Console.Write("Ваш выбор? (1/2) ");
            string gamemode = Console.ReadLine();
            switch (gamemode)
            {
                case "1":
                    FirstGameMode(N);
                    break;

                case "2":
                    SecondGameMode_V2(N);
                    break;
                default:
                    Console.WriteLine("Некорректные данные");
                    break;

            }
            Console.ReadLine();

        }
    }
}
