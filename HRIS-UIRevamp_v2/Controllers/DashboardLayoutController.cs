using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HRIS_UIRevamp_v2.ViewModel;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net;

namespace HRIS_UIRevamp_v2.Controllers
{
    public class DashboardLayoutController : ServerController
    {
        // GET: DashboardLayout
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Add()
        {
            DashboardLayoutAddViewModel data = new DashboardLayoutAddViewModel();
            data.active = true;
            return View("Add",data);
        }

        [HttpPost]
        public async Task<ActionResult> Add(DashboardLayoutAddViewModel data)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    data.active = true;
                    data.createdBy = Session["user_id"].ToString();
                    data.createdDateTime = DateTime.Now;
                    client.BaseAddress = baseurl;
                    var postTask = await client.PostAsJsonAsync("/api/DashboardLayout/Add", data);
                    if (postTask.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Index", "DashboardLayout");
                    }
                }
                catch (Exception e)
                {
                    ViewBag.Error = e.Message;
                    return View("Add", ViewBag.Error);
                }

            }
            var errors = ModelState.Select(x => x.Value.Errors)
               .Where(y => y.Count > 0)
               .ToList();

            return RedirectToActionPermanent("Index");
        }

        public async Task<ActionResult> Edit(string layout_id)
        {
            if (layout_id != null)
            {
                client.BaseAddress = baseurl;
                DashboardLayoutUpdateViewModel model = new DashboardLayoutUpdateViewModel();
                var postTask = await client.GetAsync("/api/DashboardLayout/View/?layout_id=" + layout_id);
                model = await postTask.Content.ReadAsAsync<DashboardLayoutUpdateViewModel>();
                if (model != null)
                {
                    return View("Edit", model);
                }
                else
                {
                    //DivisionIndexViewModel data = new DivisionIndexViewModel();
                    //ViewBag.Error = "No Division Found !";
                    //return View("Index", data);
                }
            }

            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }
    }
}