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
    public class CalendarController : ServerController
    {
        public CalendarController()
        {
            client.BaseAddress = baseurl;
        }

        public ActionResult Index()
        {
            CalendarIndexViewModel model = new CalendarIndexViewModel();
            return View("Index", model);
        }

        public async Task<ActionResult> SearchResult(CalendarIndexViewModel data)
        {

            if (data.queries == null)
            {
                CalendarIndexViewModel model = new CalendarIndexViewModel();

                return View("SearchResult", model);
            }
            else
            {
                var postTask = await client.PostAsJsonAsync("/api/Calendar/Search", data);
                var UserResult = await postTask.Content.ReadAsAsync<CalendarSearchViewModel>();
                return Json(UserResult, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult Add()
        {

            CalendarAddViewModel model = new CalendarAddViewModel();
            return View("Add", model);
        }

        [HttpPost]
        public async Task<ActionResult> Add(CalendarAddViewModel data)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    data.active = true;
                    data.createdBy = Session["user_id"].ToString();
                    List<CalendarCompanySetup> elements = new List<CalendarCompanySetup>();
                    {
                        foreach (CalendarCompanySetup dp in data.companies)
                        {
                            elements.Add(new CalendarCompanySetup()
                            {
                                comp_id = dp.comp_id,
                                createdDateTime = DateTime.Now,
                                createdBy = Session["user_id"].ToString()
                        });
                        }
                    }
                    data.companies = elements;
                    var postTask = await client.PostAsJsonAsync("/api/Calendar/Add", data);
                    if (postTask.IsSuccessStatusCode)
                    {
                        return Json(true, JsonRequestBehavior.DenyGet);
                    }
                }
                catch
                {
                    return Json(false, JsonRequestBehavior.DenyGet);
                }

            }
            return Json(false, JsonRequestBehavior.DenyGet);
        }

        public async Task<ActionResult> View(long? cal_id)
        {
            if (cal_id != null)
            {
                CalendarUpdateViewModel model = new CalendarUpdateViewModel();
                var postTask = await client.GetAsync("/api/Calendar/View/?cal_id=" + cal_id);
                model = await postTask.Content.ReadAsAsync<CalendarUpdateViewModel>();
                if (model != null)
                {
                    return View("View", model);
                }
                else
                {
                    CalendarIndexViewModel data = new CalendarIndexViewModel();
                    ViewBag.Error = "No Activity Found !";
                    return View("Index", data);
                }
            }
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

        }

        public async Task<ActionResult> Edit(long? cal_id)
        {
            if (cal_id != null)
            {
                CalendarUpdateViewModel model = new CalendarUpdateViewModel();
                var postTask = await client.GetAsync("/api/Calendar/View/?cal_id=" + cal_id);
                model = await postTask.Content.ReadAsAsync<CalendarUpdateViewModel>();
                if (model != null)
                {
                    return View("Edit", model);
                }
                else
                {
                    CalendarIndexViewModel data = new CalendarIndexViewModel();
                    ViewBag.Error = "No Activity Found !";
                    return View("Index", data);
                }
            }
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }

        [HttpPost]
        public async Task<ActionResult> Edit(CalendarUpdateViewModel data)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    data.active = true;
                    data.modifiedBy = Session["user_id"].ToString();
                    data.modifiedDateTime = DateTime.Now;
                    List<CalendarCompanySetup> elements = new List<CalendarCompanySetup>();
                    {
                        foreach (CalendarCompanySetup dp in data.companies)
                        {
                            elements.Add(new CalendarCompanySetup()
                            {
                                comp_id = dp.comp_id,
                                modifiedDateTime = DateTime.Now,
                                modifiedBy = Session["user_id"].ToString()
                        });
                        }
                    }
                    data.companies = elements;
                    var postTask = await client.PostAsJsonAsync("/api/Calendar/Update", data);
                    if (postTask.IsSuccessStatusCode)
                    {
                        return Json(true, JsonRequestBehavior.DenyGet);
                    }
                }
                catch (Exception)
                {
                    return Json(false, JsonRequestBehavior.DenyGet);
                }
            }
            return Json(false, JsonRequestBehavior.DenyGet);
        }
    }
}