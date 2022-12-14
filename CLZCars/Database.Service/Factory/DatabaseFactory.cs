using Database.Service.Conector;
using Library.Shared.Design;
using Model.Shared.Target;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Database.Service.Factory
{
    public class DatabaseFactory : Singleton<DatabaseFactory>
    {
        protected override void Init()
        {

        }

        public DatabaseConnector Build<T>()
        {
            if (typeof(SQLServer).GetTypeInfo().IsAssignableFrom(typeof(T).Ge‌​tTypeInfo())) return SQLServerConnector.GetInstance();

            throw new Exception("Target connector is not implemented");
        }
    }
}
