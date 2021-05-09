using System.ComponentModel.DataAnnotations;

namespace Kadry.Web.Models.BusinessLogicViewModel
{
   
    public class CountryViewModel : BaseViewModel
    {
        [Required]
        [Display(Name = "nazwa państwa")]
        public string Name { get; set; }
    }
}
