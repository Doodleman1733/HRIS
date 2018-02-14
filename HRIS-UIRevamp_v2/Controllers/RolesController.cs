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
    public class RolesController : ServerController
    {
        public RolesController()
        {
            client.BaseAddress = baseurl;
        }
        public ActionResult Index()
        {
            RoleIndexViewModel model = new RoleIndexViewModel();
            return View("Index", model);
        }


        public async Task<ActionResult> SearchResult(RoleIndexViewModel data)
        {

            if (data.queries == null)
            {
                return View("Index", data);
            }
            else
            {
                var postTask = await client.PostAsJsonAsync("/api/Roles/Search", data);
                var UserResult = await postTask.Content.ReadAsAsync<RoleSearchViewModel>();
                return Json(UserResult, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult Add()
        {
            RoleAddViewModel model = new RoleAddViewModel();
            return View("Add", model);
        }

        [HttpPost]
        public async Task<ActionResult> Add(RoleAddViewModel data)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    data.active = true;
                    data.createdBy = Session["user_id"].ToString();
                    data.createdDatetime = DateTime.Now;
                    var postTask = await client.PostAsJsonAsync("/api/Roles/Add", data);
                    if (postTask.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Index", "Roles");
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

        public async Task<ActionResult> Edit(string comp_id, string role_id)
        {
            if (comp_id != null && role_id != null)
            {
                RoleUpdateViewModel model = new RoleUpdateViewModel();
                var postTask = await client.GetAsync("/api/Roles/View/?comp_id=" + comp_id + "&role_id=" + role_id);
                model = await postTask.Content.ReadAsAsync<RoleUpdateViewModel>();
                if (model != null)
                {
                    return View("Edit", model);
                }
                else
                {
                    RoleIndexViewModel data = new RoleIndexViewModel();
                    ViewBag.Error = "No Role Found !";
                    return View("Index", data);
                }
            }
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }

        [HttpPost]
        public async Task<ActionResult> Update(RoleUpdateViewModel data)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    data.active = true;
                    data.modifiedBy = Session["user_id"].ToString();
                    data.modifiedDatetime = DateTime.Now;
                    client.BaseAddress = baseurl;
                    var postTask = await client.PostAsJsonAsync("/api/Roles/Update", data);
                    if (postTask.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Index", "Roles");
                    }
                    else
                    {
                        ViewBag.Error = postTask.ReasonPhrase;
                        return View("Update", ViewBag.Error);
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

        public new async Task<ActionResult> View(string comp_id ,string role_id)
        {
            if (comp_id != null && role_id != null)
            {
                RoleUpdateViewModel model = new RoleUpdateViewModel();
                var postTask = await client.GetAsync("/api/Roles/View/?comp_id=" + comp_id + "&role_id=" + role_id);
                model = await postTask.Content.ReadAsAsync<RoleUpdateViewModel>();
                if (model != null)
                {
                    return View("View", model);
                }
                else
                {
                    RoleIndexViewModel data = new RoleIndexViewModel();
                    ViewBag.Error = "No Role Found !";
                    return View("Index", data);
                }
            }
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }
    }
}