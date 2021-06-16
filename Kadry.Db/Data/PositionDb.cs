using Kadry.Db.Dictionaries;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kadry.Db.Data
{
    [Table("Position", Schema = "Hr")]
    public class PositionDb : MyEntity
    {
        public PositionDictionaryDb Position { get; set; }
        public DateTime From { get; set; }
        public DateTime? To { get; set; }
        [StringLength(200)]
        public string ContractNumber { get; set; }
        public DateTime ContractDate { get; set; }
        public PersonDb Person { get; set; }
    }
}
