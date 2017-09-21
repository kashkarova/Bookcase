using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

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
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Year { get; set; }

        public List<AuthorBookViewModel> Authors { get; set; }
    }
}