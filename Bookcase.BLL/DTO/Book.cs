using System;

namespace Bookcase.BLL.DTO
{
    public class Book
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string PublishingHouse { get; set; }

        public DateTime Year { get; set; }
    }
}