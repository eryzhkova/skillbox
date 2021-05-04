using System;

namespace Homework_Task2_Module03
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Описание задания

            // Просматривая сайты по поиску работы, у вас вызывает интерес следующая вакансия:

            // Требуемый опыт работы: без опыта
            // Частичная занятость, удалённая работа
            //
            // Описание 
            //
            // Стартап «Micarosppoftle» занимающийся разработкой
            // многопользовательских игр ищет разработчиков в свою команду.
            // Компания готова рассмотреть C#-программистов не имеющих опыта в разработке, 
            // но желающих развиваться в сфере разработки игр на платформе .NET.
            //
            // Должность Интерн C#/
            //
            // Основные требования:
            // C#, операторы ввода и вывода данных, управляющие конструкции 
            // 
            // Конкурентным преимуществом будет знание процедурного программирования.
            //
            // Не технические требования: 
            // английский на уровне понимания документации и справочных материалов
            //
            // В качестве тестового задания предлагается решить следующую задачу.
            //
            // Написать игру, в которою могут играть два игрока.
            // При старте, игрокам предлагается ввести свои никнеймы.
            // Никнеймы хранятся до конца игры.
            // Программа загадывает случайное число gameNumber от 12 до 120 сообщая это число игрокам.
            // Игроки ходят по очереди(игра сообщает о ходе текущего игрока)
            // Игрок, ход которого указан вводит число userTry, которое может принимать значения 1, 2, 3 или 4,
            // введенное число вычитается из gameNumber
            // Новое значение gameNumber показывается игрокам на экране.
            // Выигрывает тот игрок, после чьего хода gameNumber обратилась в ноль.
            // Игра поздравляет победителя, предлагая сыграть реванш

            // * Бонус:
            // Подумать над возможностью реализации разных уровней сложности.
            // В качестве уровней сложности может выступать настраиваемое, в начале игры,
            // значение userTry, изменение диапазона gameNumber, или указание большего количества игроков (3, 4, 5...)
            // *** Сложный бонус
            // Подумать над возможностью реализации однопользовательской игры
            // т е игрок должен играть с компьютером

            #endregion

            Console.SetCursorPosition(Console.WindowWidth / 2 - 20, 0);
            Console.WriteLine("Загадай число и выиграй!");

            #region Начальная настройка игры

            Console.SetCursorPosition(Console.WindowWidth / 2 - 15, 2);
            Console.WriteLine("Настройка игры.");

            // Настройка числа игроков
            Console.Write("Сколько игроков будет играть? (от 1 до 4) ");

            string playersStr = Console.ReadLine(); //Число от игрока в виде строки
            bool isNum = int.TryParse(playersStr, out int players); // players - количество игроков

            #region Проверка на корректность ввода количества игроков

            while (true)
            {
                if (!isNum)
                {
                    Console.Write($"Некорректные данные. Введите число игроков от 1 до 4: ");
                    playersStr = Console.ReadLine();
                    isNum = int.TryParse(playersStr, out players);
                }
                else
                {
                    if (players > 4 || players < 1)
                    {
                        Console.Write($"Некорректные данные. Игроков может быть от 1 до 4: ");
                        playersStr = Console.ReadLine();
                        isNum = int.TryParse(playersStr, out players);
                    }
                    else break;
                }
            }

            #endregion

            // Объявление переменный для игроков
            string firstPlayer = "", secondPlayer = "", thirdPlayer = "", fourthPlayer = "";

            // Настройка диапозона gameNumber
            Console.Write("Случайное число будет загадано от (мин 12): ");
            string gameNumberMinStr = Console.ReadLine(); //Число от игрока в виде строки
            isNum = int.TryParse(gameNumberMinStr, out int gameNumberMin); // gameNumberMin - минимальное случайное

            #region Проверка на корректность ввода минимального случайного для gameNumber

            while (true)
            {
                if (!isNum)
                {
                    Console.Write($"Некорректные данные. Введите число больше или равно 12: ");
                    gameNumberMinStr = Console.ReadLine();
                    isNum = int.TryParse(gameNumberMinStr, out gameNumberMin);
                }
                else
                {
                    if (gameNumberMin < 12)
                    {
                        Console.Write($"Некорректные данные. Введите число больше или равно 12: ");
                        gameNumberMinStr = Console.ReadLine();
                        isNum = int.TryParse(gameNumberMinStr, out gameNumberMin);
                    }
                    else break;
                }
            }

            #endregion

            Console.Write("До: ");
            string gameNumberMaxStr = Console.ReadLine(); //Число от игрока в виде строки
            isNum = int.TryParse(gameNumberMaxStr, out int gameNumberMax); // gameNumberMax - максмимальное случайное

            #region Проверка на корректность ввода максимального случайного для gameNumber

            while (true)
            {
                if (!isNum)
                {
                    Console.Write($"Некорректные данные. Введите число ДО: ");
                    gameNumberMaxStr = Console.ReadLine();
                    isNum = int.TryParse(gameNumberMaxStr, out gameNumberMax);
                }
                else
                {
                    if (gameNumberMax <= gameNumberMin)
                    {
                        Console.Write($"Некорректные данные. Введите число больше минимального: ");
                        gameNumberMaxStr = Console.ReadLine();
                        isNum = int.TryParse(gameNumberMaxStr, out gameNumberMax);
                    }
                    else break;
                }
            }

            #endregion

            // Настройка диапозона userTry
            Console.Write("Максимальное количество чисел (от 2 до 8): ");
            string userTryMaxStr = Console.ReadLine(); //Число от игрока в виде строки
            isNum = int.TryParse(userTryMaxStr, out int userTryMax); // userTryMax - максимальное для чисел для игроков

            #region Проверка на корректность ввода минимального случайного для userTryMax

            while (true)
            {
                if (!isNum)
                {
                    Console.Write($"Некорректные данные. Введите число (от 2 до 8): ");
                    userTryMaxStr = Console.ReadLine();
                    isNum = int.TryParse(userTryMaxStr, out userTryMax);
                }
                else
                {
                    if (userTryMax > 8 || userTryMax < 2)
                    {
                        Console.Write($"Некорректные данные. Введите число от 2 до 8: ");
                        userTryMaxStr = Console.ReadLine();
                        isNum = int.TryParse(userTryMaxStr, out userTryMax);
                    }
                    else break;
                }
            }

            #endregion


            int userTry; // Объеявление userTry

            string playerName = ""; // Для реализации корректного вывода никнеймов
            int playNow = 1; // Для определения того, кто ходит в данный момент
            bool flag = true; // Для реализации игры с компьютером

            #endregion

            #region Ввод никнеймов и генерация случайного числа gameNumber

            // Ввод никнеймов
            Console.WriteLine("Введите Ваши никнеймы.");
            if (players >= 1)
            {
                Console.Write("Первый игрок: ");
                firstPlayer = Console.ReadLine();
                if (players >= 2)
                {
                    Console.Write("Второй игрок: ");
                    secondPlayer = Console.ReadLine();
                    if (players >= 3)
                    {
                        Console.Write("Третий игрок: ");
                        thirdPlayer = Console.ReadLine();
                        if (players == 4)
                        {
                            Console.Write("Четвертый игрок: ");
                            fourthPlayer = Console.ReadLine();
                        }
                    }
                }
                else // Если выбрана настройка "Один игрок", то называем второго игрока "Компьютер"
                {
                    secondPlayer = "Computer";
                }
            }

            // Генерация gameNumber по настройкам
            Random randomize = new Random();
            int gameNumber = randomize.Next(gameNumberMin, gameNumberMax + 1);
            Console.WriteLine($"Загаданное число: {gameNumber}");

            #endregion

            #region Реализация игры

            // Реализация игры с компьютером или с игроками
            if (players == 1)
            {
                while (true)
                {
                    if (flag)
                    {
                        Console.Write($"Ходит {firstPlayer}. Введите число от 1 до {userTryMax}: ");
                        string userTryStr = Console.ReadLine(); //Число от игрока в виде строки
                        isNum = int.TryParse(userTryStr, out userTry);

                        #region Проверка на корректность ввода числа от игрока

                        while (true)
                        {
                            if (!isNum)
                            {
                                Console.Write($"Некорректные данные. {firstPlayer}, введите число от 1 до {userTryMax}: ");
                                userTryStr = Console.ReadLine();
                                isNum = int.TryParse(userTryStr, out userTry);
                            }
                            else
                            {
                                if (userTry > userTryMax || userTry < 1)
                                {
                                    Console.Write($"Некорректные данные. {firstPlayer}, введите число от 1 до {userTryMax}: ");
                                    userTryStr = Console.ReadLine();
                                    isNum = int.TryParse(userTryStr, out userTry);
                                }
                                else
                                {
                                    if (gameNumber < userTry)
                                    {
                                        Console.Write($"Некорректные данные. {firstPlayer}, введите число, чтобы получить 0: ");
                                        userTryStr = Console.ReadLine();
                                        isNum = int.TryParse(userTryStr, out userTry);
                                    }
                                    else
                                    { Console.WriteLine(userTry); break; }
                                }
                            }
                        }

                        #endregion

                        gameNumber -= userTry;
                        // Если gameNumber равен нулю, то поздравляем игрока и предлагаем реванш
                        if (gameNumber == 0)
                        {
                            Console.WriteLine($"\nУра! Выиграл {firstPlayer}. Поздравляем!");
                            Console.Write("Реванш? (y/n) ");
                            string regame = Console.ReadLine();
                            if (regame == "y") gameNumber = randomize.Next(gameNumberMin, gameNumberMax + 1);
                            else break;
                        }

                    }
                    else
                    {
                        // Генерация числа от компьютера
                        userTry = gameNumber < userTryMax ? randomize.Next(1, gameNumber + 1) : randomize.Next(1, userTryMax + 1);
                        // if (gameNumber >= 4)
                        //   userTry = randomize.Next(1, userTryMax + 1);
                        // else if (gameNumber == 3)
                        //    userTry = randomize.Next(1, 4);
                        //  else if (gameNumber == 2)
                        //   userTry = randomize.Next(1, 3);
                        // else userTry = 1;
                        Console.WriteLine($"Ходит {secondPlayer}. Введено число: {userTry}");

                        gameNumber -= userTry;
                        // Если gameNumber равен нулю, то поздравляем игрока и предлагаем реванш
                        if (gameNumber == 0)
                        {
                            Console.WriteLine($"\nУра! Выиграл {secondPlayer}. Поздравляем!");
                            Console.Write("Реванш? (y/n) ");
                            string regame = Console.ReadLine();
                            if (regame == "y") gameNumber = randomize.Next(gameNumberMin, gameNumberMax + 1);
                            else break;
                        }
                    }
                    Console.WriteLine($"Новое число: {gameNumber} \n");
                    flag = !flag;
                }
            }
            else
            {
                while (true)
                {
                    // Выбираем чья очередь ходить
                    switch (playNow)
                    {
                        case 1:
                            playerName = firstPlayer;
                            break;
                        case 2:
                            playerName = secondPlayer;
                            break;
                        case 3:
                            playerName = thirdPlayer;
                            break;
                        case 4:
                            playerName = fourthPlayer;
                            break;
                    }

                    Console.Write($"Ходит {playerName}. Введите число от 1 до {userTryMax}: ");
                    string userTryStr = Console.ReadLine(); //Число от игрока в виде строки
                    isNum = int.TryParse(userTryStr, out userTry);

                    #region Проверка на корректность ввода чисел от игрока

                    while (true)
                    {
                        if (!isNum)
                        {
                            Console.Write($"Некорректные данные. {playerName}, введите число от 1 до 4: ");
                            userTryStr = Console.ReadLine();
                            isNum = int.TryParse(userTryStr, out userTry);
                        }
                        else
                        {
                            if (userTry > userTryMax || userTry < 1)
                            {
                                Console.Write($"Некорректные данные. {playerName}, введите число от 1 до 4: ");
                                userTryStr = Console.ReadLine();
                                isNum = int.TryParse(userTryStr, out userTry);
                            }
                            else
                            {
                                if (gameNumber < userTry)
                                {
                                    Console.Write($"Некорректные данные. {playerName}, введите число, чтобы получить 0: ");
                                    userTryStr = Console.ReadLine();
                                    isNum = int.TryParse(userTryStr, out userTry);
                                }
                                else
                                { Console.WriteLine(userTry); break; }
                            }
                        }
                    }

                    #endregion

                    gameNumber -= userTry;
                    // Если gameNumber равен нулю, то поздравляем игрока и предлагаем реванш
                    if (gameNumber == 0)
                    {
                        Console.WriteLine($"\nУра! Выиграл {playerName}. Поздравляем!");
                        Console.Write("Реванш? (y/n) ");
                        string regame = Console.ReadLine();
                        if (regame == "y")
                        {
                            gameNumber = randomize.Next(gameNumberMin, gameNumberMax + 1);
                            playNow = players; // Чтобы после реванша игра началась с первого игрока
                        }
                        else break;
                    }
                    Console.WriteLine($"Новое число: {gameNumber} \n");
                    playNow = playNow != players ? playNow + 1 : 1;
                }
            }

            #endregion

            Console.WriteLine("\nИГРА ОКОНЧЕНА!");

            Console.ReadKey();

        }
    }
}
