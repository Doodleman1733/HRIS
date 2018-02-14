using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using HRIS_UIRevamp_v2.ViewModel;
using System.Net.Http;

namespace HRIS_UIRevamp_v2.Controllers
{
    public class UserRegisterController : ServerController
    {
        public UserRegisterController()
        {
            client.BaseAddress = baseurl;
        }

        public ActionResult Index()
        {
            return View("Register");
        }

        [HttpPost]
        public async Task<ActionResult> Register(RegisterViewModel data)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    data.active = true;
                    var postTask = await client.PostAsJsonAsync("/api/Register", data);
                    if (postTask.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Index", "Login");
                    }
                    else
                    {
                        ViewBag.Error = postTask.ReasonPhrase;
                        return View("Register");
                    }

                }
                catch (Exception e)
                {
                    ViewBag.Error = "Unexpected Error.";
                    return View("Register");
                }

            }
            return RedirectToActionPermanent("Index");
        }
    }
}