using Hui_Demo.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Hui_Demo.Controllers
{
    public class ValidateCodeController : Controller
    {
        // GET: ValidateCode
        public ActionResult Index()
        {
            int width = 120;
            int height = 40;
            int fontsize = 18;
            string code = string.Empty;
            byte[] bytes = ValidateCodeHelper.CreateValidateGraphic(out code, 4, width, height, fontsize);
            Session["VCode"] = code;
            return File(bytes, @"image/jpeg");
        }
    }
}