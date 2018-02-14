using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace HRIS_UIRevamp_v2.Controllers
{
    public class ServerController : Controller
    {
        // GET: Server
        protected HttpClient client = new HttpClient();
        protected Uri baseurl = new Uri("http://localhost:50301");
        //protected Uri baseurl = new Uri("http://mcpihqsvra10:8450/");
        protected bool ret = false;

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            Session["user_id"] = "Edmund";
        }
    }
}