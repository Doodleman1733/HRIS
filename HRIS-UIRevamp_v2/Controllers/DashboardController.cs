using HRIS_UIRevamp_v2.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace HRIS_UIRevamp_v2.Controllers
{
    public class DashboardController : Controller
    {
        // GET: Dashboard
        public ActionResult Index()
        {
            List<DashboardLayoutViewModel> layout = new List<DashboardLayoutViewModel>();
            layout.Add(new DashboardLayoutViewModel {
                layout_id="test",
                widget_id="calendar",
                positionleft=0,
                positiontop=15,
                url="Dashboard/_Calendar.cshtml"
            });

            layout.Add(new DashboardLayoutViewModel
            {
                layout_id = "test",
                widget_id = "quoute",
                positionleft = 53,
                positiontop = 15,
                url = "Dashboard/_Quote.cshtml"
            });

            return View(layout);
        }
    }
}