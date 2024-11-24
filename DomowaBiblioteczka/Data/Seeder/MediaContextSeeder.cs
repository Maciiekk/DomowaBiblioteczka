using DomowaBiblioteczka.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace DomowaBiblioteczka.Data.Seeder
{
    public static class MediaContextSeeder
    {
        public static async Task Seed(MediaDbContext context, bool mockData)
        {
            if(context == null) 
                throw new ArgumentNullException("missing_context");

            // Seed Units
            if (!context.Units.Any())
            {
                context.Units.AddRange(
                    new Unit { Name = "pages", Symbole = "pages" },
                    new Unit { Name = "minutes", Symbole = "min" },
                    new Unit { Name = "seconds", Symbole = "s" }

                );
                await context.SaveChangesAsync();
            }

            if (!await context.MediaTypes.AnyAsync())
            {
                IEnumerable<Unit> units = context.Units;

               await context.MediaTypes.AddRangeAsync(
               new MediaType { Name = "book", UnitId = units.First(u=>u.Id == 1).Id},
               new MediaType { Name = "movie", UnitId = units.First(u => u.Id == 2).Id },
               new MediaType { Name = "music album", UnitId = units.First(u => u.Id == 2).Id },
               new MediaType { Name = "comics", UnitId = units.First(u => u.Id == 1).Id },
               new MediaType { Name = "magazine", UnitId = units.First(u => u.Id == 1).Id }
                );
                context.SaveChanges();

            }

            if(! await context.IndustryTypes.AnyAsync())
            {
                await context.IndustryTypes.AddRangeAsync(
                new IndustryType { Name = "publishing house" },
                new IndustryType { Name = "film company" },
                new IndustryType { Name = "music label" },
                new IndustryType { Name = "publisher" },
                new IndustryType { Name = "press company " }
                );
                context.SaveChanges();
            }

            if (mockData)
                await MockData(context);


        }
        private static async Task MockData(MediaDbContext context)
        {
            // Seed Industries
            if (!context.Industries.Any())
            {
                var industryType = context.IndustryTypes.FirstOrDefault();
                if (industryType != null)
                {
                    context.Industries.AddRange(
                        new Industry { Name = "Publishing", IndustryTypeId = industryType.Id, Description = "Books and magazines" },
                        new Industry { Name = "Film Production", IndustryTypeId = industryType.Id, Description = "Movies and series" }
                    );
                    await context.SaveChangesAsync();
                }
                else
                {
                    Console.WriteLine("MockDataError: Industries is empty.");
                }
            }

            // Seed Authors
            if (!context.Authors.Any())
            {
                context.Authors.AddRange(
                    new Author { Name = "John Doe", Description = "Author of various books" },
                    new Author { Name = "Jane Smith", Description = "Famous director" }
                );
                await context.SaveChangesAsync();
            }

            // Seed Media
            if (!context.Medias.Any())
            {
                var mediaType = context.MediaTypes.FirstOrDefault();
                var author = context.Authors.FirstOrDefault();
                var industry = context.Industries.FirstOrDefault();

                if (mediaType != null && author != null && industry != null)
                {
                    context.Medias.AddRange(
                        new Media
                        {
                            Title = "Introduction to Programming",
                            Description = "A comprehensive guide to programming",
                            CreatedDate = DateTime.UtcNow,
                            ReleseDate = DateTime.UtcNow.AddYears(-2),
                            MediaTypeID = mediaType.Id,
                            Authors = new List<Author> { author },
                            Length = 350,
                            IndustryID = industry.Id,
                            Image = File.ReadAllBytes(Path.Combine(Directory.GetCurrentDirectory(), @"Data\Seeder\zzimg1.png"))
                        },
                        new Media
                        {
                            Title = "The Great Adventure",
                            Description = "An epic adventure story",
                            CreatedDate = DateTime.UtcNow,
                            ReleseDate = DateTime.UtcNow.AddYears(-1),
                            MediaTypeID = mediaType.Id,
                            Authors = new List<Author> { author },
                            Length = 320,
                            IndustryID = industry.Id,
                            Image = File.ReadAllBytes(Path.Combine(Directory.GetCurrentDirectory(), @"Data\Seeder\zzimg2.png"))


                        }
                        );
                await context.SaveChangesAsync();
                }
                else
                {
                    Console.WriteLine("MockDataError: mediaType or Authors can be empty.");
                }
            }

            // Seed MediaSections
            if (!context.MediaSections.Any())
            {
                var media = context.Medias.FirstOrDefault();

                if( media != null )
                {
                    context.MediaSections.AddRange(
                        new MediaSection { MediaId = media.Id, Position = 1, Name = "Chapter 1" },
                        new MediaSection { MediaId = media.Id, Position = 2, Name = "Chapter 2" }
                    );
                    await context.SaveChangesAsync();
                }
                else
                {
                    Console.WriteLine("MockDataError: Media can be empty.");
                }
            }

            // Seed KeyWords
            if (!context.KeyWords.Any())
            {
                context.KeyWords.AddRange(
                    new KeyWord { Word = "Programming" },
                    new KeyWord { Word = "Adventure" }
                );
                await context.SaveChangesAsync();
            }

            var mediaForKeyword = context.Medias.Include(k=> k.Keywords).FirstOrDefault();
            var keyword = context.KeyWords.FirstOrDefault();

            if ((mediaForKeyword != null && mediaForKeyword == null )&& keyword != null)
            {
                mediaForKeyword.Keywords = new List<KeyWord> { keyword };
            }
            else
            {
                Console.WriteLine("MockDataError: keyword or media can be empty.");
            }

            await context.SaveChangesAsync();



        }
    }
}
