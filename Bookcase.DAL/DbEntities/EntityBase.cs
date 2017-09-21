using System.ComponentModel.DataAnnotations;

namespace Bookcase.DAL.DbEntities
{
    public class EntityBase
    {
        [Key]
        public int Id { get; set; }
    }
}