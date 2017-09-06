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
                new AuthorEntity {Name = "А.С. Пушкин", DateOfBirth = DateTime.Parse("10.08.1886"), Country = "Россия"},
                new AuthorEntity
                {
                    Name = "Л.Н. Толстой",
                    DateOfBirth = DateTime.Parse("10.08.1886"),
                    Country = "Россия"
                },
                new AuthorEntity
                {
                    Name = "М.Ю. Лермонтов",
                    DateOfBirth = DateTime.Parse("10.08.1886"),
                    Country = "Россия"
                },
                new AuthorEntity {Name = "С.А. Есенин", DateOfBirth = DateTime.Parse("10.08.1886"), Country = "Россия"},
                new AuthorEntity {Name = "Э.А. Асадов", DateOfBirth = DateTime.Parse("10.08.1886"), Country = "Россия"},
                new AuthorEntity
                {
                    Name = "В.В. Маяковский",
                    DateOfBirth = DateTime.Parse("10.08.1886"),
                    Country = "Россия"
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
                new BookEntity {Title = "Анна Каренина", Year = DateTime.Now, PublishingHouse = "Школьная литература"},
                new BookEntity {Title = "Евгений Онегин", Year = DateTime.Now, PublishingHouse = "Школьная литература"}
            );

            //context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );


            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}