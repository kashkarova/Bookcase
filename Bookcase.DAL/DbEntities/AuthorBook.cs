using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bookcase.DAL.DbEntities
{
    public class AuthorBook : EntityBase
    {
        
        [Required]
        [ForeignKey("Author")]
        public int AuthorId { get; set; }

        
        public virtual Author Author { get; set; }
       
        [Required]
        [ForeignKey("Book")]
        public int BookId { get; set; }

        
        public virtual Book Book { get; set; }
    }
}