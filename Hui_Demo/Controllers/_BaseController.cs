using Hui_Demo.Common;
using Hui_Demo.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace Hui_Demo.Controllers
{
    public class _BaseController : Controller
    {

        protected Timer InitTime(ref string StartTime, ref string EndTime, int Years = 0)
        {
            Timer timer = new Timer();
            try
            {
                if (String.IsNullOrEmpty(StartTime))
                    StartTime = DateTime.Now.AddYears(0 - Years).ToString("yyyy-01-01");
                timer.StartTime = Convert.ToDateTime(StartTime);
                ViewBag.StartTime = StartTime;
                if (String.IsNullOrEmpty(EndTime))
                    EndTime = DateTime.Now.ToString("yyyy-MM-dd");
                timer.OriginEndTime = Convert.ToDateTime(EndTime);
                timer.EndTime = timer.OriginEndTime.AddDays(1);
                ViewBag.EndTime = EndTime;
                return timer;
            }
            catch
            {
                StartTime = DateTime.Now.ToString("yyyy-01-01");
                timer.StartTime = Convert.ToDateTime(StartTime);
                EndTime = DateTime.Now.ToString("yyyy-MM-dd");
                timer.OriginEndTime = Convert.ToDateTime(EndTime);
                timer.EndTime = timer.OriginEndTime.AddDays(1);
                return timer;
            }
        }
    }


}