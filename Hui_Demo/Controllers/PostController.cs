using Hui_Demo.Common;
using Hui_Demo.Helper;
using Hui_Demo.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Hui_Demo.Controllers
{
    public class PostController : _BaseController
    {
        public ActionResult Index(string Title)
        {
            var ctx = ContextHelper.Create();
            var query = ctx.Post.AsQueryable();   //AsQueryable是在数据库中查询再返回数据,in
            if (!String.IsNullOrEmpty(Title))    //根据名字查询
            {
                query = query.Where(x => x.Title .Contains(Title));
                ViewBag.Title = Title;
            }
            var list = query.ToList();
            return View(list);
        }
        public ActionResult Add()
        {
            return View();
        }
        public ActionResult Save(Hui_Demo.Models.Entities.Post model )
        {
            var ctx = ContextHelper.Create();
            try
            {
                if (model.Title != "调研专业负责人" && model.Title != "评价专业负责人" && model.Title != "专业人员" && model.Title != "管理员")
                {
                    var entity = new Post();
                    entity.Title = model.Title;
                    entity.Description = model.Description;
                    entity.SFFZY = model.SFFZY;
                    entity.TypeFlag = model.TypeFlag;
                    //  entity.IsSystem = false;
                    //  entity.Extra = model.Extra;
                    entity.IsSystem = 0;
                    entity.DeleteFlag = false;
                    ctx.Post.Add(entity);
                }
                else
                {
                    return Json(new Error("职务中已经存在此职位！"), JsonRequestBehavior.AllowGet);
                }
                var Errors = ctx.GetValidationErrors();
                if (Errors.Count() > 0)
                {
                    string Message = "";
                    foreach (var E in Errors)
                    {
                        foreach (var e in E.ValidationErrors)
                        {
                            Message += String.Format("{0}:{1}", e.PropertyName, e.ErrorMessage);
                            Message += Environment.NewLine;
                        }
                    }
                    return Json(new Error(Message));
                }
                else
                {
                    ctx.SaveChanges();
                    //UserLog("添加职务：" + model.Title);
                    //return Json(new Success().TabID("PostList"), JsonRequestBehavior.AllowGet);
                    //return Json(new Success(), JsonRequestBehavior.AllowGet);
                    return Content("<script >alert('提交留言成功，谢谢对我们支持，我们会根据您提供联系方式尽快与您取的联系！');window.location.reload();</script>");
                }
            }
            catch (Exception ex)
            {
                return Json(new Error(ex.Message), JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult Del()
        {
            return View();
        }

        //真删
        public ActionResult Delete(string IDs)
        {
            List<int> idList = new List<int>();
            foreach (var i in IDs.Split(','))
            {
                int id = Convert.ToInt32(i);
                idList.Add(id);
            }
            var ctx = ContextHelper.Create();
            var list = ctx.Post.Where(x => idList.Contains(x.ID));
            ctx.Post.RemoveRange(list);
            ctx.SaveChangesAsync();
            return Json(new Success(), JsonRequestBehavior.AllowGet);
        }

        //真多删
        public ActionResult Deletes(List<int> IDs)
        {
            List<int> idList = new List<int>();
            foreach (var i in IDs)
            {
                int id = Convert.ToInt32(i);
                idList.Add(id);
            }
            var ctx = ContextHelper.Create();
            var list = ctx.Post.Where(x => idList.Contains(x.ID));
            ctx.Post.RemoveRange(list);
            ctx.SaveChangesAsync();
            return Json(new Success(), JsonRequestBehavior.AllowGet);
        }



        public  ActionResult DeleteFlag(string IDs)
        {
            //假删
            var ctx = ContextHelper.Create();
            List<int> ids = new List<int>();
            foreach (var i in IDs.Split(','))
            {
                int id = Convert.ToInt32(i);
                ids.Add(id);
            }
            var list = ctx.Post.Where(x => ids.Contains(x.ID));  
            foreach (var i in list)
            {
                i.DeleteFlag = true;
            }
            ctx.SaveChangesAsync();
            return Json(new Success(), JsonRequestBehavior.AllowGet);
        }

    }
}