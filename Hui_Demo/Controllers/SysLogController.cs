using Hui_Demo.Common;
using Hui_Demo.Helper;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Hui_Demo.Controllers
{
    public class SysLogController:_BaseController 
    {

        public ActionResult Index(string UserName,string StartTime, string EndTime)
        {
            var timer = InitTime(ref StartTime, ref EndTime);
            var ctx = ContextHelper.Create();
            var query = ctx.SysLog .AsQueryable();   //AsQueryable是在数据库中查询再返回数据,in
            if (!String.IsNullOrEmpty(UserName ))    //根据名字查询
            {
                query = query.Where(x => x.UserName.Contains(UserName));
                ViewBag.UserName = UserName;
            }
            query = query.Where(x => x.LogTime >= timer.StartTime && x.LogTime <= timer.EndTime);

            var list = query.ToList();

            return View(list);
        }

        public ActionResult SystemData()
        {
            return View();
        }



        public ActionResult SystemCategory()
        {
            return View();
        }

        public ActionResult Delete(string ID)
        {
            var ctx = ContextHelper.Create();
            List<int> ids = new List<int>();
            foreach (var i in ID.Split(','))
            {
                int id = Convert.ToInt32(i);
                ids.Add(id);
            }
            var list = ctx.Post.Where(x => ids.Contains(x.ID));
            ctx.Post.RemoveRange(list);
            ctx.SaveChangesAsync();
            return Json(new Success(), JsonRequestBehavior.AllowGet);
        }
    }
}