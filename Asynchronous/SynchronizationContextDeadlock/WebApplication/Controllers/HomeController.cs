using SharedLibrary;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication.Controllers
{
    public class HomeController : Controller
    {
        readonly Log log;
        readonly RemoteHelper remoteHelper;

        public HomeController()
        {
            log = new Log();
            remoteHelper = new RemoteHelper(log);
        }

        public ActionResult Index()
        {
            log.Write("HomeController.Index");
            var resp = remoteHelper.GetResponse();
            log.Write("HomeController.Index");
            return View();
        }

        public ActionResult About()
        {
            log.Write("HomeController.Index");
            var resp = remoteHelper.GetResponseDeadlock();
            log.Write("HomeController.Index");
            return View();
        }
    }

    class Log : BaseLog
    {
        protected override void WriteImplementation(string msg)
        {
            Debug.WriteLine(msg);
        }
    }
}