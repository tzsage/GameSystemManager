using Code;
using Domain.Entity.WebManage;
using Repository.WebManage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SystemManager.Areas.WebManager.Controllers
{
    public class CategoryManageController : Web.ControllerBase
    {
        WebGameCategoryRepository wgcR = new WebGameCategoryRepository();
        WebGameRepository wgR = new WebGameRepository();



        // GET: WebManager/CategoryManage
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Edit()
        {
            return View();
        }

        public ActionResult CategoryEdit()
        {
            return View();
        }
        public ActionResult CategiryIndex()
        {
            return View();
        }

        public ActionResult DeleteC(long Cid)
        {

            var model = new GameCategoryModel();
            model.CID = Cid;
            model.CStatus = false;
            if (Cid > 0)
                wgcR.Update(model);

            return Success("操作成功");
        }
        public ActionResult Delete (long Gid)
        {
            var model = new GameModel();
            model.GID = Gid;
            model.GStatus = false;
            if (Gid > 0)
                wgR.Update(model);
            return Success("操作成功");
        }

        public ActionResult SaveCModify(GameCategoryModel model)
        {
            model.Createtime = DateTime.Now;
            if (model.CID > 0)
                wgcR.Update(model);
            else
                wgcR.Insert(model);

            return Success("操作成功");
        }


        public ActionResult SaveModify(GameModel model)
        {
            model.GCreatetime = DateTime.Now;
            if (model.GID > 0)
                wgR.Update(model);
            else
                wgR.Insert(model);

            return Success("操作成功");
        }


        /// <summary>
        /// 获取分类列表
        /// </summary>
        /// <param name="pagination"></param>
        /// <returns></returns>
        public ActionResult GetCItems(Pagination pagination)
        {
            var exp = ExtLinq.True<GameCategoryModel>();
            var data = new
            {
                rows = wgcR.IQueryable(exp).OrderBy(t => t.CID).ToList(),
                total = pagination.total,
                page = pagination.page,
                records = pagination.records
            };
            return Content(data.ToJson());
        }


        /// <summary>
        /// 获取详情列表
        /// </summary>
        /// <param name="pagination"></param>
        /// <param name="lAid"></param>
        /// <param name="keyword"></param>
        /// <returns></returns>
        public ActionResult GetItems(Pagination pagination, long? Cid, string keyword)
        {
            var exp = ExtLinq.True<GameModel>();
            if (Cid > 0)
                exp.And(t => t.GCategory == Cid);

            if (!string.IsNullOrEmpty(keyword))
            {
                exp.And(t => t.GName.Contains(keyword));
            }

            var data = new
            {
                rows = wgR.IQueryable(exp).OrderBy(t => t.GSorce).ToList(),
                total = pagination.total,
                page = pagination.page,
                records = pagination.records
            };
            return Content(data.ToJson());
        }


        public ActionResult GetFormData(long CID)
        {
            var model = wgcR.FindEntity(CID);
            return Content(model.ToJson());
        }

        public ActionResult GetGameData(long Gid)
        {
            var model = wgR.FindEntity(Gid);
            return Content(model.ToJson());
        }

        /// <summary>
        /// 获取树列表
        /// </summary>
        /// <returns></returns>
        public ActionResult GetTreeList()
        {
            var data = wgcR.IQueryable().ToList();
            var treeList = new List<TreeViewModel>();
            foreach (GameCategoryModel item in data)
            {
                TreeViewModel tree = new TreeViewModel();
                bool hasChildren = data.Count(t => t.PID == item.CID) == 0 ? false : true;
                tree.id = item.CID.ToString();
                tree.text = item.CName;
                tree.value = item.CID.ToString();
                tree.parentId = item.PID.ToString();
                tree.isexpand = true;
                tree.complete = true;
                tree.hasChildren = hasChildren;
                treeList.Add(tree);
            }
            return Content(treeList.TreeViewJson());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult GetTreeSelectJson()
        {
            var data = wgcR.IQueryable().ToList();
            var treeList = new List<TreeSelectModel>();
            foreach (GameCategoryModel item in data)
            {
                TreeSelectModel treeModel = new TreeSelectModel();
                treeModel.id = item.CID.ToString();
                treeModel.text = item.CName;
                treeModel.parentId = item.PID.ToString();
                treeList.Add(treeModel);
            }
            return Content(treeList.TreeSelectJson());
        }

    }
}