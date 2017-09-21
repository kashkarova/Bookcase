using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bookcase.DAL.DbEntities
{
    public class AuthorBookEntity : EntityBase
    {
        [ForeignKey("Author")]
        [Required]
        public int AuthorId { get; set; }

        public virtual AuthorEntity Author { get; set; }

        [ForeignKey("Book")]
        [Required]
        public int BookId { get; set; }

        public virtual BookEntity Book { get; set; }
    }
}