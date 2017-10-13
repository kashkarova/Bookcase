using Microsoft.Build.Framework;

namespace Bookcase.ViewModel
{
    public class AuthorBookViewModel
    {
        [Required]
        public int AuthorId { get; set; }

        public virtual AuthorViewModel Author { get; set; }

        [Required]
        public int BookId { get; set; }

        public virtual BookViewModel Book { get; set; }
    }
}