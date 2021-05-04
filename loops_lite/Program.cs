using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_Theme_03
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

            // Демонстрация
            // Число: 12,
            // Ход User1: 3
            //
            // Число: 9
            // Ход User2: 4
            //
            // Число: 5
            // Ход User1: 2
            //
            // Число: 3
            // Ход User2: 3
            //
            // User2 победил!

            #endregion

            Console.SetCursorPosition(Console.WindowWidth / 2 - 20, 0);
            Console.WriteLine("Загадай число и выиграй!");

            #region Начальная настройка игры

            Console.WriteLine("Введите Ваши никнеймы.");
            Console.Write("Первый игрок: ");
            string firstPlayer = Console.ReadLine();
            Console.Write("Второй игрок: ");
            string secondPlayer = Console.ReadLine();

            // Генерания числа
            Random randomize = new Random();
            int gameNumber = randomize.Next(12, 121);
            Console.WriteLine($"Загаданное число: {gameNumber}");

            bool flag = true; //для обозначения игроков

            #endregion

            #region Реализация игры

            while (true)
            {
                string player = flag ? firstPlayer : secondPlayer;
                Console.Write($"Ходит {player}. Введите число от 1 до 4: ");
                string userTryStr = Console.ReadLine(); //Число от игрока в виде строки
                int userTry;
                bool isNum = int.TryParse(userTryStr, out userTry);

                // Проверяем верно ли введено число
                while (true)
                {
                    if (!isNum)
                    {
                        Console.Write($"Некорректные данные. {player}, введите число от 1 до 4: ");
                        userTryStr = Console.ReadLine();
                        isNum = int.TryParse(userTryStr, out userTry);
                    }
                    else
                    {
                        if (userTry > 4 || userTry < 1)
                        {
                            Console.Write($"Некорректные данные. {player}, введите число от 1 до 4: ");
                            userTryStr = Console.ReadLine();
                            isNum = int.TryParse(userTryStr, out userTry);
                        }
                        else
                        {
                            if (gameNumber < userTry)
                            {
                                Console.Write($"Некорректные данные. {player}, введите число, чтобы получить 0: ");
                                userTryStr = Console.ReadLine();
                                isNum = int.TryParse(userTryStr, out userTry);
                            }
                            else break;
                        }
                    }
                }
                gameNumber -= userTry;
                // Если gameNumber равен нулю, то поздравляем игрока и предлагаем реванш
                if (gameNumber == 0)
                {
                    Console.WriteLine($"\nУра! Выиграл {player}. Поздравляем!");
                    Console.Write("Реванш? (y/n) ");
                    string regame = Console.ReadLine();
                    if (regame == "y") gameNumber = randomize.Next(12, 121);
                    else break;
                }
                Console.WriteLine($"\nНовое число: {gameNumber}");
                flag = !flag;
            }

            #endregion

            Console.WriteLine("\nИГРА ОКОНЧЕНА!");

            Console.ReadKey();

        }
    }
}
