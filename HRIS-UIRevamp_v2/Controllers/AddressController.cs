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
    public class AddressController : ServerController
    {
        // GET: Address
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Add()
        {
            AddressAddViewModel model = new AddressAddViewModel();
            return View("Add", model);
        }

        [HttpPost]
        public async Task<ActionResult> Add(AddressAddViewModel data)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    data.active = true;
                    data.createdBy = Session["user_id"].ToString();
                    data.createDateTime = DateTime.Now;
                    client.BaseAddress = baseurl;
                    var postTask = await client.PostAsJsonAsync("/api/Address/Add", data);
                    if (postTask.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Index", "Address");
                    }
                }
                catch (Exception e)
                {
                    ViewBag.Error = e.Message;
                    return View("Add", ViewBag.Error);
                }

            }
            return RedirectToActionPermanent("Index");
        }


        public async Task<ActionResult> View(long? id)
        {
            if (id != null)
            {
                client.BaseAddress = baseurl;
                AddressUpdateViewModel model = new AddressUpdateViewModel();
                var postTask = await client.GetAsync("/api/Address/View/?id=" + id);
                model = await postTask.Content.ReadAsAsync<AddressUpdateViewModel>();
                if (model != null)
                {
                    return View("View", model);
                }
                //else
                //{
                //    CalendarIndexViewModel data = new CalendarIndexViewModel();
                //    ViewBag.Error = "No Activity Found !";
                //    return View("Index", data);
                //}
            }
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

        }


        public async Task<ActionResult> Edit(string id)
        {
            if (id != null)
            {
                client.BaseAddress = baseurl;
                AddressUpdateViewModel model = new AddressUpdateViewModel();
                var postTask = await client.GetAsync("/api/Address/View/?id=" + id);
                model = await postTask.Content.ReadAsAsync<AddressUpdateViewModel>();
                if (model != null)
                {
                    return View("Edit", model);
                }
                else
                {
                    AddressIndexViewModel data = new AddressIndexViewModel();
                    ViewBag.Error = "No Address Found !";
                    return View("Index", data);
                }
            }
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }

        [HttpPost]
        public async Task<ActionResult> Update(AddressUpdateViewModel data)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    data.active = true;
                    data.modifiedBy = Session["user_id"].ToString();
                    data.modifiedDateTime = DateTime.Now;
                    client.BaseAddress = baseurl;
                    var postTask = await client.PostAsJsonAsync("/api/Address/Update", data);
                    if (postTask.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Index", "Address");
                    }
                }
                catch (Exception e)
                {
                    ViewBag.Error = e.Message;
                    return View("Update", ViewBag.Error);
                }

            }
            var errors = ModelState.Select(x => x.Value.Errors)
               .Where(y => y.Count > 0)
               .ToList();

            return RedirectToActionPermanent("Index");
        }
    }
}