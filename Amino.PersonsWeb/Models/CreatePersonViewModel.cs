using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using WebGrease.Css;

namespace Amino.PersonsWeb.Models
{
    public class CreatePersonViewModel
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Fornavn skal være udfyldt")]
        [Display(Name = "Fornavn")]
        public string Firstname { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Efternavn skal være udfyldt")]
        [Display(Name = "Efternavn")]
        public string Lastname { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Adressse skal være udfyldt")]
        [Display(Name = "Adresse")]
        public string Address { get; set; }

        public ZipCodeViewModel SelectZipCode { get; set; }

        [Required(ErrorMessage = "Der skal angives en fødselsdato")]
        [Display(Name = "Fødselsdato")]
        public DateTime DateOfBirth { get; set; }
    }
}