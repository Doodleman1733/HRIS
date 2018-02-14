using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HRIS_UIRevamp_v2.Controllers
{
    public class LayoutController : Controller
    {
        // GET: Layout
        public ActionResult Sidebar()
        {
            return PartialView("~/Views/Shared/_Sidebar.cshtml");
        }

        public ActionResult ButtonLinks()
        {
            return PartialView("~/Views/Shared/_ButtonLinks.cshtml");
        }
    }
}