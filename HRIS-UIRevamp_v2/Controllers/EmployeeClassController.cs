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
    public class EmployeeClassController : ServerController
    {
        public EmployeeClassController()
        {
            client.BaseAddress = baseurl;
        }

        public ActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> SearchResult(EmployeeClassIndexViewModel data)
        {
            if (data.queries == null)
            {
                return View("Index", data);
            }
            else
            {
                var postTask = await client.PostAsJsonAsync("/api/EmployeeClass/Search", data);
                var empClass = await postTask.Content.ReadAsAsync<EmployeeClassSearchViewModel>();
                return Json(empClass, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult Add()
        {
            EmployeeClassAddViewModel model = new EmployeeClassAddViewModel();
            ViewBag.ShiftId = new List<string>();
            return View("Add", model);
        }

        [HttpPost]
        public async Task<ActionResult> Add(EmployeeClassAddViewModel data)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    data.createdDateTime = DateTime.Now;
                    data.createdBy = Session["user_id"].ToString();
                    var postTask = await client.PostAsJsonAsync("/api/EmployeeClass/Add", data);
                    if (postTask.IsSuccessStatusCode)
                    {
                        return Json(true, JsonRequestBehavior.DenyGet);
                    }
                }
                catch (Exception e)
                {
                    return Json(e.Message, JsonRequestBehavior.DenyGet);
                }
            }

            return Json(false, JsonRequestBehavior.DenyGet);
        }

        public async Task<ActionResult> Edit(string comp_id, string class_id)
        {
            if (class_id != null && comp_id != null)
            {
                EmployeeClassUpdateViewModel model = new EmployeeClassUpdateViewModel();
                var postTask = await client.GetAsync("/api/EmployeeClass/View/?comp_id=" + comp_id + "&class_id=" + class_id);
                model = await postTask.Content.ReadAsAsync<EmployeeClassUpdateViewModel>();
                if (model != null)
                {
                    return View("Edit", model);
                }
                else
                {
                    EmployeeClassIndexViewModel data = new EmployeeClassIndexViewModel();
                    ViewBag.Error = "No Employee Class Found !";
                    return View("Index", data);
                }
            }

            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }

        [HttpPost]
        public async Task<ActionResult> Update(EmployeeClassUpdateViewModel data)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    data.modifiedDateTime = DateTime.Now;
                    data.modifiedBy = Session["user_id"].ToString();
                    var postTask = await client.PostAsJsonAsync("/api/EmployeeClass/Update", data);
                    if (postTask.IsSuccessStatusCode)
                    {
                        return Json(true, JsonRequestBehavior.DenyGet);
                    }
                }
                catch (Exception e)
                {
                    return Json(e.Message, JsonRequestBehavior.DenyGet);
                }
            }

            return Json(false, JsonRequestBehavior.DenyGet);
        }

        public new async Task<ActionResult> View(string comp_id, string class_id)
        {
            if (class_id != null && comp_id != null)
            {
                EmployeeClassUpdateViewModel model = new EmployeeClassUpdateViewModel();
                var postTask = await client.GetAsync("/api/EmployeeClass/View/?comp_id=" + comp_id + "&class_id=" + class_id);
                model = await postTask.Content.ReadAsAsync<EmployeeClassUpdateViewModel>();
                if (model != null)
                {
                    return View("View", model);
                }
                else
                {
                    EmployeeClassIndexViewModel data = new EmployeeClassIndexViewModel();
                    ViewBag.Error = "No Employee Class Found !";
                    return View("Index", data);
                }
            }

            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }
    }
}