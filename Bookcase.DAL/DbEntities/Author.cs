using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Bookcase.DAL.DbEntities
{
    public class Author : EntityBase
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }

        [Required]
        [MaxLength(20)]
        public string Country { get; set; }

        public string Photo { get; set; }

        public virtual ICollection<AuthorInBook> Books { get; set; }
    }
}