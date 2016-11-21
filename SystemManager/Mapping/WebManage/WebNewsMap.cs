using Domain.Entity.WebManage;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mapping.WebManage
{
    public class WebNewsMap: EntityTypeConfiguration<NewsModel>
    {
        public WebNewsMap()
        {
            this.ToTable("tblNews");
            this.HasKey(t => t.NID);
        }
    }
}
