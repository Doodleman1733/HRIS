using System;
using System.Collections.Generic;
using System.Web.Mvc;
using HRIS_UIRevamp_v2.ViewModel;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net;

namespace HRIS_UIRevamp_v2.Controllers
{
    public class DocumentNumberController : ServerController
    {
        public DocumentNumberController()
        {
            client.BaseAddress = baseurl;
        }

        public ActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> SearchResult(DocumentNumberIndexViewModel data)
        {
            if (data.queries == null)
            {
                return View("Index", data);
            }
            else
            {
                var postTask = await client.PostAsJsonAsync("/api/DocumentNumber/Search", data);
                var UserResult = await postTask.Content.ReadAsAsync<DocumentNumberSearchViewModel>();
                return Json(UserResult, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult Add()
        {
            DocumentNumberAddViewModel data = new DocumentNumberAddViewModel();
            return View("Add", data);
        }

        [HttpPost]
        public async Task<ActionResult> Add(DocumentNumberAddViewModel data)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    data.active = true;
                    data.createdDateTime = DateTime.Now;
                    data.createdBy = Session["user_id"].ToString();
                    var postTask = await client.PostAsJsonAsync("/api/DocumentNumber/Add", data);
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

        public async Task<ActionResult> Edit(string comp_id, string doc_id)
        {
            if (comp_id != null && doc_id != null)
            {
                DocumentNumberUpdateViewModel model = new DocumentNumberUpdateViewModel();
                var postTask = await client.GetAsync("/api/DocumentNumber/View/?comp_id=" + comp_id + "&doc_id=" + doc_id);
                model = await postTask.Content.ReadAsAsync<DocumentNumberUpdateViewModel>();
                if (model != null)
                {
                    return View("Edit", model);
                }
                else
                {
                    DocumentNumberIndexViewModel data = new DocumentNumberIndexViewModel();
                    ViewBag.Error = "No Document Found !";
                    return View("Index", data);
                }
            }

            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }

        [HttpPost]
        public async Task<ActionResult> Update(DocumentNumberUpdateViewModel data)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    data.active = true;
                    data.modifiedDateTime = DateTime.Now;
                    data.modifiedBy = Session["user_id"].ToString();
                    var postTask = await client.PostAsJsonAsync("/api/DocumentNumber/Update", data);
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

        public new async Task<ActionResult> View(string comp_id, string doc_id)
        {
            if (comp_id != null && doc_id != null)
            {
                DocumentNumberUpdateViewModel model = new DocumentNumberUpdateViewModel();
                var postTask = await client.GetAsync("/api/DocumentNumber/View/?comp_id=" + comp_id + "&doc_id=" + doc_id);
                model = await postTask.Content.ReadAsAsync<DocumentNumberUpdateViewModel>();
                if (model != null)
                {
                    return View("View", model);
                }
                else
                {
                    DocumentNumberIndexViewModel data = new DocumentNumberIndexViewModel();
                    ViewBag.Error = "No Document Found !";
                    return View("Index", data);
                }
            }

            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }
    }
}
