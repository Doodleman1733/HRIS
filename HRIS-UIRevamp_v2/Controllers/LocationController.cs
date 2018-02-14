using System;
using System.Collections.Generic;
using System.Web.Mvc;
using HRIS_UIRevamp_v2.ViewModel;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net;

namespace HRIS_UIRevamp_v2.Controllers
{
    public class LocationController : ServerController
    {
        public LocationController()
        {
            client.BaseAddress = baseurl;
        }

        public ActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> SearchResult(LocationIndexViewModel data)
        {
            if (data.queries == null)
            {
                return View("Index", data);
            }
            else
            {
                var postTask = await client.PostAsJsonAsync("/api/Location/Search", data);
                var division = await postTask.Content.ReadAsAsync<LocationSearchViewModel>();
                return Json(division, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult Add()
        {
            LocationAddViewModel model = new LocationAddViewModel();
            return View("Add", model);
        }

        [HttpPost]
        public async Task<ActionResult> Add(LocationAddViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    model.active = true;
                    model.createdDatetime = DateTime.Now;
                    model.createdBy = Session["user_id"].ToString();
                    var postTask = await client.PostAsJsonAsync("/api/Location/Add", model);
                    if (postTask.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Index", "Location");
                    }
                }
                catch (Exception e)
                {
                    ViewBag.Error = e.Message;
                    return View("Add");
                }
            }
            return RedirectToActionPermanent("Index");
        }

        public async Task<ActionResult> Edit(string comp_id, string loc_id)
        {
            if (loc_id != null && comp_id != null)
            {
                LocationUpdateViewModel model = new LocationUpdateViewModel();
                var postTask = await client.GetAsync("/api/Location/View/?comp_id=" + comp_id + "&loc_id=" + loc_id);
                model = await postTask.Content.ReadAsAsync<LocationUpdateViewModel>();
                if (model != null)
                {
                    return View("Edit", model);
                }
                else
                {
                    LocationIndexViewModel data = new LocationIndexViewModel();
                    ViewBag.Error = "No Location Found !";
                    return View("Index", data);
                }
            }
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }

        [HttpPost]
        public async Task<ActionResult> Update(LocationUpdateViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    model.active = true;
                    model.modifiedDatetime = DateTime.Now;
                    model.modifiedBy = Session["user_id"].ToString();
                    var postTask = await client.PostAsJsonAsync("/api/Location/Update", model);
                    if (postTask.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Index", "Location");
                    }
                }
                catch (Exception e)
                {
                    ViewBag.Error = e.Message;
                    return View("Update");
                }
            }
            return RedirectToActionPermanent("Index");
        }

        public new async Task<ActionResult> View(string comp_id, string loc_id)
        {
            if (loc_id != null && comp_id != null)
            {
                LocationUpdateViewModel model = new LocationUpdateViewModel();
                var postTask = await client.GetAsync("/api/Location/View/?comp_id=" + comp_id + "&loc_id=" + loc_id);
                model = await postTask.Content.ReadAsAsync<LocationUpdateViewModel>();
                if (model != null)
                {
                    return View("View", model);
                }
                else
                {
                    LocationIndexViewModel data = new LocationIndexViewModel();
                    ViewBag.Error = "No Location Found !";
                    return View("Index", data);
                }
            }

            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }
    }
}
