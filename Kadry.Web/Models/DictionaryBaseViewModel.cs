using System.ComponentModel.DataAnnotations;

namespace Kadry.Web.Models
{
    public class DictionaryBaseViewModel : BaseViewModel
    {
        [Required]
        [Display(Name = "sort")]
        public int Sort { get; set; }
        [Required]
        [Display(Name = "wartość")]
        public string Name { get; set; }
        [Display(Name = "opis")]
        public string Description { get; set; }
}
}
