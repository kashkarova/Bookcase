using System;

namespace Bookcase.BLL.DTO
{
    public class Author
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string Country { get; set; }

        public string Photo { get; set; }
    }
}