using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC.Models;

namespace MVC.Controllers
{
    public class MyController : Controller
    {
        //Cannot be Accessed from outside
        string Get() => "1234";

        //Cannot be Accessed from outside
        [NonAction]
        public string Get2() => "5678";
        
        //Can be Accessed from outside with GET and POST (Default Behavior)
        public string Get3() => "9999";

        //Can be Accessed from outside with GET
        [HttpGet]
        public string Get4() => "9999";

        //Can be Accessed from outside with GET
        [AcceptVerbs(HttpVerbs.Get)]
        public string Get5() => "9999";

        //Can be Accessed from outside with GET and POST
        [AcceptVerbs(HttpVerbs.Get | HttpVerbs.Post)]
        public string Get6() => "9999";

        [HttpGet]
        public ActionResult GetView1() => View("View1");

        [HttpGet]
        public ActionResult GetView2()
        {
            Class1 a = new Class1 { A = "A", B = "B" };
            ViewBag.HelloBag = a;
            //ViewData.Add("Hello", a);
            return View("TestView");
        }

        [HttpGet]
        public ActionResult GetView3()
        {
            Class1 a = new Class1 { A = "A", B = "B" };
            return View("StrongView", a);
        }

        [HttpPost]
        public void PostByModelBinder(Class1 c)
        {
            bool isValid = ModelState.IsValid;
            if (!isValid)
            {
                var values = ModelState.Values;
                List<ModelErrorCollection> errors = new List<ModelErrorCollection>();
                foreach(ModelState v in values)
                {
                    errors.Add(v.Errors);
                }
            }
            else
            {
            }
        }

        [HttpPost]
        public void PostByModelBinder2(string A, string B)
        {
            bool isValid = ModelState.IsValid;
            if (!isValid)
            {
                var values = ModelState.Values;
                List<ModelErrorCollection> errors = new List<ModelErrorCollection>();
                foreach (ModelState v in values)
                {
                    errors.Add(v.Errors);
                }
            }
            Class1 c = new Class1 { A = A, B = B };
        }

        [HttpPost]
        public void PostManual()
        {
            Class1 c = new Class1();
            c.A = Request.Form["A"];
            c.B = Request.Form["B"];
        }

        [HttpGet]
        public string WriteHTML()
        {
            return @"<!DOCTYPE html>
<html>
<head>
<title>Page Title</title>
</head>
<body>

<h1>This is a Heading</h1>
<p>This is a paragraph.</p>

</body>
</html>";
        }
    }
}