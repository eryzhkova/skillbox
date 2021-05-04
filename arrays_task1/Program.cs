using System;

namespace Homework_Module04_task1
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Описание задания 1

            // Задание 1.
            // Заказчик просит вас написать приложение по учёту финансов
            // и продемонстрировать его работу.
            // Суть задачи в следующем: 
            // Руководство фирмы по 12 месяцам ведет учет расходов и поступлений средств. 
            // За год получены два массива – расходов и поступлений.
            // Определить прибыли по месяцам
            // Количество месяцев с положительной прибылью.
            // Добавить возможность вывода трех худших показателей по месяцам, с худшей прибылью, 
            // если есть несколько месяцев, в некоторых худшая прибыль совпала - вывести их все.
            // Организовать дружелюбный интерфейс взаимодействия и вывода данных на экран

            // Пример
            //       
            // Месяц      Доход, тыс. руб.  Расход, тыс. руб.     Прибыль, тыс. руб.
            //     1              100 000             80 000                 20 000
            //     2              120 000             90 000                 30 000
            //     3               80 000             70 000                 10 000
            //     4               70 000             70 000                      0
            //     5              100 000             80 000                 20 000
            //     6              200 000            120 000                 80 000
            //     7              130 000            140 000                -10 000
            //     8              150 000             65 000                 85 000
            //     9              190 000             90 000                100 000
            //    10              110 000             70 000                 40 000
            //    11              150 000            120 000                 30 000
            //    12              100 000             80 000                 20 000
            // 
            // Худшая прибыль в месяцах: 7, 4, 1, 5, 12
            // Месяцев с положительной прибылью: 10

            #endregion

            Console.SetCursorPosition(Console.WindowWidth / 2 - 15, 1);
            Console.WriteLine("Приложение \"Учет финансов\" \n");


            int[] incomeArray = new int[12];  // Массив для доходов
            int[] costsArray = new int[12];   // Массив для расходов
            int[] profitArray = new int[12];  // Массив для прибыли

            Random random = new Random();

            Console.WriteLine("{0,10} {1,20} {1,20} {1,20}",
                              "Месяц",
                              "Доход, тыс. руб.",
                              "Расход, тыс. руб.",
                              "Прибыль, тыс. руб.");

            // Заполнение массивов и вывод
            // Я бы сделала простые переменные для дохода и расхода, так как мы их больше нигде не используем
            // Но в ТЗ было сказано "массивы"
            for (int i = 0; i < 12; i++)
            {
                incomeArray[i] = random.Next(21) * 10000;
                costsArray[i] = random.Next(21) * 10000;
                profitArray[i] = incomeArray[i] - costsArray[i];
                Console.WriteLine($"{i + 1,10} {incomeArray[i],20} {costsArray[i],20} {profitArray[i],20}");
            }

            Console.WriteLine();

            // Объявление минимумов
            int firstMinProfit = profitArray[0], secondMinProfit = 200000, thirdMinProfit = 200000;

            #region Поиск минимумов

            // Поиск первой минимальной прибыли
            foreach (int item in profitArray)
            {
                if (firstMinProfit >= item)
                    firstMinProfit = item;

            }

            // Поиск второй минимальной прибыли
            foreach (int item in profitArray)
            {
                if (secondMinProfit >= item && item != firstMinProfit)
                    secondMinProfit = item;

            }

            // Поиск третьей минимальной прибыли
            foreach (int item in profitArray)
            {
                if (thirdMinProfit >= item && item != secondMinProfit && item != firstMinProfit)
                    thirdMinProfit = item;

            }

            #endregion

            // Вывод месяцев с худшей прибылью
            Console.Write("Худшая прибыль в месяцах: ");
            for (int i = 0; i < profitArray.Length; i++)
            {
                if (profitArray[i] == firstMinProfit || profitArray[i] == secondMinProfit || profitArray[i] == thirdMinProfit)
                    Console.Write($"{i + 1} ");
            }

            Console.WriteLine();

            // Подсчет месяцев с положительной прибылью
            int profitCount = 0;
            foreach (int item in profitArray)
            {
                if (item > 0) profitCount++;
            }
            Console.Write($"Месяцев с положительной прибылью: {profitCount} \n");

            Console.ReadKey();
        }
    }
}
