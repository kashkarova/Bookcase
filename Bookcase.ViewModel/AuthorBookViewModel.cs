using Microsoft.Build.Framework;

namespace Bookcase.ViewModel
{
    public class AuthorBookViewModel
    {
        [Required]
        public int AuthorId { get; set; }
        public AuthorViewModel Author { get; set; }

        [Required]
        public int BookId { get; set; }
        public BookViewModel Book { get; set; }
    }
}