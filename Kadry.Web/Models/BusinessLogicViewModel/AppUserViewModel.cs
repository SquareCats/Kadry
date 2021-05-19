
using System;
using System.ComponentModel.DataAnnotations;

namespace Kadry.Web.Models.BusinessLogicViewModel
{
    public class AppUserViewModel 
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        [Required]
        [Display(Name = "id")]
        public int Id { get; set; }
        //[Display(Name = "utworzono przez ")]
        //public AppUserViewModel CreatedBy { get; set; }
        //[Display(Name = "utworzono")]
        //public DateTime CreatedOn { get; set; }
        //[Display(Name = "zmieniono przez")]
        //public AppUserViewModel ChangedBy { get; set; }
        [Display(Name = "zmieniono")]
        public DateTime? ChangedOn { get; set; }
        public Guid ObjectGuid { get; set; }
    }
}
