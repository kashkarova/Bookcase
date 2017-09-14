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
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(BookcaseContext context)
        {
            context.Author.AddOrUpdate(
                a => a.Name,
                new AuthorEntity { Name = "А.С. Пушкин", DateOfBirth = DateTime.Parse("10.08.1886"), Country = "Россия", Photo = "pushkin.jpg" },
                new AuthorEntity
                {
                    Name = "Л.Н. Толстой",
                    DateOfBirth = DateTime.Parse("10.08.1886"),
                    Country = "Россия",
                    Photo = "tolstoy_lev.jpg"
                },
                new AuthorEntity
                {
                    Name = "М.Ю. Лермонтов",
                    DateOfBirth = DateTime.Parse("10.08.1886"),
                    Country = "Россия",
                    Photo = "lermontov.jpg"

                },
                new AuthorEntity { Name = "С.А. Есенин", DateOfBirth = DateTime.Parse("10.08.1886"), Country = "Россия", Photo = "yesenin.jpg" },
                new AuthorEntity { Name = "Э.А. Асадов", DateOfBirth = DateTime.Parse("10.08.1886"), Country = "Россия", Photo = "asadov.jpg" },
                new AuthorEntity
                {
                    Name = "В.В. Маяковский",
                    DateOfBirth = DateTime.Parse("10.08.1886"),
                    Country = "Россия",
                    Photo = "mayakovskyi.jpg"
                }
            );


            context.Book.AddOrUpdate(
                b => b.Title,
                new BookEntity
                {
                    Title = "Война и мир. Том 1.",
                    Year = DateTime.Now,
                    PublishingHouse = "Школьная литература"
                },
                new BookEntity
                {
                    Title = "Война и мир. Том 2.",
                    Year = DateTime.Now,
                    PublishingHouse = "Школьная литература"
                },
                new BookEntity
                {
                    Title = "Война и мир. Том 3.",
                    Year = DateTime.Now,
                    PublishingHouse = "Школьная литература"
                },
                new BookEntity
                {
                    Title = "Война и мир. Том 4.",
                    Year = DateTime.Now,
                    PublishingHouse = "Школьная литература"
                },
                new BookEntity { Title = "Анна Каренина", Year = DateTime.Now, PublishingHouse = "Школьная литература" },
                new BookEntity { Title = "Евгений Онегин", Year = DateTime.Now, PublishingHouse = "Школьная литература" }
            );

            context.SaveChanges();
        }
    }
}