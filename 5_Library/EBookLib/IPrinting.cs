using System;

namespace EBookLib
{
    /// <summary>
    /// Интерфейс реалезующий событие onPrint 
    /// и метод Print для доступа к нему.
    /// </summary>
    internal interface IPrinting
    {
        /// <summary>
        /// Событие сигнализирующее о печати издания.
        /// </summary>
        public event EventHandler onPrint;

        /// <summary>
        /// Метод предоставляющий доступ к событию onPrint.
        /// </summary>
        public void Print();
    }
}
