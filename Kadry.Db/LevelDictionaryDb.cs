using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kadry.Db
{
    [Table("LevelDictionary", Schema ="dbo")]
    public class LevelDictionaryDb : MyEntity
    {
        [StringLength(100)]
        [Required]
        public string Name { get; set; }
    }
}
