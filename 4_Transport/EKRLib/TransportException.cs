using System.Runtime.Serialization;

namespace EKRLib
{
    public class TransportException : Exception 
    {
        /// <summary>
        /// Конструктор класса без параметров.
        /// </summary>
        public TransportException() : base() { }

        /// <summary>
        /// Конструктор класса с указанным сообщением об ошибке.
        /// </summary>
        /// <param name="message">Сообщение об ошибке, указывающее причину создания исключения.</param>
        public TransportException(string message) : base(message) { }

        /// <summary>
        /// Конструктор класса с сериализованными данными.
        /// </summary>
        /// <param name="info">
        /// Объект хранящий сериализованные 
        /// данные объекта, относящиеся к выдаваемому исключению.
        /// </param>
        /// <param name="context">Объект содержащий контекстные сведения об источнике или назначении.</param>
        public TransportException(SerializationInfo info, StreamingContext context) : base(info, context) { }

        /// <summary>
        /// Конструктор класса с указанным сообщением об ошибке 
        /// и ссылкой на внутреннее исключение, вызвавшее данное исключение.
        /// </summary>
        /// <param name="message">Сообщение об ошибке, указывающее причину создания исключения.</param>
        /// <param name="exception">Исключение, вызвавшее текущее исключение.</param>
        public TransportException(string message, Exception exception) : base(message, exception) { }
    }
}
