using Kadry.Web.Models.Dictionaries;
using System;
using System.ComponentModel.DataAnnotations;

namespace Kadry.Web.Models.BusinessLogicViewModel
{
    public class PositionViewModel : BaseViewModel
    {
        [Required(ErrorMessage = "pole stanowisko musi być wypełnione")]
        [Display(Name = "stanowisko")]
        public PositionDictionaryViewModel Position { get; set; }
        [Required(ErrorMessage = "pole od dnia musi być wypełnione")]
        [Display(Name = "od dnia")]
        public DateTime From { get; set; }
        public string FromTxt { get { return From.ToShortDateString(); } }
        [Required(ErrorMessage = "pole do dnia musi być wypełnione")]
        [Display(Name = "do dnia")]
        public DateTime? To { get; set; }
        public string ToTxt { get { return To.HasValue?To.Value.ToShortDateString():""; } }
        [StringLength(200)]
        [Required(ErrorMessage = "pole nr umowy musi być wypełnione")]
        [Display(Name = "nr umowy")]
        public string ContractNumber { get; set; }
        [Required(ErrorMessage = "pole data umowy musi być wypełnione")]
        [Display(Name = "data umowy")]
        public DateTime ContractDate { get; set; }
        public string ContractDateTxt { get { return ContractDate.ToShortDateString(); } }

        public PersonViewModel Person { get; set; }
    }
}
