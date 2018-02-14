using HRIS_UIRevamp_v2.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace HRIS_UIRevamp_v2.Controllers
{
    public class UserRoleController : ServerController
    {
        // GET: UserRole
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<ActionResult> Add()
        {
            UserRoleAddViewModel model = new UserRoleAddViewModel();
            client.BaseAddress = baseurl;
            var modules = client.GetAsync("api/LookUp/getAllModules/").Result;
            model.modules = await modules.Content.ReadAsAsync<List<ModuleViewModel>>();


            var moduleActions = client.GetAsync("api/LookUp/moduleAction/").Result;
            List<ModuleActionViewModel> modAction = await moduleActions.Content.ReadAsAsync<List<ModuleActionViewModel>>();
            foreach (var mod in model.modules)
            {
                mod.moduleActions = new List<ModuleActionViewModel>();
                mod.moduleActions.AddRange(modAction.Where(x => x.module_id == mod.module_id));
            }

            return View(model);
        }
    }
}