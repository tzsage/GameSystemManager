using Domain.Entity.WebManage;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mapping.WebManage
{
    public class WebExpMap: EntityTypeConfiguration<ExpModel>
    {
        public WebExpMap()
        {
            this.ToTable("tblExp");
            this.HasKey(t => t.EID);
        }
    }
}
