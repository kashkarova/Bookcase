using System;
using System.Collections.Generic;

namespace Bookcase.BLL.DomainModels
{
    public class Book
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string PublishingHouse { get; set; }

        public DateTime Year { get; set; }

        public virtual List<Author> Authors { get; set; }
    }
}