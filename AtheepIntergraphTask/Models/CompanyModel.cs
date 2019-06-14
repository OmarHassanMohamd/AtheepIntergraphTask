using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AtheepIntergraphTask.Models
{
    [MetadataType(typeof(CompanyMetaData))]
    public class CompanyModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string PhoneNo { get; set; }
        public string Code { get; set; }
        public string LogoPath { get; set; }
        public byte[] Logo { get; set; }
        public HttpPostedFileBase ImageFile { get; set; }

    }

    public class CompanyMetaData
    {
        [Display(Name = "Name")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Name Required")]
        public string Name { get; set; }

        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Mobile Number")]
        public string PhoneNo { get; set; }

        [Display(Name = "Postal Code")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Postal Code Required")]
        [DataType(DataType.PostalCode)]
        [MaxLength(2, ErrorMessage = "Maximum 2 characters required")]
        public string Code { get; set; }

        [Display(Name = "Logo")]
        public string Logo { get; set; }
    }
}