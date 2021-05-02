using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kadry.Db
{
    [Table("LogActivitiesDictionary", Schema = "dbo")]
    public class LogActivitiesDb : Dictionary
    {

        [StringLength(100)]
        [Required]
        public EnumLogLevel Level { get; set; }
    }
}
