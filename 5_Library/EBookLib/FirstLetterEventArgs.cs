using System;

namespace EBookLib
{
    /// <summary>
    /// Класс первой буквы в названии изданий.
    /// </summary>
    public class FirstLetterEventArgs : EventArgs
    {
        public char firstLetter;    // Первая буква в названии издания.

        /// <summary>
        /// Конструктор класса.
        /// </summary>
        /// <param name="firstLetter">Первая буква в названии издания.</param>
        public FirstLetterEventArgs(char firstLetter) => this.firstLetter = firstLetter;
    }
}
