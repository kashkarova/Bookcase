using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Bookcase.ViewModel
{
    public class AuthorViewModel
    {
        public int Id { get; set; }

        [Required]
        [DisplayName("Name")]
        public string Name { get; set; }

        [Required]
        [DisplayName("Date of birth")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DateOfBirth { get; set; }

        [Required]
        [DisplayName("Country")]
        public string Country { get; set; }

        [DisplayName("Photo")]
        public string Photo { get; set; }

        public virtual List<AuthorInBookViewModel> Books { get; set; }
    }
}