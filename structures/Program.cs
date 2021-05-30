using System;

namespace structures
{
    class Program
    {
        #region Описание задание

        /// Разработать ежедневник.
        /// В ежедневнике реализовать возможность 
        /// - создания
        /// - удаления
        /// - реактирования 
        /// записей
        /// 
        /// В отдельной записи должно быть не менее пяти полей
        /// 
        /// Реализовать возможность 
        /// - Загрузки даннах из файла
        /// - Выгрузки даннах в файл
        /// - Добавления данных в текущий ежедневник из выбранного файла
        /// - Импорт записей по выбранному диапазону дат
        /// - Упорядочивания записей ежедневника по выбранному полю

        #endregion

        /// <summary>
        /// Метод для проверки корректности ввода чисел
        /// </summary>
        /// <param name="str">Не конвертированная введенная строка с числом</param>
        /// <returns></returns>
        static uint CheckNumber(string str)
        {
            bool isNum = uint.TryParse(str, out uint num);
            while (true)
            {
                if (!isNum)
                {
                    Console.Write($"Некорректные данные. Введите число: ");
                    str = Console.ReadLine();
                    isNum = uint.TryParse(str, out num);
                }
                else return num;
            }
        }

        /// <summary>
        /// Метод для проверки корректности ввода даты
        /// </summary>
        /// <param name="str">Не конвертированная введенная строка с датой</param>
        /// <returns></returns>
        static DateTime CheckDate(string str)
        {
            bool isNum = DateTime.TryParse(str, out DateTime date);
            while (true)
            {
                if (!isNum)
                {
                    Console.Write($"Некорректные данные. Введите дату в формате дд.мм.гггг: ");
                    str = Console.ReadLine();
                    isNum = DateTime.TryParse(str, out date);
                }
                else return date;
            }
        }

        /// <summary>
        /// Метод, с которого начинается выполнение
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Repository repository = new Repository(0); //Инициализируем репозиторий

            Console.SetCursorPosition(Console.WindowWidth / 2 - 10, 1);
            Console.WriteLine("Ежедневник \n");

            while (true)
            {
                Console.WriteLine("1. Создать запись 2. Удалить запись 3. Редактировать запись");
                Console.WriteLine("4. Загрузить записи из файла");
                Console.WriteLine("5. Добавить записи в ежедневник из файла");
                Console.WriteLine("6. Выгрузить записей в файл");
                Console.WriteLine("7. Импорт записей по выбранного диапазону дат");
                Console.WriteLine("8. Показать все записи");
                Console.WriteLine("-----\n9. Выход");

                Console.Write("Что хотите сделать? ");
                string numStr = Console.ReadLine();   // Номер действия
                uint num = CheckNumber(numStr);       // Проверяем корректность ввода

                // Выбор действия
                switch (num)
                {
                    case 1:
                        Console.WriteLine("-----Создание записи-----");
                        Console.Write("Заголовок: ");
                        string header = Console.ReadLine();
                        Console.Write("Текст: ");
                        string text = Console.ReadLine();
                        Console.Write("Создатель записи: ");
                        string creator = Console.ReadLine();
                        repository.Add(header, text, creator);
                        Console.WriteLine("-----Запись создана-----");
                        break;
                    case 2:
                        Console.WriteLine("-----Удаление записи-----");
                        Console.Write("Номер записи: ");
                        string idDelStr = Console.ReadLine();
                        uint idDel = CheckNumber(idDelStr);
                        repository.Delete(idDel);
                        break;
                    case 3:
                        Console.WriteLine("-----Редактирование записи-----");
                        Console.Write("Номер записи: ");
                        string idEditStr = Console.ReadLine();
                        uint idEdit = CheckNumber(idEditStr);
                        repository.Edit(idEdit);
                        break;
                    case 4:
                        Console.WriteLine("-----Загрузка записей из файла-----");
                        //Console.Write("Введите название файла: "); //Берем фаил из директории проекта
                        //string path = Console.ReadLine();
                        Console.WriteLine("Все данные по умолчанию берутся из ./bin/Debug/netcoreapp3.1/dataset.csv");
                        string loadPath = @"dataset.csv";
                        repository.LoadNotes(loadPath);
                        break;
                    case 5:
                        Console.WriteLine("-----Добавление записей из файла-----");
                        //Console.Write("Введите название файла: "); //Берем фаил из директории проекта
                        //string path = Console.ReadLine();
                        Console.WriteLine("Все данные по умолчанию берутся из ./bin/Debug/netcoreapp3.1/dataset.csv");
                        string addPath = @"dataset.csv";
                        repository.AddNotes(addPath);
                        break;
                    case 6:
                        Console.WriteLine("-----Выгрузка записей в файл-----");
                        //Console.Write("Введите название файла: "); //Берем фаил из директории проекта
                        //string path = Console.ReadLine();
                        Console.WriteLine("Все данные по умолчанию сохраняются в ./bin/Debug/netcoreapp3.1/newdata.csv");
                        string savePath = @"newdata.csv";
                        repository.Save(savePath);
                        break;
                    case 7:
                        Console.WriteLine("-----Импорт записей по выбранного диапазону дат-----");
                        //Console.Write("Введите название файла: "); //Берем фаил из директории проекта
                        //string path = Console.ReadLine();
                        Console.WriteLine("Все данные по умолчанию сохраняются в ./bin/Debug/netcoreapp3.1/newdatawithdate.csv");
                        string savePath2 = @"newdatawithdate.csv";

                        Console.Write("Введите дату (дд.мм.гггг) от: ");
                        string startDateStr = Console.ReadLine();
                        DateTime startDate = CheckDate(startDateStr);

                        Console.Write("Введите дату (дд.мм.гггг) до: ");
                        string endDateStr = Console.ReadLine();
                        DateTime endDate = CheckDate(endDateStr);

                        repository.SaveBetweenDate(savePath2, startDate, endDate);
                        break;
                    case 8:
                        Console.Clear();
                        repository.PrintDbToConsole();
                        break;
                    default: return;
                }
            }
        }
    }
}
