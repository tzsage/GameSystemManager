using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity.SystemFrame
{
    public class sys_UserEntiry:IEntity<sys_UserEntiry>
    {
       public long UserID { get; set; }
        public string UserName { get; set; }
        public string NckName { get; set; }
        public string PassWord { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime LastLoginTime { get; set; }
        public string UserPhoto { get; set; }
    }
}
