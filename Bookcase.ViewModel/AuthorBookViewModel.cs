using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bookcase.ViewModel
{
    public class AuthorBookViewModel
    {
        [Required]
        [ForeignKey("Book")]
        public int BookId { get; set; }

        [Required]
        [ForeignKey("Author")]
        public int AuthorId { get; set; }

        public virtual AuthorViewModel Author { get; set; }
        public virtual BookViewModel Book { get; set; }
    }
}