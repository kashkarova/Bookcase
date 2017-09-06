using System;
using System.ComponentModel;
using Microsoft.Build.Framework;

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
        public DateTime DateOfBirth { get; set; }

        [Required]
        [DisplayName("Country")]
        public string Country { get; set; }

        [DisplayName("Photo")]
        public string Photo { get; set; }
    }
}