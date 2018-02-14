using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using HRIS_UIRevamp_v2.ViewModel;
using System.Net.Http;
using System.Web.Http.Controllers;
using System.Net;

namespace HRIS_UIRevamp_v2.Controllers
{
    public class LoginController : ServerController
    {
        // GET: Login
        public ActionResult Index()
        {
            ViewBag.error = TempData["error"] != null ? TempData["error"] : "";
            return View("Login");
        }

        [HttpPost]
        public async Task<ActionResult> Verify(LoginViewModel data)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    ClientKeyViewModel key = new ClientKeyViewModel();
                    key.user_id = data.user_id;
                    key.valid = true;
                    key.createdDateTime = DateTime.Now;
                    client.BaseAddress = baseurl;
                    var User = client.PostAsJsonAsync("api/Login/CheckUser", data).Result;
                    var Login = client.PostAsJsonAsync("api/Login/Login", data).Result;
                    var UserResult = await User.Content.ReadAsAsync<LoginResponseViewModel>();
                    var LoginResult = await Login.Content.ReadAsAsync<LoginResponseViewModel>();
                    if (UserResult != null)
                    {
                        if (LoginResult != null)
                        {
                            if (LoginResult.active == false)
                            {
                                ViewBag.Error = "Account is inactive. Contact your system administrator.";
                                return View("Login");
                            }

                            if (LoginResult.locked == true)
                            {
                                ViewBag.Error = "Account is locked. Contact your system administrator.";
                                return View("Login");
                            }

                            var ClientKey = client.PostAsJsonAsync("api/Server/Server", key).Result;
                            if (ClientKey.ReasonPhrase == "Bad Request")
                            {
                                ViewBag.Error = "Bad Request.";
                                return View("Login");
                            }
                            var ClientTokenResult = await ClientKey.Content.ReadAsAsync<ClientTokenViewModel>();
                            Session["user_id"] = LoginResult.user_id;
                            Session.Timeout =(int) ClientTokenResult.expiresOn.Subtract(ClientTokenResult.createdDateTime).TotalMinutes;
                            Session["fname"] = LoginResult.fname;
                            var cookie = new HttpCookie("user_id");
                            cookie.Value = LoginResult.user_id;
                            Response.Cookies.Add(cookie);
                            await client.PutAsJsonAsync("api/login/ResetAttempts", data);
                            return RedirectToAction("Index", "Dashboard");
                        }

                        if (UserResult.locked == false)
                        {
                            var loginAttempts = client.PostAsJsonAsync("api/Login/UpdateAttempts", data).Result;
                            ViewBag.Error = "Invalid Login. You have " + (5 - UserResult.loginAttempts) + " attempt(s) left.";
                        }
                        else
                        {
                            ViewBag.Error = "Account Locked.";
                        }
                    }
                }
                catch (Exception e)
                {
                    ViewBag.Error = e.Message;
                }
            }
            else
            {
                ViewBag.Error = "Invalid Login.";
            }
            return View("Login");
        }
    }
}