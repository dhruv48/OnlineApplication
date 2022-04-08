
using Microsoft.AspNetCore.Http;
using OnlineApplication.Common.Entities;
using OnlineApplication.Common.EnumHelper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OnlineApplication.Common.Model
{
    public class RegistrationModel:CommonModel
    {
        [Display(Name="Capacity*")]
        [Required(ErrorMessage = "Capacity is required!")]
        public Capacity Capacity { get; set; }

        [Display(Name = "Name*")]
        [Required(ErrorMessage ="Name is required!")]
        public string Name { get; set; }

        [Display(Name = "Company*")]
        [Required(ErrorMessage = "Company is required!")]
        public string Company { get; set; }

        [Display(Name = "Designation*")]
        [Required(ErrorMessage = "Designation is required!")]
        public string Designation { get; set; }

        [Display(Name = "Email Id*")]
        [Required(ErrorMessage = "Please put a valid email")]
        [RegularExpression(@"^[^@\s]+@[^@\s]+\.[^@\s]+$")]
        //[CustomEmailAddress]
        public string EmailId { get; set; }

        [Display(Name = "Contact Number*")]
        [Required(ErrorMessage = "Please put a valid 10 digit Contact no.")]
        [RegularExpression(@"^[0-9]{10}$")]
        
        public string ContactNumber { get; set; }

        [Display(Name = "Category*")]
        [Required(ErrorMessage = "Category is required!")]
        public CategoryOptions Category { get; set; }

        [Display(Name = "Please Choose Your engagement with PILOT*")]
        [Required(ErrorMessage = "EngagementWithPilot is required!")]
        public EngagementWithPiolt EngagementWithPilot { get; set; }

        [Display(Name="Technical Parameters*")]
        [Required(ErrorMessage = "TechnicalParameters is required!")]
        public List<EnumModel> CheckBoxTechnicalParameters { get; set; }

        [Display(Name="Drag Your PDF Here")]
        [Required]
        public IFormFile RegisterPDF { get; set; }

        public string RegisterPDFUrl { get; set; }


    }
}
