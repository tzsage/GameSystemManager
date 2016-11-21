using Code;
using Domain.Entity.SystemManage;
using Domain.Entity.WebManage;
using Repository.WebManage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web;

namespace SystemManager.Areas.WebManager.Controllers
{
    public class ADManageController : Web.ControllerBase
    {
        ADRepository AD = new ADRepository();
        ADItemRepository ADItem = new ADItemRepository();
        // GET: WebManager/ADManage
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetADItems(Pagination pagination, long? lAid, string keyword)
        {
            var exp = ExtLinq.True<ADItemModel>();
            if (lAid > 0)
                exp.And(t => t.AID == lAid);

            if (!string.IsNullOrEmpty(keyword))
            {
                exp.And(t => t.IName.Contains(keyword));
            }

            var data = new
            {
                rows = ADItem.IQueryable(exp).OrderBy(t => t.AID).ToList(),
                total = pagination.total,
                page = pagination.page,
                records = pagination.records
            };
            return Content(data.ToJson());
        }

        /// <summary>
        /// 广告 保存
        /// </summary>
        /// <param name="itemsEntity"></param>
        /// <param name="lAid"></param>
        /// <returns></returns>
        public ActionResult ADSave(ADItemModel itemsEntity, long? lAid)
        {
            string imgPat = string.Empty;
            if (Request.Files.Count > 0)
            {
                string imageName = Request.Files[0].FileName.Split('.').Last();
                if (!string.IsNullOrEmpty(imageName))
                {
                    imgPat = "/Image/" + Guid.NewGuid().ToString() + "." + imageName;
                    Request.Files[0].SaveAs(Server.MapPath(imgPat));
                    itemsEntity.IPath = imgPat;
                }
            }
            ADItem.SubmitForm(itemsEntity, Convert.ToInt64(lAid));
            //return JavaScript("top.ItemsType.$(\"#gridList\").resetSelection();top.ItemsType.$(\"#gridList\").trigger(\"reloadGrid\"); ");
            return Success("操作成功。");
        }

        public ActionResult ADItemData(long lAid)
        {
            var data = ADItem.FindEntity(lAid);
            return Content(data.ToJson());
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="lAid"></param>
        /// <returns></returns>
        public ActionResult Delete(long lAid)
        {
            ADItem.Delete(t => t.IID == lAid);
            return Success("操作成功。");
        }
        /// <summary>
        /// 页面初始化
        /// </summary>
        /// <returns></returns>
        public ActionResult Edit()
        {
            return View();
        }

        /// <summary>
        /// 获取广告位为树结构
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [HandlerAjaxOnly(Ignore = true)]
        public ActionResult GetTreeJson()
        {
            var data = AD.IQueryable().ToList();
            var treeList = new List<TreeViewModel>();
            foreach (ADModel item in data)
            {
                TreeViewModel tree = new TreeViewModel();
                bool hasChildren = data.Count(t => t.APID == item.AID) == 0 ? false : true;
                tree.id = item.AID.ToString();
                tree.text = item.AName;
                tree.value = item.AID.ToString();
                tree.parentId = item.APID.ToString();
                tree.isexpand = true;
                tree.complete = true;
                tree.hasChildren = hasChildren;
                treeList.Add(tree);
            }
            return Content(treeList.TreeViewJson());
        }

        /// <summary>
        /// 获取树列表
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [HandlerAjaxOnly]
        public ActionResult GetTreeSelectJson()
        {
            var data = AD.IQueryable().ToList();
            var treeList = new List<TreeSelectModel>();
            foreach (ADModel item in data)
            {
                TreeSelectModel treeModel = new TreeSelectModel();
                treeModel.id = item.AID.ToString();
                treeModel.text = item.AName;
                treeModel.parentId = item.APID.ToString();
                treeList.Add(treeModel);
            }
            return Content(treeList.TreeSelectJson());
        }

        [HttpGet]
        [HandlerAjaxOnly(Ignore = true)]
        public ActionResult GetFormData(long keyValue)
        {
            var data = AD.FindEntity(keyValue);
            return Content(data.ToJson());
        }


        public ActionResult ADIndex()
        {
            return View();
        }
        public ActionResult ADListIndex()
        {
            var data = AD.IQueryable().ToList();
            var treeList = new List<TreeGridModel>();
            foreach (ADModel item in data)
            {
                TreeGridModel treeModel = new TreeGridModel();
                bool hasChildren = data.Count(t => t.APID == item.AID) == 0 ? false : true;
                treeModel.id = item.AID.ToString();
                treeModel.isLeaf = hasChildren;
                treeModel.parentId = item.APID.ToString();
                treeModel.expanded = hasChildren;
                treeModel.entityJson = item.ToJson();
                treeList.Add(treeModel);
            }
            return Content(treeList.TreeGridJson());
        }

        public ActionResult ADDelete(long keyValue)
        {
            if (AD.IQueryable().Count(t => t.APID.Equals(keyValue)) > 0)
            {
                throw new Exception("删除失败！操作的对象包含了下级数据。");
            }
            else
            {
                AD.Delete(t => t.AID == keyValue);
            }
            return Success("删除成功。");

        }

        public ActionResult ADEdit()
        {
            return View();
        }

        [HttpPost]
        [HandlerAjaxOnly]
        public ActionResult ADSubmit(ADModel itemsEntity, long keyValue)
        {

            itemsEntity.AeditTime = itemsEntity.ACreatetime = DateTime.Now;
            var LoginInfo = OperatorProvider.Provider.GetCurrent();
            if (LoginInfo != null)
            {
                itemsEntity.ACreateUser = LoginInfo.UserId;
            }



            AD.SubmitForm(itemsEntity, Convert.ToInt64(keyValue));
            return Success("操作成功。");
        }
        public ActionResult ADDetails()
        {
            return View();
        }



    }
}