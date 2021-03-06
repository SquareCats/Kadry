using System.ComponentModel.DataAnnotations;

namespace Kadry.Db
{
    public abstract class DictionaryDb : MyEntity
    {
        public int Sort { get; set; }
        [StringLength(255)]
        [Required]
        public string Name { get; set; }

        public string Description { get; set; }
    }
}
