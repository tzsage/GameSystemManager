using Domain.Entity.WebManage;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mapping.WebManage
{
    public class WebGameMap: EntityTypeConfiguration<GameModel>
    {
        public WebGameMap()
        {
            this.ToTable("tblGame");
            this.HasKey(t => t.GID);
        }
    }
    public class WebGameCategoryMap : EntityTypeConfiguration<GameCategoryModel>
    {
        public WebGameCategoryMap()
        {
            this.ToTable("tblCategory");
            this.HasKey(t => t.CID);
        }
    }

    
}
