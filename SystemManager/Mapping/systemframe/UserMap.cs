/****************************************************************************************************************************************************************/
using DataHelper.DBContext;
using Domain.Entity.SystemFrame;
using Domain.Entity.SystemManage;
using System.Data.Entity.ModelConfiguration;

namespace Mapping.SystemManage
{
    public class sys_UserMap : EntityTypeConfiguration<sys_UserEntiry>
    {
        public sys_UserMap()
        {
            this.ToTable("sys_User");
            this.HasKey(t => t.UserID);
        }
    }

    //public class UserInfoMap : EntityTypeConfiguration<UserInfoModel>
    //{
    //    public UserInfoMap()
    //    {
    //        this.ToTable("tblUser");
    //        this.HasKey(t => t.UserID);
    //    }

    //}
}
