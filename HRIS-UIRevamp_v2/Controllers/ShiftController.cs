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
    public class ShiftController : ServerController
    {
        public ShiftController()
        {
            client.BaseAddress = baseurl;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Add()
        {
            ShiftAddViewModel model = new ShiftAddViewModel();
            return View("Add", model);
        }

        public async Task<ActionResult> SearchResult(ShiftIndexViewModel data)
        {
            if (data.queries == null)
            {
                return View("Index", data);
            }
            else
            {
                var postTask = await client.PostAsJsonAsync("/api/Shift/Search", data);
                var shift = await postTask.Content.ReadAsAsync<ShiftSearchViewModel>();
                return Json(shift, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public async Task<ActionResult> Add(ShiftAddViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    model.active = true;
                    model.createdBy = Session["user_id"].ToString();
                    model.createdDatetime = DateTime.Now;
                    var postTask = await client.PostAsJsonAsync("/api/Shift/Add", model);
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

        public async Task<ActionResult> Edit(string comp_id, string sft_id)
        {
            if (sft_id != null && comp_id != null)
            {
                ShiftUpdateViewModel model = new ShiftUpdateViewModel();
                var postTask = await client.GetAsync("/api/Shift/View/?comp_id=" + comp_id + "&sft_id=" + sft_id);
                model = await postTask.Content.ReadAsAsync<ShiftUpdateViewModel>();
                if (model != null)
                {
                    return View("Edit", model);
                }
                else
                {
                    ShiftIndexViewModel data = new ShiftIndexViewModel();
                    ViewBag.Error = "No Shift Found !";
                    return View("Index", data);
                }
            }
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }

        [HttpPost]
        public async Task<ActionResult> Update(ShiftUpdateViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    model.active = true;
                    model.modifiedBy = Session["user_id"].ToString();
                    model.modifiedDatetime = DateTime.Now;
                    var postTask = await client.PostAsJsonAsync("/api/Shift/Update", model);
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

        public new async Task<ActionResult> View(string comp_id, string sft_id)
        {
            if (sft_id != null && comp_id != null)
            {
                ShiftUpdateViewModel model = new ShiftUpdateViewModel();
                var postTask = await client.GetAsync("/api/Shift/View/?comp_id=" + comp_id + "&sft_id=" + sft_id);
                model = await postTask.Content.ReadAsAsync<ShiftUpdateViewModel>();
                if (model != null)
                {
                    return View("View", model);
                }
                else
                {
                    ShiftIndexViewModel data = new ShiftIndexViewModel();
                    ViewBag.Error = "No Shift Found !";
                    return View("Index", data);
                }
            }
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }
    }
}