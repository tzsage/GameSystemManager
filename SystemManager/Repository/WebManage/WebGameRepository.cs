using Code;
using DataHelper.Repository;
using Domain.Entity.WebManage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.WebManage
{
    public class WebGameRepository : WebRepositoryBase<GameModel>
    {
        public List<GameModel> GetList(Pagination pagination, string keyword)
        {
            var expression = ExtLinq.True<GameModel>();
            if (!string.IsNullOrEmpty(keyword))
            {
                expression = expression.And(t => t.GName.Contains(keyword));
            }
            return base.FindList(expression, pagination);
        }
    }

    public class WebGameCategoryRepository : WebRepositoryBase<GameCategoryModel>
    {
        public List<GameCategoryModel> GetList(Pagination pagination, string keyword)
        {
            var expression = ExtLinq.True<GameCategoryModel>();
            if (!string.IsNullOrEmpty(keyword))
            {
                expression = expression.And(t => t.CName.Contains(keyword));
            }
            return base.FindList(expression, pagination);
        }
    }
}
