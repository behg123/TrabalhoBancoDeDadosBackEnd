using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Service.Conector
{
    public interface DatabaseConnector
    {
        public void Register();
        public void Open();
        public void Close();
        public bool Create<T>(T target);
        public bool Update<T>(Dictionary<string, int> dictionary, T target);
        public bool Delete<T>(Dictionary<string, int> dictionary, T target);
        public T? Get<T>(Dictionary<string, string> dictionary, T target) where T : class;
        public T? Get<T>(Dictionary<string, int> dictionary, T target) where T : class;
        public List<T>? List<T>(T target);
        bool Update<T>(Dictionary<string, string> dictionary, T login);
    }

}
