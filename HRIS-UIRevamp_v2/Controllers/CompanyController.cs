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
    public class CompanyController : ServerController
    {
        public CompanyController()
        {
            client.BaseAddress = baseurl;
        }

        public ActionResult Index()
        {
            CompanyIndexViewModel model = new CompanyIndexViewModel();
            return View("Index", model);
        }

        
        public async Task<ActionResult> SearchResult(CompanyIndexViewModel data)
        {

            if (data.queries == null)
            {
                return View("Index", data);
            }
            else
            {
                var postTask = await client.PostAsJsonAsync("/api/Company/Search", data);
                var UserResult = await postTask.Content.ReadAsAsync<CompanySearchViewModel>();
                return Json(UserResult, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult Add()
        {
            CompanyAddViewModel model = new CompanyAddViewModel();
            return View("Add", model);
        }

        [HttpPost]
        public async Task<ActionResult> Add(CompanyAddViewModel data)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    data.active = true;
                    data.createdBy = Session["user_id"].ToString();
                    data.createdDatetime = DateTime.Now;
                    var postTask = await client.PostAsJsonAsync("/api/Company/Add", data);
                    if (postTask.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Index", "Company");
                    }
                }
                catch (Exception e)
                {
                    ViewBag.Error = e.Message;
                    return View("Index", ViewBag.Error);
                }
            }
            return RedirectToActionPermanent("Index");
        }

        public async Task<ActionResult> Edit(string comp_id)
        {
            if (comp_id != null)
            {
                CompanyUpdateViewModel model = new CompanyUpdateViewModel();
                var postTask = await client.GetAsync("/api/Company/View/?comp_id=" + comp_id);
                model = await postTask.Content.ReadAsAsync<CompanyUpdateViewModel>();
                if (model != null)
                {
                    return View("Edit", model);
                }
                else
                {
                    CompanyIndexViewModel data = new CompanyIndexViewModel();
                    ViewBag.Error = "No Company Found !";
                    return View("Index", data);
                }
            }
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }

        [HttpPost]
        public async Task<ActionResult> Update(CompanyUpdateViewModel data)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    data.active = true;
                    data.modifiedBy = Session["user_id"].ToString();
                    data.modifiedDatetime = DateTime.Now;
                    var postTask = await client.PostAsJsonAsync("/api/Company/Update", data);
                    if (postTask.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Index", "Company");
                    }
                }
                catch (Exception e)
                {
                    ViewBag.Error = e.Message;
                    return View("Index", ViewBag.Error);
                }

            }
            var errors = ModelState.Select(x => x.Value.Errors)
               .Where(y => y.Count > 0)
               .ToList();

            return RedirectToActionPermanent("Index");
        }

        public new async Task<ActionResult> View(string comp_id)
        {
            if (comp_id != null)
            {
                CompanyUpdateViewModel model = new CompanyUpdateViewModel();
                var postTask = await client.GetAsync("/api/Company/View/?comp_id=" + comp_id);
                model = await postTask.Content.ReadAsAsync<CompanyUpdateViewModel>();
                if (model != null)
                {
                    return View("View", model);
                }
                else
                {
                    CompanyIndexViewModel data = new CompanyIndexViewModel();
                    ViewBag.Error = "No Company Found !";
                    return View("Index", data);
                }
            }
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }
    }
}