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
    public class LookUpController : ServerController
    {
        public LookUpController()
        {
            client.BaseAddress = baseurl;
        }
        
        public async Task<ActionResult> AllowedFieldsPerUser()
        {
            var result = client.GetAsync("api/LookUp/KEYVALUE/").Result;
            return Json(await result.Content.ReadAsAsync<List<KeyValueViewModel>>(), JsonRequestBehavior.AllowGet);
        }

        public async Task<ActionResult> AllCompanies()
        {
            var result = client.GetAsync("api/LookUp/getAllCompany/").Result;
            return Json(await result.Content.ReadAsAsync<List<CompanyResult>>(), JsonRequestBehavior.AllowGet);
        }

        public async Task<ActionResult> selectCompany(string comp_id)
        {
            var result = client.GetAsync("api/LookUp/selectCompany/?comp_id=" + comp_id).Result;
            return Json(await result.Content.ReadAsAsync<CompanyUpdateViewModel>(), JsonRequestBehavior.AllowGet);
        }

        public async Task<ActionResult> shiftsPerCompany(string comp_id)
        {
            var result = client.GetAsync("api/LookUp/shiftsPerCompany/?comp_id=" + comp_id).Result;
            var sd = await result.Content.ReadAsAsync<List<ShiftAddViewModel>>();
            return Json(sd, JsonRequestBehavior.AllowGet);
        }

        public async Task<ActionResult> shiftsRulesPerCompany(string comp_id,string sft_Id)
        {
            var result = client.GetAsync("api/LookUp/shiftsRulesPerCompany/?comp_id=" + comp_id + "&sft_Id=" + sft_Id).Result;
            return Json(await result.Content.ReadAsAsync<List<ShiftRuleViewModel>>(), JsonRequestBehavior.AllowGet);
        }

        public async Task<ActionResult> selectClassShiftSetup(string comp_id, string class_id)
        {
            var result = client.GetAsync("api/LookUp/selectClassShiftSetup/?comp_id=" + comp_id + "&class_id=" + class_id).Result;
            return Json(await result.Content.ReadAsAsync<List<ShiftRuleViewModel>>(), JsonRequestBehavior.AllowGet);
        }

        public async Task<ActionResult> selectClassShiftOTSetup(string comp_id, string class_id, string sft_id)
        {
            var result = client.GetAsync("api/LookUp/selectClassShiftOTSetup/?comp_id=" + comp_id + "&class_id=" + class_id + "&sft_id=" + sft_id).Result;
            return Json(await result.Content.ReadAsAsync<List<EmployeeClassShiftRulesViewModel>>(), JsonRequestBehavior.AllowGet);
        }

        public async Task<ActionResult> selectProfileCredentials()
        {
            var result = client.GetAsync("api/LookUp/selectProfileCredentials/").Result;
            return Json(await result.Content.ReadAsAsync<List<ProfileCredentialsViewModel>>(), JsonRequestBehavior.AllowGet);
        }

        public async Task<ActionResult> selectRoleCredentials()
        {
            var result = client.GetAsync("api/LookUp/selectRoleCredentials/").Result;
            return Json(await result.Content.ReadAsAsync<List<RoleCredentialsViewModel>>(), JsonRequestBehavior.AllowGet);
        }

        public async Task<ActionResult> getModules()
        {
            var result = client.GetAsync("api/LookUp/getModules/").Result;
            return Json(await result.Content.ReadAsAsync<List<ModuleViewModel>>(), JsonRequestBehavior.AllowGet);
        }

        public async Task<ActionResult> getAllModules()
        {
            var result = client.GetAsync("api/LookUp/getAllModules/").Result;
            return Json(await result.Content.ReadAsAsync<List<ModuleViewModel>>(), JsonRequestBehavior.AllowGet);
        }

        public async Task<ActionResult> getAllUsers()
        {
            var result = client.GetAsync("api/LookUp/getAllUsers/").Result;
            return Json(await result.Content.ReadAsAsync<List<UserCredentialsIndexViewModel>>(), JsonRequestBehavior.AllowGet);
        }
    }
}