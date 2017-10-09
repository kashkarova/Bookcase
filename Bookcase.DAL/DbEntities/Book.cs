using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Bookcase.DAL.DbEntities
{
    public class Book : EntityBase
    {
        [MinLength(1)]
        [MaxLength(50)]
        [Required]
        public string Title { get; set; }

        [MinLength(1)]
        [MaxLength(50)]
        [Required]
        public string PublishingHouse { get; set; }

        [Required]
        public DateTime Year { get; set; }

        public virtual ICollection<AuthorBook> Authors { get; set; }
    }
}