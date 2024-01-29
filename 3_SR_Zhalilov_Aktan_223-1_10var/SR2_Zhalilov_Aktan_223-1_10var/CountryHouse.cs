using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace SR2_Zhalilov_Aktan_223_1_10var
{
    internal class CountryHouse : Property
    {
        /// <summary>
        /// Пустой конструктор.
        /// </summary>
        public CountryHouse() { }

        /// <summary>
        /// Конструктор обращающийся к конструктору базового класса.
        /// </summary>
        /// <param name="name">Наименование налога.</param>
        /// <param name="increase">Коэффициент увеличения налога.</param>
        /// <param name="taxRate">Процентная ставка налога в долях.</param>
        /// <param name="tenure">Количество месяцев владения объектом.</param>
        /// <param name="price">Стоимость объекта.</param>
        public CountryHouse(string name, double increase, 
                            double taxRate, int tenure, int price) : base(name, increase, taxRate, tenure, price) 
        {
            TaxRateCheck();
        }

        /// <summary>
        /// Метод проверяющий корректность параметра taxRate.
        /// </summary>
        protected override void TaxRateCheck()
        {
            if (TaxRate > 1 || TaxRate < 0)
            {
                throw new ArgumentException("For a country house, the percentage tax rate in shares cannot exceed 1\n" +
                                            "and cannot be less than 0");
            }
        }

        /// <summary>
        /// Индексатор возвращающий значение налога в соответсвии с его стоимостью.
        /// </summary>
        /// <param name="price">Стоимость имущества.</param>
        /// <returns>Значение налога наложенного на объект.</returns>
        public override double this[int price]
        {
            get
            {
                return Increase * TaxRate * price / Tenure;
            }
        }

        /// <summary>
        /// Переопределенный метод преобразющий данные этого класса в строку.
        /// </summary>
        /// <returns>Строка содержащая данные этого класса.</returns>
        public override string ToString()
        {
            return "CountryHouse " + base.ToString(0);
        }
    }
}
