using System.ComponentModel.DataAnnotations;

namespace Bookcase.DAL.DbEntities
{
    public abstract class BaseEntity
    {
        [Key]
        public int Id { get; set; }
    }
}