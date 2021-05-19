using System;
using System.ComponentModel.DataAnnotations;

namespace Kadry.Web.Models.BusinessLogicViewModel
{
    public class PersonViewModel :BaseViewModel
    {
        [StringLength(60)]
        [Display(Name = "nazwisko")]
        public string Name { get; set; }
        [StringLength(50)]
        [Display(Name = "imię")]
        public string FirstName { get; set; }
        [StringLength(11)]
        [Display(Name = "nr PESEL")]
        public string SocialNumber { get; set; }
        [Display(Name = "data urodzenia")]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }
    }
}
