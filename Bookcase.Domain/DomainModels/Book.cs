using System;
using System.Collections.Generic;

namespace Bookcase.Domain.DomainModels
{
    public class Book : DomainBase
    {
        public string Title { get; set; }

        public string PublishingHouse { get; set; }

        public DateTime Year { get; set; }

        public List<AuthorBook> Authors { get; set; }
    }
}