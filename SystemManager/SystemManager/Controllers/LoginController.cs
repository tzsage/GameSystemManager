using Application;
using Application.SystemManage;
using Application.SystemSecurity;
using Code;
using Domain.Entity.SystemFrame;
using Domain.Entity.SystemManage;
using Domain.Entity.SystemSecurity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using SystemManager.Models;
using Web;

namespace SystemManager.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            //getUser();
            return View();
        }

        private void getUser()
        {
            //Data.RepositoryBase<UserInfoModel> service = new Data.RepositoryBase<UserInfoModel>();
            //var m= service.FindEntity(t => t.UserID == 1);

            //DataHelper.DBContext.SystemDBContext db = new DataHelper.DBContext.SystemDBContext();
            //db.Users.FirstOrDefault(t=>t.MenuID==1);
        }


        [HttpGet]
        public ActionResult GetAuthCode()
        {
            return File(new VerifyCode().GetVerifyCode(), @"image/Gif");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <param name="returnUrl"></param>
        /// <returns></returns>
        [HttpPost]//接受post请求
        [ValidateAntiForgeryToken]//检测服务器请求是否被篡改 该特性只能用于post请求，get请求无效 防止CSRF攻击
        public ActionResult Index(LoginModels model, string returnUrl)
        {
            //验证输入信息
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            LogEntity logEntity = new LogEntity();
            logEntity.F_ModuleName = "系统登录";
            logEntity.F_Type = DbLogType.Login.ToString();
            try
            {
                UserEntity userEntity = new UserApp().CheckLogin(model.UserName, model.Password);
                if (userEntity != null)
                {
                    OperatorModel operatorModel = new OperatorModel();
                    operatorModel.UserId = userEntity.F_Id;
                    operatorModel.UserCode = userEntity.F_Account;
                    operatorModel.UserName = userEntity.F_RealName;
                    operatorModel.CompanyId = userEntity.F_OrganizeId;
                    operatorModel.DepartmentId = userEntity.F_DepartmentId;
                    operatorModel.RoleId = userEntity.F_RoleId;
                    operatorModel.LoginIPAddress = Net.Ip;
                    operatorModel.LoginIPAddressName = Net.GetLocation(operatorModel.LoginIPAddress);
                    operatorModel.LoginTime = DateTime.Now;
                    operatorModel.LoginToken = DESEncrypt.Encrypt(Guid.NewGuid().ToString());
                    if (userEntity.F_Account == "admin")
                    {
                        operatorModel.IsSystem = true;
                    }
                    else
                    {
                        operatorModel.IsSystem = false;
                    }
                    OperatorProvider.Provider.AddCurrent(operatorModel);
                    logEntity.F_Account = userEntity.F_Account;
                    logEntity.F_NickName = userEntity.F_RealName;
                    logEntity.F_Result = true;
                    logEntity.F_Description = "登录成功";
                    new LogApp().WriteDbLog(logEntity);
                }
                //return Content(new AjaxResult { state = ResultType.success.ToString(), message = "登录成功。" }.ToJson());
            }
            catch (Exception ex)
            {
                logEntity.F_Account = model.UserName;
                logEntity.F_NickName = model.UserName;
                logEntity.F_Result = false;
                logEntity.F_Description = "登录失败，" + ex.Message;
                new LogApp().WriteDbLog(logEntity);
                return Content(new AjaxResult { state = ResultType.error.ToString(), message = ex.Message }.ToJson());
            }


            return  RedirectToAction("Index", "Home");
        }


        [HttpGet]
        public ActionResult OutLogin()
        {
            new LogApp().WriteDbLog(new LogEntity
            {
                F_ModuleName = "系统登录",
                F_Type = DbLogType.Exit.ToString(),
                F_Account = OperatorProvider.Provider.GetCurrent().UserCode,
                F_NickName = OperatorProvider.Provider.GetCurrent().UserName,
                F_Result = true,
                F_Description = "安全退出系统",
            });
            Session.Abandon();
            Session.Clear();
            OperatorProvider.Provider.RemoveCurrent();
            return RedirectToAction("Index", "Login");
        }
        [HttpPost]
        [HandlerAjaxOnly(Ignore =true)]
        public ActionResult CheckLogin(string username, string password)
        {
            LogEntity logEntity = new LogEntity();
            logEntity.F_ModuleName = "系统登录";
            logEntity.F_Type = DbLogType.Login.ToString();
            try
            {
                UserEntity userEntity = new UserApp().CheckLogin(username, password);
                if (userEntity != null)
                {
                    OperatorModel operatorModel = new OperatorModel();
                    operatorModel.UserId = userEntity.F_Id;
                    operatorModel.UserCode = userEntity.F_Account;
                    operatorModel.UserName = userEntity.F_RealName;
                    operatorModel.CompanyId = userEntity.F_OrganizeId;
                    operatorModel.DepartmentId = userEntity.F_DepartmentId;
                    operatorModel.RoleId = userEntity.F_RoleId;
                    operatorModel.LoginIPAddress = Net.Ip;
                    operatorModel.LoginIPAddressName = Net.GetLocation(operatorModel.LoginIPAddress);
                    operatorModel.LoginTime = DateTime.Now;
                    operatorModel.LoginToken = DESEncrypt.Encrypt(Guid.NewGuid().ToString());
                    if (userEntity.F_Account == "admin")
                    {
                        operatorModel.IsSystem = true;
                    }
                    else
                    {
                        operatorModel.IsSystem = false;
                    }
                    OperatorProvider.Provider.AddCurrent(operatorModel);
                    logEntity.F_Account = userEntity.F_Account;
                    logEntity.F_NickName = userEntity.F_RealName;
                    logEntity.F_Result = true;
                    logEntity.F_Description = "登录成功";
                    new LogApp().WriteDbLog(logEntity);
                }
                return Content(new AjaxResult { state = ResultType.success.ToString(), message = "登录成功。" }.ToJson());
            }
            catch (Exception ex)
            {
                logEntity.F_Account = username;
                logEntity.F_NickName = username;
                logEntity.F_Result = false;
                logEntity.F_Description = "登录失败，" + ex.Message;
                new LogApp().WriteDbLog(logEntity);
                return Content(new AjaxResult { state = ResultType.error.ToString(), message = ex.Message }.ToJson());
            }
        }



    }
}