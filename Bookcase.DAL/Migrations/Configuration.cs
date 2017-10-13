using System;
using System.Data.Entity.Migrations;
using Bookcase.DAL.DbContext;
using Bookcase.DAL.DbEntities;

namespace Bookcase.DAL.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<BookcaseContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(BookcaseContext context)
        {
            context.Author.AddOrUpdate(
                a => a.Name,
                new Author
                {
                    Name = "А.С. Пушкин",
                    DateOfBirth = DateTime.Parse("29.01.1837"),
                    Country = "Россия",
                    Photo = "pushkin.jpg"
                },
                new Author
                {
                    Name = "Л.Н. Толстой",
                    DateOfBirth = DateTime.Parse("28.08.1828"),
                    Country = "Россия",
                    Photo = "tolstoy_lev.jpg"
                },
                new Author
                {
                    Name = "М.Ю. Лермонтов",
                    DateOfBirth = DateTime.Parse("15.07.1841"),
                    Country = "Россия",
                    Photo = "lermontov.jpg"
                },
                new Author
                {
                    Name = "С.А. Есенин",
                    DateOfBirth = DateTime.Parse("21.09.1895"),
                    Country = "Россия",
                    Photo = "yesenin.jpg"
                },
                new Author
                {
                    Name = "Э.А. Асадов",
                    DateOfBirth = DateTime.Parse("07.09.1923"),
                    Country = "Россия",
                    Photo = "asadov.jpg"
                },
                new Author
                {
                    Name = "В.В. Маяковский",
                    DateOfBirth = DateTime.Parse("07.07.1893"),
                    Country = "Россия",
                    Photo = "mayakovskyi.jpg"
                }
            );


            context.Book.AddOrUpdate(
                b => b.Title,
                new Book
                {
                    Title = "Война и мир. Том 1.",
                    Year = DateTime.Parse("10.08.1886"),
                    PublishingHouse = "Школьная литература"
                },
                new Book
                {
                    Title = "Война и мир. Том 2.",
                    Year = DateTime.Parse("10.08.1886"),
                    PublishingHouse = "Школьная литература"
                },
                new Book
                {
                    Title = "Война и мир. Том 3.",
                    Year = DateTime.Parse("10.08.1886"),
                    PublishingHouse = "Школьная литература"
                },
                new Book
                {
                    Title = "Война и мир. Том 4.",
                    Year = DateTime.Parse("10.08.1886"),
                    PublishingHouse = "Школьная литература"
                },
                new Book {Title = "Анна Каренина", Year = DateTime.Now, PublishingHouse = "Школьная литература"},
                new Book {Title = "Евгений Онегин", Year = DateTime.Now, PublishingHouse = "Школьная литература"}
            );

            context.SaveChanges();
        }
    }
}