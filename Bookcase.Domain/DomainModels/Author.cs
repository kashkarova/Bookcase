using System;
using System.Collections.Generic;

namespace Bookcase.Domain.DomainModels
{
    public class Author : DomainBase
    {
        public string Name { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string Country { get; set; }

        public string Photo { get; set; }

        public List<AuthorBook> Books { get; set; }
    }
}