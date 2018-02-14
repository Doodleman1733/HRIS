using System;
using System.Collections.Generic;
using System.Web.Mvc;
using HRIS_UIRevamp_v2.ViewModel;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net;
using System.Linq;

namespace HRIS_UIRevamp_v2.Controllers
{
    public class DivisionController : ServerController
    {
        public DivisionController()
        {
            client.BaseAddress = baseurl;
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Add()
        {
            DivisionAddViewModel model = new DivisionAddViewModel();
            return View("Add", model);
        }

        public async Task<ActionResult> SearchResult(DivisionIndexViewModel data)
        {
            if (data.queries == null)
            {
                return View("Index", data);
            }
            else
            {
                var postTask = await client.PostAsJsonAsync("/api/Division/Search", data);
                var division = await postTask.Content.ReadAsAsync<DivisionSearchViewModel>();
                return Json(division, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public async Task<ActionResult> Add(DivisionAddViewModel data)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    data.active = true;
                    data.createdDatetime = DateTime.Now;
                    data.createdBy = Session["user_id"].ToString();
                    var postTask = await client.PostAsJsonAsync("/api/Division/Add", data);
                    if (postTask.IsSuccessStatusCode)
                    {
                        return Json(true, JsonRequestBehavior.DenyGet);
                    }
                }
                catch (Exception e)
                {
                    return Json(false, JsonRequestBehavior.DenyGet);
                }
            }
            var errors = ModelState.Select(x => x.Value.Errors)
               .Where(y => y.Count > 0)
               .ToList();

            return Json(false, JsonRequestBehavior.DenyGet);
        }

        public async Task<ActionResult> Edit(string comp_id, string div_id)
        {
            if (div_id != null && comp_id != null)
            {
                client.BaseAddress = baseurl;
                DivisionViewModel model = new DivisionViewModel();
                var postTask = await client.GetAsync("/api/Division/View/?comp_id=" + comp_id + "&div_id=" + div_id);
                model = await postTask.Content.ReadAsAsync<DivisionViewModel>();
                if (model != null)
                {
                    model.departments = model.departments.OrderBy(x => x.name1).ToList();
                    model.sections = model.sections.OrderBy(x => x.dept_id).OrderBy(x => x.name1).ToList();
                    return View("Edit", model);
                }
                else
                {
                    DivisionIndexViewModel data = new DivisionIndexViewModel();
                    ViewBag.Error = "No Division Found !";
                    return View("Index", data);
                }
            }

            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }

        [HttpPost]
        public async Task<ActionResult> Update(DivisionUpdateViewModel data)
        {   
            if (ModelState.IsValid)
            {
                try
                {
                    data.active = true;
                    data.modifiedDatetime = DateTime.Now;
                    data.modifiedBy = Session["user_id"].ToString();
                    var postTask = await client.PostAsJsonAsync("/api/Division/Update", data);
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
            var errors = ModelState.Select(x => x.Value.Errors)
               .Where(y => y.Count > 0)
               .ToList();

            return Json(false, JsonRequestBehavior.DenyGet);
        }

        public new async Task<ActionResult> View(string comp_id, string div_id)
        {
            if (div_id != null && comp_id != null)
            {
                DivisionViewModel model = new DivisionViewModel();
                var postTask = await client.GetAsync("/api/Division/View/?comp_id=" + comp_id + "&div_id=" + div_id);
                model = await postTask.Content.ReadAsAsync<DivisionViewModel>();
                if (model != null)
                {
                    model.departments = model.departments.OrderBy(x => x.name1).ToList();
                    model.sections = model.sections.OrderBy(x => x.dept_id).OrderBy(x => x.name1).ToList();
                    return View("View", model);
                }
                else
                {
                    DivisionIndexViewModel data = new DivisionIndexViewModel();
                    ViewBag.Error = "No Division Found !";
                    return View("Index", data);
                }
            }

            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }
    }
}