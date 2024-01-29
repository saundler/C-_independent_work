using System;
using System.Runtime.Serialization;

namespace EBookLib
{
    /// <summary>
    /// Класс ошибок PrintEdition.
    /// </summary>
    public class PrintEditionException : Exception
    {
        /// <summary>
        /// Конструктор класса без параметров.
        /// </summary>
        public PrintEditionException() : base() { }

        /// <summary>
        /// Конструктор класса с указанным сообщением об ошибке.
        /// </summary>
        /// <param name="message">Сообщение об ошибке, указывающее причину создания исключения.</param>
        public PrintEditionException(string message) : base(message) { }

        /// <summary>
        /// Конструктор класса с сериализованными данными.
        /// </summary>
        /// <param name="info">
        /// Объект хранящий сериализованные 
        /// данные объекта, относящиеся к выдаваемому исключению.
        /// </param>
        /// <param name="context">Объект содержащий контекстные сведения об источнике или назначении.</param>
        public PrintEditionException(SerializationInfo info, StreamingContext context) : base(info, context) { }

        /// <summary>
        /// Конструктор класса с указанным сообщением об ошибке 
        /// и ссылкой на внутреннее исключение, вызвавшее данное исключение.
        /// </summary>
        /// <param name="message">Сообщение об ошибке, указывающее причину создания исключения.</param>
        /// <param name="exception">Исключение, вызвавшее текущее исключение.</param>
        public PrintEditionException(string message, Exception exception) : base(message, exception) { }
    }
}
