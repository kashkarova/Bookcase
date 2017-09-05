using System;
using System.ComponentModel;
using Microsoft.Build.Framework;

namespace Bookcase.ViewModel
{
    public class AuthorViewModel
    {
        [Required]
        [DisplayName("Name")]
        public string Name { get; set; }

        [Required]
        [DisplayName("Date of birth")]
        public DateTime DateOfBirth { get; set; }
    }
}