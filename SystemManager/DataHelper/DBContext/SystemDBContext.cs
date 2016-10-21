using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataHelper.DBContext
{
    public class SystemDBContext: DbContext
    {
        public SystemDBContext()
            : base("NFineDbContext")
        {
          
        }
    }
}
