using Code;
using Data;
using Domain.Entity.WebManage;
using Repository.WebManage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SystemManager.Areas.WebManager.Controllers
{
    public class CustomManageController : Controller
    {


        private WebUserRepository repCustom = new WebUserRepository();

        // GET: WebManager/CustomManage
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Edit()
        {
            return View();
        }

        public ActionResult EditUser(long UserId,int status)
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

        public ActionResult RevisePassword(string keyValue)
        {
            var model = new WebUserModel();
            model.UserID = Convert.ToInt64(keyValue);
            model.UserPassword = "123456";
            model.Status = 1;
            repCustom.Update(model);
           return  Content(new AjaxResult { state = ResultType.success.ToString(), message = "操作成功" }.ToJson());
        }

        public ActionResult DisabledAccount(string keyValue)
        {
            var model = new WebUserModel();
            model.UserID = Convert.ToInt64(keyValue);
            model.Status = 0;
            repCustom.Update(model);

            return Content(new AjaxResult { state = ResultType.success.ToString(), message = "操作成功" }.ToJson());
        }
        public ActionResult EnabledAccount(string keyValue)
        {
            var model = new WebUserModel();
            model.UserID = Convert.ToInt64(keyValue);
            model.Status = 1;
            repCustom.Update(model);
            return Content(new AjaxResult { state = ResultType.success.ToString(), message = "操作成功" }.ToJson());
        }

    }
}