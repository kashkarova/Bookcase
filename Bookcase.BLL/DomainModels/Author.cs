using System;
using System.Collections.Generic;

namespace Bookcase.BLL.DomainModels
{
    public class Author
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string Country { get; set; }

        public string Photo { get; set; }

        public virtual List<Book> Books { get; set; }
    }
}