using System;
using System.ComponentModel;
using Microsoft.Build.Framework;

namespace Bookcase.ViewModel
{
    public class BookViewModel
    {
        public int Id { get; set; }

        [Required]
        [DisplayName("Title of book")]
        public string Title { get; set; }

        [Required]
        [DisplayName("Publishing house")]
        public string PublishingHouse { get; set; }

        [Required]
        [DisplayName("Year of publishing")]
        public DateTime Year { get; set; }
    }
}