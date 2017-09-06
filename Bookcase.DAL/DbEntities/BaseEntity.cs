using System.ComponentModel.DataAnnotations;

namespace Bookcase.DAL.DbEntities
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }
    }
}