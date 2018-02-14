using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using HRIS_UIRevamp_v2.ViewModel;
using System.Threading.Tasks;

namespace HRIS_UIRevamp_v2.Controllers
{
    public class BaseController : Controller
    {
        // GET: Base //
        protected HttpClient client = new HttpClient();
        protected Uri baseurl = new Uri("http://localhost:50301");

        protected async override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            try
            {
                ClientKeyViewModel key = new ClientKeyViewModel();
                ClientTokenViewModel token = new ClientTokenViewModel();
                if (Session["user_id"] != null)
                {
                    key.user_id = Session["user_id"].ToString();
                    client.BaseAddress = baseurl;
                    var ClientToken = client.PostAsJsonAsync("api/Server/Token", key).Result;
                    if (ClientToken.ReasonPhrase != "Bad Request")
                    {
                        var ClientTokenResult = await ClientToken.Content.ReadAsAsync<ClientTokenViewModel>();
                        client.DefaultRequestHeaders.Add("Token", ClientTokenResult.client_token);
                    }                    
                    else
                    {
                        filterContext.Result = new RedirectResult("~/Login/Index");
                    }
                }
                else
                {
                    TempData["error"] = "Session Expired.";
                    filterContext.Result = new RedirectResult("~/Login/Index");
                }
            }
            catch (Exception e)
            {
                TempData["error"] = e.Message;
                filterContext.Result = new RedirectResult("~/Login/Index");
            }
        }
    }
}