using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AtheepIntergraphTask.Models
{
    [MetadataType(typeof(CustomerMetaData))]
    public class CustomerModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Job { get; set; }
        public string MobileNo { get; set; }
        public string Email { get; set; }
        public Nullable<System.DateTime> BirthDate { get; set; }
        public int CompanyId { get; set; }
        public IEnumerable<SelectListItem> Companies { get; set; }
    }
    public class CustomerMetaData
    {
        [Display(Name =  "Name")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Name Required")]
        public string Name { get; set; }

        [Display(Name = "Job Title")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Job Title Required")]
        public string Job { get; set; }

        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Mobile Number")]
        public string MobileNo { get; set; }

        [Display(Name = "Email")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Email Required")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Display(Name = "Birth Date")]
        [DataType(DataType.Date)]
        public Nullable<System.DateTime> BirthDate { get; set; }

        [Display(Name = "Company Name ")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Select Company")]
        public int CompanyId { get; set; }
    }
}