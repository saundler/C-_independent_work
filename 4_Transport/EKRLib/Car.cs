﻿namespace EKRLib
{
    public class Car : Transport
    {
        /// <summary>
        /// Конструктор класса. 
        /// </summary>
        /// <param name="model">Название модели транспорта.</param>
        /// <param name="power">Значение мощности транспорта.</param>
        public Car(string model, uint power) : base(model, power) { }

        /// <summary>
        /// Метод запуска двигателя.
        /// </summary>
        /// <returns>Строка с названием модели и звуком двигателя</returns>
        public override string StartEngine()
        {
            return $"{Model}: Vroom";
        }

        /// <summary>
        /// Метод возвращающий данные о транспорте.
        /// </summary>
        /// <returns>Строка с данными о транспорте.</returns>
        public override string ToString()
        {
            return "Car. " + base.ToString();
        }
    }
}
