using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bookcase.DAL.DbEntities
{
    public class AuthorBook : EntityBase
    {
        [ForeignKey("Author")]
        [Required]
        public int AuthorId { get; set; }

        public virtual Author Author { get; set; }

        [ForeignKey("Book")]
        [Required]
        public int BookId { get; set; }

        public virtual Book Book { get; set; }
    }
}