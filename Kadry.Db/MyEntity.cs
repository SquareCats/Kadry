using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kadry.Db
{
    public abstract class MyEntity : IMyEntity
    {
        public MyEntity()
        {
            ObjectGuid = Guid.NewGuid();
        }
        public int Id { get; set; }
        public AppUser CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public AppUser? ChengedBy { get; set; }
        public DateTime? ChangedOn { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        
        public Guid ObjectGuid { get; set; }

    }

    public interface IMyEntity
    {
        int Id { get; set; }
        AppUser CreatedBy { get; set; }
        DateTime CreatedOn { get; set; }
        AppUser? ChengedBy { get; set; }
        DateTime? ChangedOn { get; set; }
        public Guid ObjectGuid { get; set; }
    }
}
