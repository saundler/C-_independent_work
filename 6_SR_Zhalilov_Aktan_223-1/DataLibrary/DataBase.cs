using System;
using System.IO;
using System.Linq;
using System.Data;
using System.Text.Json;
using NewVariant.Interfaces;
using NewVariant.Exceptions;
using System.Collections.Generic;

namespace DataLibrary
{
    public class DataBase : IDataBase
    {
        private readonly Dictionary<Type, object> _dataBase; // База данных где храняться все таблицы типа T.
        
        /// <summary>
        /// Конструктор без параметров для инициализации базы данных. 
        /// </summary>
        public DataBase() => _dataBase = new Dictionary<Type, object>();
        
        /// <summary>
        /// Метод создающий новую таблицу типа T.
        /// </summary>
        /// <typeparam name="T">Тип новой таблицы.</typeparam>
        /// <exception cref="DataBaseException">В базе данных уже есть таблица типа T.</exception>
        public void CreateTable<T>() where T : IEntity
        {
            if (_dataBase.ContainsKey(typeof(T)))
                throw new DataBaseException("The database already contains a table of this type.");
            _dataBase.Add(typeof(T), new List<T>());
        }
        
        /// <summary>
        /// Метод добавляющий строку в таблицу типа T.
        /// </summary>
        /// <param name="getEntity">Метод возращающий экземпляр типа T.</param>
        /// <typeparam name="T">Тип таблицы.</typeparam>
        /// <exception cref="DataBaseException">В базе данных несуществует таблицы типа T.</exception>
        public void InsertInto<T>(Func<T> getEntity) where T : IEntity
        {
            if (!_dataBase.ContainsKey(typeof(T)))
                throw new DataBaseException("No table of the corresponding type was found in the database.");
            ((List<T>)_dataBase[typeof(T)]).Add(getEntity());
        }
        
        /// <summary>
        ///  Метод возвращающий ссылку на таблицу типа T.
        /// </summary>
        /// <typeparam name="T">Тип таблицы.</typeparam>
        /// <returns>Ссылка на таблицу типа T.</returns>
        /// <exception cref="DataBaseException">В базе данных несуществует таблицы типа T.</exception>
        public IEnumerable<T> GetTable<T>() where T : IEntity
        {
            if (!_dataBase.ContainsKey(typeof(T)))
                throw new DataBaseException("No table of the corresponding type was found in the database.");
            return (List<T>)_dataBase[typeof(T)];
        }
        
        /// <summary>
        /// Метод сериализующий таблицу типа T в файл.
        /// </summary>
        /// <param name="path">Путь к файлу.</param>
        /// <typeparam name="T">Тип сериализуемой таблицы.</typeparam>
        /// <exception cref="DataException">Ошибка при сериализации или при записи в файл.</exception>
        public void Serialize<T>(string path) where T : IEntity
        {
            try
            {
                using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write))
                    JsonSerializer.Serialize(fs, GetTable<T>(), typeof(IEnumerable<T>));
            }
            catch (Exception e)
            {
                throw new DataBaseException(e.Message, e);
            }
        }
        
        /// <summary>
        /// Метод десериализующий таблицу из файла в таблицу типа T. 
        /// </summary>
        /// <param name="path">Путь к файлу.</param>
        /// <typeparam name="T">Тип десериализуемой таблицы.</typeparam>
        /// <exception cref="DataException">Ошибка при десериализации или при чтение в файла.</exception>
        public void Deserialize<T>(string path) where T : IEntity
        {
            try
            {
                using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read))
                {
                    var temp = JsonSerializer.Deserialize(fs, typeof(IEnumerable<T>));
                    if (temp != null)
                        _dataBase[typeof(T)] = temp;
                }
            }
            catch (Exception e)
            {
                throw new DataBaseException(e.Message, e);
            }
        }
    }
}