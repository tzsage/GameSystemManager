using Domain.Entity.WebManage;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mapping.WebManage
{
    public  class WebUserMap : EntityTypeConfiguration<WebUserModel>
    {
        public WebUserMap()
        {
            this.ToTable("tblUser");
            this.HasKey(t => t.UserID);
        }

    }
}
