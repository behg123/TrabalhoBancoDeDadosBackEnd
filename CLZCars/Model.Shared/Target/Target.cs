using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Shared.Target
{
    public interface Target
    {
       public DateTime? Updated { get; set; }
        public DateTime Created { get; set; }
        public string Entity { get; }
    }
}
