using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Amino.PersonsWeb.Models
{
    public class ZipCodeViewModel
    {
        [Display(Name = "Postnr")]
        [Required(ErrorMessage = "Vælg venligst et postnummer..")]
        public string SelectedZipCode { get; set; }

        public IEnumerable<SelectListItem> ZipCodes { get; set; }
    }
}
