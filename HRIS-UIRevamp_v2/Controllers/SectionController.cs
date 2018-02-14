using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HRIS_UIRevamp_v2.ViewModel;
using System.Threading.Tasks;
using System.Net.Http;

namespace HRIS_UIRevamp_v2.Controllers
{
    public class SectionController : BaseController
    {
        // GET: Section
        public ActionResult Index()
        {
            SectionIndexViewModel model = new SectionIndexViewModel();
            return View("Index", model);
        }


        public async Task<ActionResult> SearchResult(SectionIndexViewModel data)
        {
            if (data.queries == null)
            {
                return View("Index", data);
            }
            else
            {
                var postTask = await client.PostAsJsonAsync("/api/Section/Search", data);
                var UserResult = await postTask.Content.ReadAsAsync<SectionSearchViewModel>();
                return Json(UserResult, JsonRequestBehavior.AllowGet);
            }
        }
    }
}