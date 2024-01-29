namespace EKRLib
{
    public abstract class Transport
    {
        private string _model;      // Модель транспорта.
        private uint _power;        // Мощность транспорта.
        public string Model         // Свойство Модели транспорта.
        {
            set
            {
                // Проверка на количество символов в названии модели.
                if (value.Length == 5)
                {
                    // Проверка на недопустимые символы в названии модели.
                    foreach (char symbol in value.ToCharArray())
                    {
                        if (!(((int)symbol > 64 && (int)symbol < 91) || ((int)symbol > 47 && (int)symbol < 58)))
                        {
                            throw new TransportException("Недопустимая модель " + value);
                        }
                    }
                    _model = value;
                }
                else
                {
                    throw new TransportException("Недопустимая модель " + value);
                }
            }
            get { return _model; }
        }
        public uint Power               // Свойство мощности транспорта.
        {
            set
            {
                // Проверка на корректно заданую мощность.
                if(value < 20)
                {
                    throw new TransportException("Мощность не может быть меньше 20 л.с.");
                }

                _power = value;
            }
            get { return _power; }
        }

        /// <summary>
        /// Конструктор класса. 
        /// </summary>
        /// <param name="model">Название модели транспорта.</param>
        /// <param name="power">Значение мощности транспорта.</param>
        public Transport(string model, uint power)
        {
            Model = model;
            Power = power;
        }

        /// <summary>
        /// Метод запуска двигателя.
        /// </summary>
        /// <returns>Строка с названием модели и звуком двигателя</returns>
        public abstract string StartEngine();

        /// <summary>
        /// Метод возвращающий данные о транспорте.
        /// </summary>
        /// <returns>Строка с данными о транспорте.</returns>
        public override string ToString()
        {
            return $"Model: {Model}, Power: {Power}";
        }
    }
}