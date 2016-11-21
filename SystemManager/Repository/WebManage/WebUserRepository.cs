using Code;
using Data;
using DataHelper.Repository;
using Domain.Entity.WebManage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.WebManage
{
    public class WebUserRepository : WebRepositoryBase<WebUserModel>
    {
        public List<WebUserModel> GetList(Pagination pagination, string keyword)
        {
            var expression = ExtLinq.True<WebUserModel>();
            if (!string.IsNullOrEmpty(keyword))
            {
                expression = expression.And(t => t.UserName.Contains(keyword));
                expression = expression.Or(t => t.NickName.Contains(keyword));
            }
            return base.FindList(expression, pagination);
        }


    }
}
