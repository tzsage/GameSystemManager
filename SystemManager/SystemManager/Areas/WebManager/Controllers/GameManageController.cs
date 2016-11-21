using Code;
using Repository.WebManage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SystemManager.Areas.WebManager.Controllers
{
    public class GameManageController : Controller
    {

        private WebGameRepository repCustom = new WebGameRepository();
        // GET: WebManager/GameManage
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetGridJson(Pagination pagination, string keyword)
        {
            var data = new
            {
                rows = repCustom.GetList(pagination, keyword),
                total = pagination.total,
                page = pagination.page,
                records = pagination.records
            };
            return Content(data.ToJson());
        }

    }
}