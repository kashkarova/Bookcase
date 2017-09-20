using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Build.Framework;

namespace Bookcase.ViewModel
{
    public class AuthorBookViewModel
    {
        
        public AuthorViewModel Author { get; set; }
        [Required]
        public int AuthorId { get; set; }

        [Required]
        public int BookId { get; set; }
    }
}
