using System;
using System.ComponentModel.DataAnnotations;

namespace Kadry.Web.Models
{
    public abstract class BaseViewModel
    {

        [Required]
        [Display(Name = "id")]
        public int Id { get; set; }
        [Display(Name = "utworzono przez ")]
        public int CreatedBy { get; set; }
        [Display(Name = "utworzono")]
        public DateTime CreatedOn { get; set; }
        [Display(Name = "zmieniono przez")]
        public int? ChengedBy { get; set; }
        [Display(Name = "zmieniono")]
        public DateTime? ChangedOn { get; set; }
        public Guid ObjectGuid { get; set; }

    }
}
