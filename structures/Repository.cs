using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace structures
{
    struct Repository
    {
        #region Поля

        /// <summary>
        /// Массив записей
        /// </summary>
        Note[] notes;

        /// <summary>
        /// Текущий элемент для добавления в notes
        /// </summary>
        uint index;

        /// <summary>
        /// Массив, храняий заголовки полей, используется для вывода
        /// </summary>
        string[] titles;

        #endregion

        #region Конструктор

        /// <summary>
        /// Констурктор
        /// </summary>
        public Repository(uint index)
        {
            this.index = index; // текущая позиция для добавления сотрудника в workers
            this.titles = new string[5] { "Номер", "Заголовок", "Текст", "Дата создания", "Создатель" }; // инициализаия массива заголовков   
            this.notes = new Note[1]; // инициализаия массива сотрудников.    | изначально предпологаем, что данных нет
        }

        #endregion

        #region Методы

        /// <summary>
        /// Метод увеличения текущего хранилища
        /// </summary>
        /// <param name="Flag">Условие увеличения</param>
        private void Resize(bool Flag)
        {
            if (Flag)
            {
                Array.Resize(ref notes, notes.Length * 2);
            }
        }

        /// <summary>
        /// Метод добавления записи в хранилище
        /// </summary>
        /// <param name="ConcreteNote">Запись</param>
        public void Add(string headerNote, string textNote, string creatorNote)
        {
            this.Resize(index >= notes.Length);
            this.notes[index].HeaderNote = headerNote;
            this.notes[index].TextNote = textNote;
            this.notes[index].Creator = creatorNote;
            this.notes[index].DateNote = DateTime.Today;
            this.notes[index].ID = index;
            this.index++;
        }

        /// <summary>
        /// Количество записей в хранилище
        /// </summary>
        public uint Count { get { return index; } }

        /// <summary>
        /// Сортировка по указанному полю
        /// </summary>
        /// <returns></returns>
        void SortNotes()
        {
            bool wantSort = CheckNotes("Хотите отсортировать по дате?");
            if (wantSort)
            {
                var newNotes = notes.OrderByDescending(itm => itm.DateNote);
                Console.WriteLine($"{this.titles[0],10} {this.titles[1],15} {this.titles[2],20} {this.titles[3],20} {this.titles[4],15}");
                int i = 0;

                //Изменяет исходных массив
                foreach (var note in newNotes)
                {
                    notes[i] = note;
                    i++;
                }
                //Печать итогового массива записей
                for (int j = 0; j < index; j++)
                {
                    Console.WriteLine(this.notes[j].Print());
                }
                Console.WriteLine("Отсортировано по дате.");
            }
            else return;
        }

        /// <summary>
        /// Вывод данных в консоль
        /// </summary>
        public void PrintDbToConsole()
        {
            if (index == 0)
            {
                Console.WriteLine("В ежедневнике нет записей.");
            }
            else
            {
                Console.WriteLine($"{this.titles[0],10} {this.titles[1],15} {this.titles[2],20} {this.titles[3],20} {this.titles[4],15}");

                for (int i = 0; i < index; i++)
                {
                    Console.WriteLine(this.notes[i].Print());
                }
            }
            this.SortNotes();
        }

        /// <summary>
        /// Поиск записи в хранилище
        /// </summary>
        /// <param name="id">Номер записи</param>
        /// <returns></returns>
        bool FindNote(uint id)
        {
            for (int i = 0; i < index; i++)
            {
                if (notes[i].ID == id)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Печать найденной записи
        /// </summary>
        public void NotePrint(uint id)
        {
            Console.WriteLine($"{this.titles[0],15} {this.titles[1],15} {this.titles[2],15} {this.titles[3],15} {this.titles[4],15}");
            Console.WriteLine(this.notes[id].Print());
        }

        /// <summary>
        /// Удаление элемента массива
        /// </summary>
        public void Delete(uint id)
        {
            if (this.FindNote(id))
            {
                NotePrint(id);
                if (id == index - 1) index--;
                else
                {
                    for (uint i = id; i < index - 1; i++)
                    {
                        notes[i] = notes[i + 1];
                    }
                    index--;
                }
                Console.WriteLine("-----Запись удалена-----");
            }
            else Console.WriteLine("-----Запись не найдена-----");
        }

        /// <summary>
        /// Редактирование записи
        /// </summary>
        /// <param name="id">Номер записи</param>
        public void Edit(uint id)
        {
            if (this.FindNote(id))
            {
                NotePrint(id);
                Console.Write("Новый заголовок: ");
                notes[id].HeaderNote = Console.ReadLine();
                Console.Write("Новый текст: ");
                notes[id].TextNote = Console.ReadLine();
                Console.Write("Новый создатель: ");
                notes[id].Creator = Console.ReadLine();
                Console.WriteLine("-----Запись отредактирована-----");
            }
            else Console.WriteLine("-----Запись не найдена-----");
        }

        /// <summary>
        /// Проверка на пустоту ежедневника
        /// </summary>
        /// <returns></returns>
        bool CheckNotes(string text)
        {
            bool isEmpty = index == 0;
            if (!isEmpty)
            {
                Console.Write($"{text} (y - да, n - нет) ");
                string agree = Console.ReadLine();
                bool flag = true;
                while (flag)
                {
                    if (!string.Equals(agree, "y") && !string.Equals(agree, "n"))
                    {
                        Console.Write("Введите одну букву (y - да, n - нет) ");
                        agree = Console.ReadLine();
                    }
                    else flag = false;
                }
                if (agree == "y") return true;
                else return false;
            }
            else return true;
        }

        /// <summary>
        /// Загрузка записей из файла
        /// </summary>
        /// <param name="path">Путь к файлу</param>
        public void LoadNotes(string path)
        {
            using (StreamReader sr = new StreamReader(path))
            {
                sr.ReadLine(); //Пропускаем строку с заголовками
                bool isEmpty = CheckNotes("Ежедневник не пуст. Очистить его?");
                if (isEmpty)
                {
                    index = 0;
                    while (!sr.EndOfStream)
                    {
                        string[] args = sr.ReadLine().Split(';');
                        this.Resize(index >= this.notes.Length);
                        this.notes[index] = new Note(Convert.ToUInt32(args[0]), args[1], args[2], Convert.ToDateTime(args[3]), args[4]);
                        this.index++;
                    }
                }
                else return;
            }
        }

        /// <summary>
        /// Добавление записей из файла
        /// </summary>
        /// <param name="path">Путь к файлу</param>
        public void AddNotes(string path)
        {
            using (StreamReader sr = new StreamReader(path))
            {
                sr.ReadLine(); //Пропускаем строку с заголовками
                while (!sr.EndOfStream)
                {
                    string[] args = sr.ReadLine().Split(';');
                    this.Resize(index >= this.notes.Length);
                    this.notes[index] = new Note(index, args[1], args[2], Convert.ToDateTime(args[3]), args[4]);
                    this.index++;
                }
            }
        }

        /// <summary>
        /// Сохранение записей в файл
        /// </summary>
        /// <param name="path">Путь к файлу сохранения</param>
        public void Save(string path)
        {
            string temp = String.Format("{0},{1},{2},{3},{4}",
                                            this.titles[0],
                                            this.titles[1],
                                            this.titles[2],
                                            this.titles[3],
                                            this.titles[4]);

            File.WriteAllText(path, $"{temp}\n");

            for (int i = 0; i < this.index; i++)
            {
                temp = String.Format("{0},{1},{2},{3},{4}",
                                        this.notes[i].ID,
                                        this.notes[i].HeaderNote,
                                        this.notes[i].TextNote,
                                        this.notes[i].DateNote.ToString("d"),
                                        this.notes[i].Creator);
                File.AppendAllText(path, $"{temp}\n");
            }
        }

        /// <summary>
        /// Сохранение записей по выбранному диапозону дат
        /// </summary>
        /// <param name="path">Путь к файлу сохранения</param>
        /// <param name="date1">Начальная дата (от)</param>
        /// <param name="date2">Конечная дата (до)</param>
        public void SaveBetweenDate(string path, DateTime date1, DateTime date2)
        {
            string temp = String.Format("{0},{1},{2},{3},{4}",
                                            this.titles[0],
                                            this.titles[1],
                                            this.titles[2],
                                            this.titles[3],
                                            this.titles[4]);

            File.WriteAllText(path, $"{temp}\n");

            for (int i = 0; i < this.index; i++)
            {
                if (this.notes[i].DateNote > date1 && this.notes[i].DateNote < date2)
                {
                    temp = String.Format("{0},{1},{2},{3},{4}",
                                        this.notes[i].ID,
                                        this.notes[i].HeaderNote,
                                        this.notes[i].TextNote,
                                        this.notes[i].DateNote.ToString("d"),
                                        this.notes[i].Creator);
                    File.AppendAllText(path, $"{temp}\n");
                }
            }
        }

        #endregion
    }
}
