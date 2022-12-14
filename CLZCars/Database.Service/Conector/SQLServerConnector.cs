using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using Library.Shared.Design;
using Microsoft.Extensions.Configuration;
using Model.Shared.Target;
using Model.Shared.User;
using NHibernate;
using NHibernate.Tool.hbm2ddl;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SqlServer.Server;

using NHibernate.Cfg;
using System.Configuration;

namespace Database.Service.Conector
{
    public class SQLServerConnector : Singleton<SQLServerConnector>, DatabaseConnector
    {
        private ISessionFactory? session;
        private ISession? connection;
        private string? connectionString;

        protected override void Init()
        {
            this.connectionString = "Data Source=BGaya;Initial Catalog=CLZCars;Integrated Security=True";

            this.session = Fluently.Configure().Database(MsSqlConfiguration.MsSql2012.ConnectionString(connectionString).ShowSql())
                           .Mappings(m => m.FluentMappings.AddFromAssemblyOf<LoginModelMap>())
                           .ExposeConfiguration(cfg => new SchemaExport(cfg)
                           .Create(false, false))
                           .BuildSessionFactory();

        }

        public void Register()
        {

        }

        public void Open()
        {
            if (this.session == null) throw new Exception("Session is null");

            try
            {
                this.connection = this.session.OpenSession();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void Close()
        {
            if (this.connection == null) throw new Exception("Connection is null");

            try
            {
                this.connection.Close();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public bool Create<T>(T target)
        {
            if (this.connection == null) throw new Exception("Connection is null");
            if (target == null) throw new Exception("Target is null");

            ITransaction transaction = this.connection.BeginTransaction();

            try
            {
                SQLServer sqlServer = (SQLServer)target;
                sqlServer.Created = DateTime.Now;
                this.connection.Save(sqlServer);
                transaction.Commit();

                return true;
            }
            catch (Exception e)
            {
                transaction.Rollback();
                throw new Exception(e.Message);
            }
        }

        public bool Delete<T>(Dictionary<string, int> dictionary, T target)
        {
            if (this.connection == null) throw new Exception("Connection is null");
            if (target == null) throw new Exception("Target is null");

            ITransaction transaction = this.connection.BeginTransaction();

            try
            {
                SQLServer sqlServer = (SQLServer)target;
                this.connection.Delete(sqlServer);
                transaction.Commit();

                return true;
            }
            catch (Exception e)
            {
                transaction.Rollback();
                throw new Exception(e.Message);
            }
        }


        public T? Get<T>(Dictionary<string, string> dictionary, T target) where T : class
        {
            if (this.connection == null) throw new Exception("Connection is null");
            if (target == null) throw new Exception("Target is null");
            if (dictionary == null || dictionary.Count == 0) throw new Exception("Dictionary is null or empty");

            try
            {
                SQLServer sqlServer = (SQLServer)target;
                string key = dictionary.First().Key;
                string value = dictionary.First().Value;
                return this.connection.CreateCriteria<T>().Add(NHibernate.Criterion.Expression.Eq(key, value)).List<T>().First();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }


        public T? Get<T>(Dictionary<string, int> dictionary, T target) where T : class
        {
            if (this.connection == null) throw new Exception("Connection is null");
            if (target == null) throw new Exception("Target is null");
            if (dictionary == null || dictionary.Count == 0) throw new Exception("Dictionary is null or empty");

            try
            {
                SQLServer sqlServer = (SQLServer)target;
                string key = dictionary.First().Key;
                int value = dictionary.First().Value;
                return this.connection.CreateCriteria<T>().Add(NHibernate.Criterion.Expression.Eq(key, value)).List<T>().First();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public List<T>? List<T>(T target)
        {
            if (this.connection == null) throw new Exception("Connection is null");
            if (target == null) throw new Exception("Target is null");

            try
            {
                SQLServer sqlServer = (SQLServer)target;
                return this.connection.Query<T>().ToList();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public bool Update<T>(Dictionary<string, int> dictionary, T target)
        {
            if (this.connection == null) throw new Exception("Connection is null");
            if (target == null) throw new Exception("Target is null");

            ITransaction transaction = this.connection.BeginTransaction();

            try
            {
                SQLServer sqlServer = (SQLServer)target;
                sqlServer.Updated= DateTime.Now;
                this.connection.Update(sqlServer);

                transaction.Commit();

                return true;
            }
            catch (Exception e)
            {
                transaction.Rollback();
                throw new Exception(e.Message);
            }
        }

        public bool Update<T>(Dictionary<string, string> dictionary, T login)
        {
            throw new NotImplementedException();
        }
    }

}
