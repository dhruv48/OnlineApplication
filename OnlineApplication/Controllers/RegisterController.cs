using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineApplication.Business.InterfaceBusiness;
using OnlineApplication.Common.Entities;
using OnlineApplication.Common.EnumHelper;
using OnlineApplication.Common.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace OnlineApplication.Controllers
{
    public class RegisterController : Controller
    {
        public bool flag;
        private readonly IRegistrationBusiness _registerationBusiness;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public RegisterController(IRegistrationBusiness registrationBusiness, IWebHostEnvironment webHostEnvironment)
        {
            _registerationBusiness = registrationBusiness;
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Insert()
        {
            RegistrationModel registrationModel = new RegistrationModel();
            registrationModel.CheckBoxTechnicalParameters = new List<EnumModel>();
            foreach (TechnicalParameters technicalParameters in Enum.GetValues(typeof(TechnicalParameters)))
            {
                registrationModel.CheckBoxTechnicalParameters.Add(new EnumModel() { TechnicalParameters = technicalParameters, IsSelected = false });
            }
            return View(registrationModel);
        }


        [HttpPost]
        public async Task<IActionResult> InsertAsync(RegistrationModel registrationModel)
        {
            if (ModelState.IsValid)
            {
                if(IsEmail(registrationModel.EmailId))
                {
                    if (registrationModel.RegisterPDF != null)
                    {
                        string folder = "RegisterFile/Pdf/";
                        registrationModel.RegisterPDFUrl = await UploadImageAsync(folder, registrationModel.RegisterPDF);
                    }
                    _registerationBusiness.Add(registrationModel);
                }
                else
                {
                  ViewBag.error = "Please  input Custom Email Address";
                    registrationModel.CheckBoxTechnicalParameters = new List<EnumModel>();
                    foreach (TechnicalParameters technicalParameters in Enum.GetValues(typeof(TechnicalParameters)))
                    {
                        registrationModel.CheckBoxTechnicalParameters.Add(new EnumModel() { TechnicalParameters = technicalParameters, IsSelected = false });
                    }
                    return View(registrationModel);
                }
               
            }

            return RedirectToAction("GetAll");
        }

        public const string MatchEmailPattern = @"^([\w-.]+@(?!gmail\.com)(?!yahoo\.com)(?!hotmail\.com)(?!mail\.ru)(?!yandex\.ru)(?!mail\.com)([\w-]+.)+[\w-]{2,4})?$";
        public bool IsEmail(string email)
        {
            if (email != null) return Regex.IsMatch(email, MatchEmailPattern);
            else return false;
        }


        [HttpGet]
        public IActionResult GetAll()
        {
            IEnumerable<RegistrationModel> registrationModel;
            registrationModel = _registerationBusiness.GetAll();
            flag = true;
            return View(registrationModel);

        }

        public PartialViewResult FilterByCapacity(int id)
        {
            if (id == 0)
            {
                IEnumerable<RegistrationModel> registrationModel;
                registrationModel = _registerationBusiness.GetAll();
                flag = true;
                return PartialView("_GetItem", registrationModel);
            }
            flag = false;
            var model = _registerationBusiness.GetByCapacity(id);
            return PartialView("_GetItem", model);

        }

        public PartialViewResult FilterByCategory(int id)
        {
            if (id == 0)
            {
                IEnumerable<RegistrationModel> registrationModel;
                registrationModel = _registerationBusiness.GetAll();
                flag = true;
                return PartialView("_GetItem",registrationModel);
            }
            flag = false;
            var model = _registerationBusiness.GetByCategory(id);
            return PartialView("_GetItem", model);

        }

        public PartialViewResult FilterByTechnicalParameters(int id)
        {
            if (id == 0)
            {
                IEnumerable<RegistrationModel> registrationModel;
                registrationModel = _registerationBusiness.GetAll();
                flag = true;
                return PartialView("_GetItem", registrationModel);
            }
            flag = false;
            var model = _registerationBusiness.GetByTechnicalParameters(id);
            return PartialView("_GetItem", model);

        }


        private async Task<string> UploadImageAsync(string folderPath, IFormFile file)
        {
            folderPath += Guid.NewGuid().ToString() + "_" + file.FileName;

            string serverFolder = Path.Combine(_webHostEnvironment.WebRootPath, folderPath);

            await file.CopyToAsync(new FileStream(serverFolder, FileMode.Create));

            return "/" + folderPath;
        }

        private Boolean Flag(bool flag)
        {

            return flag;
        }

    }
}
