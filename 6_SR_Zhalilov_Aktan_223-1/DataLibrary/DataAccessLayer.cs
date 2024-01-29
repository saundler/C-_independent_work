using System;
using System.IO;
using System.Linq;
using NewVariant.Models;
using NewVariant.Interfaces;
using System.Collections.Generic;

namespace DataLibrary
{
    public class DataAccessLayer
    {
        /// <summary>
        /// Конструктор без параметров.
        /// </summary>
        public DataAccessLayer() { }

        /// <summary>
        /// Метод возвращающий список всех товаров, купленных покупателем с самым длинным именем.
        /// </summary>
        /// <param name="dataBase">База данных.</param>
        /// <returns>Список товаров.</returns>
        public IEnumerable<Good> GetAllGoodsOfLongestNameBuyer(IDataBase dataBase)
        {
            try
            {
                var buyer = dataBase.GetTable<Buyer>().OrderBy(x => x.Name.Length).ThenBy(x => x.Name).Last();
                var sales = dataBase.GetTable<Sale>().Where(x => x.BuyerId == buyer.Id).Select(x => x.GoodId);
                return dataBase.GetTable<Good>().Where(y => sales.Contains(y.Id));
            }
            catch 
            {
                return Enumerable.Empty<Good>();
            }
        }
        
        /// <summary>
        /// Возвращает название категории самого дорогого товара. 
        /// </summary>
        /// <param name="dataBase">База данных.</param>
        /// <returns>Название категории.</returns>
        public string? GetMostExpensiveGoodCategory(IDataBase dataBase)
        {
            try
            {
                return dataBase.GetTable<Good>().OrderBy(x => x.Price).Last().Category;
            }
            catch 
            {
                return null;
            }
        }
        
        /// <summary>
        /// Возвращает название города, в котором было потрачено меньше всего денег.
        /// </summary>
        /// <param name="dataBase">База данных.</param>
        /// <returns>Название города.</returns>
        public string? GetMinimumSalesCity(IDataBase dataBase)
        {
            try
            {
                var goods = dataBase.GetTable<Good>().ToList();
                var shopsRevenue = dataBase.GetTable<Sale>().GroupBy(x => x.ShopId).Select(x =>
                    (x.Key, x.Select(y => goods.Find(z =>
                        z.Id == y.GoodId)!.Price * y.GoodCount).Sum())).ToList();
                return dataBase.GetTable<Shop>().Where(x => shopsRevenue.Exists(y => y.Key == x.Id))
                    .GroupBy(x => x.City).Select(x =>
                        (x.Key, x.Select(y => shopsRevenue.Find(z => z.Key == y.Id).Item2).Sum()))
                    .OrderBy(x => x.Item2).First().Key;
            }
            catch 
            {
                return null;
            }
        }
        
        /// <summary>
        /// Возвращает список покупателей, которые купили самый популярный товар.
        /// </summary>
        /// <param name="dataBase">База данных.</param>
        /// <returns>Список покупателей.</returns>
        public IEnumerable<Buyer> GetMostPopularGoodBuyers(IDataBase dataBase)
        {
            try
            {
                var sales = dataBase.GetTable<Sale>().ToList();
                var mostPopularGoodSales = dataBase.GetTable<Good>().
                    Where(x => sales.Exists(y => y.GoodId == x.Id)).
                    Select(x => sales.FindAll(y => y.GoodId == x.Id)).
                    OrderBy(x => x.Count).Last();
                return dataBase.GetTable<Buyer>().Where(x =>
                    mostPopularGoodSales.Exists(y => y.BuyerId == x.Id)).Distinct();
            }
            catch 
            {
                return Enumerable.Empty<Buyer>();
            }
        }
        
        /// <summary>
        /// Возвращает количество магазинов в городе в котором их меньше всего.
        /// </summary>
        /// <param name="dataBase">База данных.</param>
        /// <returns>Количество магазинов.</returns>
        public int GetMinimumNumberOfShopsInCountry(IDataBase dataBase)
        {
            try
            {
                return dataBase.GetTable<Shop>().GroupBy(x => x.Country).
                Select(x => x.Count()).OrderBy(x => x).First();
            }
            catch
            {
                return 0;
            }
        }
        
        /// <summary>
        /// Возвращает список покупок, совершенных покупателями во всех городах, отличных от города их проживания.
        /// </summary>
        /// <param name="dataBase">База данных.</param>
        /// <returns>Список покупок.</returns>
        public IEnumerable<Sale> GetOtherCitySales(IDataBase dataBase)
        {
            try
            {
                var buyers = dataBase.GetTable<Buyer>().ToList();
                var shops = dataBase.GetTable<Shop>().ToList();
                return dataBase.GetTable<Sale>().Where(x =>
                    buyers.Find(y => y.Id == x.BuyerId)?.City != 
                    shops.Find(y => y.Id == x.ShopId)?.City);
            }
            catch 
            {
                return Enumerable.Empty<Sale>();
            }
        }
        
        /// <summary>
        /// Возвращает общую стоимость покупок, совершенных всеми покупателями.
        /// </summary>
        /// <param name="dataBase">База данных.</param>
        /// <returns>Стоимость всех покупок.</returns>
        public long GetTotalSalesValue(IDataBase dataBase)
        {
            try
            {
                var goods = dataBase.GetTable<Good>().ToList();
                return dataBase.GetTable<Sale>().Select(x =>
                    goods.Find(y => y.Id == x.GoodId)!.Price * x.GoodCount).Sum();
            }
            catch
            {
                return 0;
            }
        }
    }
}
