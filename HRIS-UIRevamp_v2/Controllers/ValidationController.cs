using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using HRIS_UIRevamp_v2.ViewModel;
using System.Net.Http;
using HRIS_UIRevamp_v2.Helper;

namespace HRIS_UIRevamp_v2.Controllers
{
    public class ValidationController : ServerController
    {
        public ValidationController()
        {
            client.BaseAddress = baseurl;
        }

        private async Task<bool> checkUser(string user_id)
        {
            var result = await client.GetAsync("api/validation/checkUser/?user_id=" + user_id);
            return await result.Content.ReadAsAsync<bool>();

        }

        public async Task<JsonResult> CheckUserIfExist(RegisterViewModel data)
        {
            return await checkUser(data.user_id)
                ? Json(true, JsonRequestBehavior.AllowGet)
                : Json(false, JsonRequestBehavior.AllowGet);
        }

        private async Task<bool> checkCompany(string comp_id)
        {
            var result = await client.GetAsync("api/validation/Company/" + comp_id);
            return await result.Content.ReadAsAsync<bool>();

        }

        public async Task<JsonResult> CheckCompanyIfExist(CompanyAddViewModel data)
        {
            return await checkCompany(data.comp_id)
                ? Json(true, JsonRequestBehavior.AllowGet)
                : Json(false, JsonRequestBehavior.AllowGet);
        }

        private async Task<bool> checkDivision(string comp_id, string div_id)
        {
            var url = "api/validation/Division/?comp_id=" + comp_id + "&div_id=" + div_id;
            var result = await client.GetAsync(url);
            return await result.Content.ReadAsAsync<bool>();

        }

        public async Task<JsonResult> CheckDivisionIfExist(string comp_id, string div_id)
        {
            return (comp_id == null) || await checkDivision(comp_id, div_id)
                ? Json(true, JsonRequestBehavior.AllowGet)
                : Json(false, JsonRequestBehavior.AllowGet);
        }

        private async Task<bool> checkDocument(string comp_id, string doc_id)
        {
            var url = "api/validation/Document/?comp_id=" + comp_id + "&doc_id=" + doc_id;
            var result = await client.GetAsync(url);
            return await result.Content.ReadAsAsync<bool>();

        }

        public async Task<JsonResult> CheckDocumentNumberIfExist(string comp_id, string doc_id)
        {
            return (comp_id == null) || await checkDocument(comp_id, doc_id)
                ? Json(true, JsonRequestBehavior.AllowGet)
                : Json(false, JsonRequestBehavior.AllowGet);
        }

        private async Task<bool> checkDeparment(string comp_id, string div_id, string dept_id)
        {
            var result = await client.GetAsync("api/validation/Department/?comp_id=" + comp_id + "&div_id=" + div_id + "&dept_id=" + dept_id);
            return await result.Content.ReadAsAsync<bool>();

        }

        public async Task<JsonResult> CheckDepartmentIfExist(string comp_id, string div_id, string dept_id)
        {
            return await checkDeparment(comp_id, div_id, dept_id)
                ? Json(true, JsonRequestBehavior.AllowGet)
                : Json(false, JsonRequestBehavior.AllowGet);
        }

        private async Task<bool> checkSection(string sect_id)
        {
            var result = await client.GetAsync("api/validation/Section/" + sect_id);
            return await result.Content.ReadAsAsync<bool>();

        }

        public async Task<JsonResult> CheckSectionIfExist(SectionAddViewModel data)
        {
            return await checkSection(data.sect_id)
                ? Json(true, JsonRequestBehavior.AllowGet)
                : Json(false, JsonRequestBehavior.AllowGet);
        }

        private async Task<bool> checkShift(string comp_id, string sft_Id)
        {
            var result = await client.GetAsync("api/validation/Shift/?comp_id=" + comp_id + "&sft_Id=" + sft_Id);
            return await result.Content.ReadAsAsync<bool>();

        }

        public async Task<JsonResult> checkShiftIfExist(ShiftAddViewModel data)
        {
            return await checkShift(data.comp_id, data.sft_Id)
                ? Json(true, JsonRequestBehavior.AllowGet)
                : Json(false, JsonRequestBehavior.AllowGet);
        }

        private async Task<bool> checkLocation(string comp_id, string loc_id)
        {
            var result = await client.GetAsync("api/validation/Location/?comp_id=" + comp_id + "&loc_id=" + loc_id);
            return await result.Content.ReadAsAsync<bool>();

        }

        public async Task<JsonResult> checkLocationIfExist(LocationAddViewModel data)
        {
            return await checkLocation(data.comp_id, data.loc_id)
                ? Json(true, JsonRequestBehavior.AllowGet)
                : Json(false, JsonRequestBehavior.AllowGet);
        }

        private async Task<bool> checkRole(string comp_id, string role_id)
        {
            var result = await client.GetAsync("api/validation/Role/?comp_id=" + comp_id + "&role_id=" + role_id);
            return await result.Content.ReadAsAsync<bool>();

        }

        public async Task<JsonResult> checkRoleIfExist(RoleAddViewModel data)
        {
            return await checkRole(data.comp_id, data.role_id)
                ? Json(true, JsonRequestBehavior.AllowGet)
                : Json(false, JsonRequestBehavior.AllowGet);
        }

        private async Task<bool> checkClass(string comp_id, string class_id)
        {
            var result = await client.GetAsync("api/validation/EmployeeClass/?comp_id=" + comp_id + "&class_id=" + class_id);
            return await result.Content.ReadAsAsync<bool>();

        }

        public async Task<JsonResult> checkClassfExist(EmployeeClassAddViewModel data)
        {
            return await checkClass(data.comp_id, data.class_id)
                ? Json(true, JsonRequestBehavior.AllowGet)
                : Json(false, JsonRequestBehavior.AllowGet);
        }

        private async Task<bool> checkDocumentNumber(string comp_id, string doc_id)
        {
            var result = await client.GetAsync("api/validation/DocumentNumber/?comp_id=" + comp_id + "&comp_id=" + doc_id);
            return await result.Content.ReadAsAsync<bool>();

        }

        private async Task<bool> checkWorkflow(string comp_id, string wflw_id)
        {
            var result = await client.GetAsync("api/validation/Workflow/?comp_id=" + comp_id + "&wflw_id=" + wflw_id);
            return await result.Content.ReadAsAsync<bool>();

        }

        public async Task<JsonResult> checkWorkflowIfExist(WorkflowAddViewModel data)
        {
            return await checkWorkflow(data.comp_id, data.wflw_id)
                ? Json(true, JsonRequestBehavior.AllowGet)
                : Json(false, JsonRequestBehavior.AllowGet);
        }

        private async Task<bool> checkUserRole(string c_role_id)
        {
            var result = await client.GetAsync("api/validation/confRole/?c_role_id=" + c_role_id);
            return await result.Content.ReadAsAsync<bool>();

        }

        public async Task<JsonResult> CheckUserRoleIfExist(UserRoleAddViewModel data)
        {
            return await checkUserRole(data.c_role_id)
                ? Json(true, JsonRequestBehavior.AllowGet)
                : Json(false, JsonRequestBehavior.AllowGet);
        }
    }
}