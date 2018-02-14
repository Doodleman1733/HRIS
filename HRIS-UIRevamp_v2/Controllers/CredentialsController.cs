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
    public class CredentialsController : ServerController
    {
        public CredentialsController()
        {
            client.BaseAddress = baseurl;
        }

        public ActionResult Index()
        {
            UserCredentialsIndexViewModel model = new UserCredentialsIndexViewModel();
            return View("Index", model);
        }


        public async Task<ActionResult> SearchResult(UserCredentialsIndexViewModel data)
        {

            if (data.queries == null)
            {
                return View("Index", data);
            }
            else
            {
                var postTask = await client.PostAsJsonAsync("/api/UserCredentials/Search", data);
                var UserResult = await postTask.Content.ReadAsAsync<UserCredentialsSearchViewModel>();
                return Json(UserResult, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult Add()
        {
            UserCredentialsAddViewModel model = new UserCredentialsAddViewModel();
            return View("Add", model);
        }

        [HttpPost]
        public async Task<ActionResult> Add(UserCredentialsAddViewModel data)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    data.active = true;
                    data.createdDateTime = DateTime.Now;
                    data.createdBy = Session["user_id"].ToString();
                    var postTask = await client.PostAsJsonAsync("/api/UserCredentials/Add", data);
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

        public async Task<ActionResult> Edit(string user_id)
        {
            if (user_id != null)
            {
                UserCredentialsUpdateViewModel model = new UserCredentialsUpdateViewModel();
                var postTask = await client.GetAsync("/api/UserCredentials/View/?user_id=" + user_id);
                model = await postTask.Content.ReadAsAsync<UserCredentialsUpdateViewModel>();
                if (model != null)
                {
                    return View("Edit", model);
                }
                else
                {
                    UserCredentialsIndexViewModel data = new UserCredentialsIndexViewModel();
                    ViewBag.Error = "No User Credentials Found !";
                    return View("Index", data);
                }
            }

            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }

        [HttpPost]
        public async Task<ActionResult> Update(UserCredentialsUpdateViewModel data)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    data.active = true;
                    data.modifiedDateTime = DateTime.Now;
                    data.modifiedBy = Session["user_id"].ToString();
                    var postTask = await client.PostAsJsonAsync("/api/UserCredentials/Update", data);
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

        public new async Task<ActionResult> View(string user_id)
        {
            if (user_id != null )
            {
                UserCredentialsUpdateViewModel model = new UserCredentialsUpdateViewModel();
                var postTask = await client.GetAsync("/api/UserCredentials/View/?user_id=" + user_id);
                model = await postTask.Content.ReadAsAsync<UserCredentialsUpdateViewModel>();
                if (model != null)
                {
                    return View("View", model);
                }
                else
                {
                    UserCredentialsIndexViewModel data = new UserCredentialsIndexViewModel();
                    ViewBag.Error = "No User Credentials Found !";
                    return View("Index", data);
                }
            }

            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }
    }
}