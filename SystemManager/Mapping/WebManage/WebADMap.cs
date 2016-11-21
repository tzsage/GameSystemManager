using Domain.Entity.WebManage;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mapping.WebManage
{
    public  class WebADMap: EntityTypeConfiguration<ADModel>
    {
        public WebADMap()
        {
            this.ToTable("tblAD");
            this.HasKey(t => t.AID);
        }
    }
    public class WebADItemMap : EntityTypeConfiguration<ADItemModel>
    {
        public WebADItemMap()
        {
            this.ToTable("tblADItem");
            this.HasKey(t => t.IID);
        }
    }
}
