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
    public class WorkflowController : ServerController
    {
        public WorkflowController()
        {
            client.BaseAddress = baseurl;
        }

        public ActionResult Index()
        {
            WorkflowIndexViewModel model = new WorkflowIndexViewModel();
            return View("Index", model);
        }

        public async Task<ActionResult> SearchResult(WorkflowIndexViewModel data)
        {

            if (data.queries == null)
            {
                return View("Index", data);
            }
            else
            {
                var postTask = await client.PostAsJsonAsync("/api/Workflow/Search", data);
                var UserResult = await postTask.Content.ReadAsAsync<WorkflowSearchViewModel>();
                return Json(UserResult, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult Add()
        {
            WorkflowAddViewModel model = new WorkflowAddViewModel();
            return View("Add", model);
        }

        [HttpPost]
        public async Task<ActionResult> Add(WorkflowAddViewModel data)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    data.createdBy = Session["user_id"].ToString();
                    data.createdDateTime = DateTime.Now;
                    var postTask = await client.PostAsJsonAsync("/api/Workflow/Add", data);
                    if (postTask.IsSuccessStatusCode)
                    {
                        return Json(true, JsonRequestBehavior.DenyGet);
                    }
                }
                catch (Exception e)
                {
                    return Json(e.Message, JsonRequestBehavior.DenyGet); ;
                }

            }
            return Json(false, JsonRequestBehavior.DenyGet);
        }

        public async Task<ActionResult> Edit(string comp_id, string wflw_id)
        {
            if (comp_id != null && wflw_id != null)
            {
                WFModel model = new WFModel();
                var postTask = await client.GetAsync("/api/Workflow/View/?comp_id=" + comp_id + "&wflw_id=" + wflw_id);
                model = await postTask.Content.ReadAsAsync<WFModel>();
                if (model != null)
                {
                    return View("Edit", model);
                }
                else
                {
                    RoleIndexViewModel data = new RoleIndexViewModel();
                    ViewBag.Error = "No Workflow Found !";
                    return View("Index", data);
                }
            }
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }

        [HttpPost]
        public async Task<ActionResult> Update(WorkflowUpdateViewModel data)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    data.modifiedBy = Session["user_id"].ToString();
                    data.modifiedDateTime = DateTime.Now;
                    var postTask = await client.PostAsJsonAsync("/api/Workflow/Update", data);
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

        public new async Task<ActionResult> View(string comp_id, string wflw_id)
        {
            if (comp_id != null && wflw_id != null)
            {
                WFModel model = new WFModel();
                var postTask = await client.GetAsync("/api/Workflow/View/?comp_id=" + comp_id + "&wflw_id=" + wflw_id);
                model = await postTask.Content.ReadAsAsync<WFModel>();
                if (model != null)
                {
                    return View("View", model);
                }
                else
                {
                    WorkflowIndexViewModel data = new WorkflowIndexViewModel();
                    ViewBag.Error = "No Workflow Found !";
                    return View("Index", data);
                }
            }
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }

        public async Task<ActionResult> TableList(string module)
        {
            WFModel model = new WFModel();
            var postTask = await client.GetAsync("/api/Workflow/TableList/?module=" + module);
            return Json(await postTask.Content.ReadAsAsync<List<ModuleTableSetupViewModel>>(), JsonRequestBehavior.AllowGet);
        }

        public async Task<ActionResult> FieldList(string module, string table)
        {
            WFModel model = new WFModel();
            var postTask = await client.GetAsync("/api/Workflow/FieldList/?module=" + module + "&table=" + table);
            return Json(await postTask.Content.ReadAsAsync<List<ModuleTableSetupViewModel>>(), JsonRequestBehavior.AllowGet);
        }
    }
}