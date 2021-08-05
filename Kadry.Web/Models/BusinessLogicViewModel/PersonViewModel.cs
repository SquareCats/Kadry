using System;
using System.ComponentModel.DataAnnotations;

namespace Kadry.Web.Models.BusinessLogicViewModel
{
    public class PersonViewModel : BaseViewModel
    {
        [StringLength(60)]
        [Required(ErrorMessage = "pole nazwisko musi być wypełnione")]
        [Display(Name = "nazwisko")]
        public string Name { get; set; }
        [StringLength(50)]
        [Required(ErrorMessage = "pole imię musi być wypełnione")]
        [Display(Name = "imię")]
        public string FirstName { get; set; }
        [StringLength(11)]
        [Required(ErrorMessage = "pole pesel musi być wypełnione")]
        [Display(Name = "nr PESEL")]
        public string SocialNumber { get; set; }
        [Display(Name = "data urodzenia")]
        [Required(ErrorMessage = "pole data urodzenia musi być wypełnione")]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }
        public string Description { get { return string.Format("{0} {1} - {2}", Name, FirstName, Id); } }
    }
}
