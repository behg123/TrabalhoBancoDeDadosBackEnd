using Database.Service.Conector;
using Database.Service.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Service.Repository
{
    public abstract class DatabaseRepository<T, K> where T : class, new()
    {
        private DatabaseConnector databaseConnector;
        private static T? _instance = null;
        private static readonly object _lock = new object();

        public static T GetInstance()
        {
            if (_instance == null)
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new T();
                    }
                }
            }
            return _instance;
        }

        protected DatabaseRepository()
        {
            this.databaseConnector = DatabaseFactory.GetInstance().Build<K>();
            this.Init();
        }

        protected DatabaseConnector DatabaseConnector
        {
            get
            {
                return this.databaseConnector;
            }
        }

        protected abstract void Init();
    }
}
