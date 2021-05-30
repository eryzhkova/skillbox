using System;
using System.Collections.Generic;
using System.Text;

namespace structures
{
    struct Note
    {
        #region Поля

        /// <summary>
        /// Поле "Номер записи"
        /// </summary>
        uint id;

        /// <summary>
        /// Поле "Заголовок записи"
        /// </summary>
        string headerNote;

        /// <summary>
        /// Поле "Текст записи"
        /// </summary>
        string textNote;

        /// <summary>
        /// Поле "Дата создания/изменения записи"
        /// </summary>
        DateTime dateNote;

        /// <summary>
        /// Поле "Создатель записи"
        /// </summary>
        string creator;

        #endregion

        #region Конструктор

        /// <summary>
        /// Создание записи
        /// </summary>
        /// <param name="id">Номер записи</param>
        /// <param name="headerNote">Заголовок записи</param>
        /// <param name="textNote">Текст записи</param>
        /// <param name="dateNote">Дата создания/изменения записи</param>
        /// <param name="creator">Создатель записи</param>
        public Note(uint id, string headerNote, string textNote, DateTime dateNote, string creator)
        {
            this.id = id;
            this.headerNote = headerNote;
            this.textNote = textNote;
            this.dateNote = dateNote;
            this.creator = creator;
        }

        #endregion

        #region Свойства

        /// <summary>
        /// Номер записи
        /// </summary>
        public uint ID { get { return this.id; } set { this.id = value; } }

        /// <summary>
        /// Заголовок записи
        /// </summary>
        public string HeaderNote { get { return this.headerNote; } set { this.headerNote = value; } }

        /// <summary>
        /// Текст записи
        /// </summary>
        public string TextNote { get { return this.textNote; } set { this.textNote = value; } }

        /// <summary>
        /// Дата создания записи
        /// </summary>
        public DateTime DateNote { get { return this.dateNote; } set { this.dateNote = value; } }

        /// <summary>
        /// Создатель записи
        /// </summary>
        public string Creator { get { return this.creator; } set { this.creator = value; } }

        #endregion

        #region Методы

        /// <summary>
        /// Печать одной записи
        /// </summary>
        /// <returns></returns>
        public string Print()
        {
            return $"{this.id,10} {this.headerNote,15} {this.textNote,20} {this.dateNote,20:d} {this.creator,15}";
        }

        #endregion
    }
}
