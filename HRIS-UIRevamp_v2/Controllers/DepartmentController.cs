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
    public class DepartmentController : BaseController
    {
        // GET: Department
        public ActionResult Index()
        {
            DepartmentIndexViewModel model = new DepartmentIndexViewModel();
            return View("Index", model);
        }


        public async Task<ActionResult> SearchResult(DepartmentIndexViewModel data)
        {
            if (data.queries == null)
            {
                return View("Index", data);
            }
            else
            {
                var postTask = await client.PostAsJsonAsync("/api/Department/Search", data);
                var UserResult = await postTask.Content.ReadAsAsync<DepartmentSearchViewModel>();
                return Json(UserResult, JsonRequestBehavior.AllowGet);
            }
        }
    }
}