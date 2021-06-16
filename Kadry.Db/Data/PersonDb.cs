using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Kadry.Db.Data
{
    [Table("Person", Schema = "Hr")]
    public class PersonDb : MyEntity
    {
        [StringLength(60)]
        [Display(Name="nazwisko")]
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

        public List<PositionDb> Positions;
    }
}
