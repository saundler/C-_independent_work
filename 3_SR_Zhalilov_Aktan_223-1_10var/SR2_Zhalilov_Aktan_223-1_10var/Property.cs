using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Diagnostics;

namespace SR2_Zhalilov_Aktan_223_1_10var
{
    /// <summary>
    /// Абстрактный класс описывающий все виды имущества. 
    /// </summary>
    abstract internal class Property
    {
        public string Name { get; set; }        // Наименование налога.
        public double Increase { get; set; }    // Коэффициент увеличения налога.
        public double TaxRate { get; set; }     // Процентная ставка налога в долях.
        public int Tenure { get; set; }         // Количество месяцев владения объектом.  
        public int Price { get; set; }          // Стоимость объекта.
        
        /// <summary>
        /// Пустой конструктор.
        /// </summary>
        public Property() { }

        /// <summary>
        /// Конструктор формирующий экземпляр дочернего класса.
        /// </summary>
        /// <param name="name">Наименование налога.</param>
        /// <param name="increase">Коэффициент увеличения налога.</param>
        /// <param name="taxRate">Процентная ставка налога в долях.</param>
        /// <param name="tenure">Количество месяцев владения объектом.</param>
        /// <param name="price">Стоимость объекта.</param>
        /// <exception cref="ArgumentException"></exception>
        public Property(string name, double increase, double taxRate, int tenure, int price)
        {
            // Проверка данных на корректность.
            foreach(char ch in name)
            {
                if (!((ch > 47 && ch < 58) || (ch > 64 && ch < 91) || (ch > 96 && ch < 123)))
                {
                    throw new ArgumentException("Tax name may contain invalid characters");
                }
            }
            if (increase < 1)
            {
                throw new ArgumentException("The tax increase factor must be at least 1");
            }
            else if (tenure < 1)
            {
                throw new ArgumentException("The number of months of ownership of the object must be at least 1.");
            }
            else if (price <= 0)
            {
                throw new ArgumentException("Object value must be greater than 0");
            }

            // Инициализация полей
            Name = name;
            Increase = increase;
            TaxRate = taxRate;
            Tenure = tenure;
            Price = price;
        }

        /// <summary>
        /// Метод проверяющий корректность параметра taxRate.
        /// </summary>
        abstract protected void TaxRateCheck();

        /// <summary>
        /// Индексатор возвращающий значение налога в соответсвии с его стоимостью.
        /// </summary>
        /// <param name="price">Стоимость имущества.</param>
        /// <returns>Значение налога наложенного на объект.</returns>
        abstract public double this[int price]      
        {                                             
            get;                                    
        }                                           

        /// <summary>
        /// Переопределенный метод преобразющий данные этого класса в строку.
        /// </summary>
        /// <returns>Строка содержащая данные этого класса.</returns>
        public override string ToString()
        {
            return $"Property: {Name}. Tax increase factor: {Increase}, " + 
                   $"Tax percentage: {TaxRate}, Number of months of ownership: {Tenure}.";
        }

        /// <summary>
        /// Метод преобразющий данные этого класса в строку.
        /// </summary>
        /// <returns>Строка содержащая данные этого класса.</returns>
        public string ToString(int i)
        {
            return $"{Name} {Increase} {TaxRate} {Tenure} {Price} {this[Price]:f3}";
        }
    }
}
