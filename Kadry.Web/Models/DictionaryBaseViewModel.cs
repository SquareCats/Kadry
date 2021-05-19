using System.ComponentModel.DataAnnotations;

namespace Kadry.Web.Models
{
    public class DictionaryBaseViewModel : BaseViewModel
    {
        [Required(ErrorMessage ="Pole sort jest wymagane")]
        [Display(Name = "sort")]
        public int Sort { get; set; }
        [Required(ErrorMessage = "Pole wartość jest wymagane")]
        [Display(Name = "wartość")]
        public string Name { get; set; }
        [Display(Name = "opis")]
        public string Description { get; set; }
}
}
