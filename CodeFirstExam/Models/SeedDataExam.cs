using Microsoft.EntityFrameworkCore;

namespace CodeFirstExam.Models
{
    public class SeedDataExam
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (GuestBookExamContext context = new GuestBookExamContext(serviceProvider.GetRequiredService<DbContextOptions<GuestBookExamContext>>()))
            {
                if (!context.Books.Any())
                {
                    string[] guid = { Guid.NewGuid().ToString(),
                Guid.NewGuid().ToString(), Guid.NewGuid().ToString(),
                Guid.NewGuid().ToString(), Guid.NewGuid().ToString() };

                    context.Books.AddRange(
                        new BookExam
                        {
                            BookID = guid[0],
                            Title = "C# 程式設計",
                            Description = "這是一本關於C#程式設計的書籍",
                            Author = "作者一號",
                            Photo = guid[0] + ".jpg",
                            CreatedDate = DateTime.Now,
                        },
                        new BookExam
                        {
                            BookID = guid[1],
                            Title = "烹飪課",
                            Description = "這是一本關於烹飪的書籍",
                            Author = "作者五號",
                            Photo = guid[1] + ".jpg",
                            CreatedDate = DateTime.Now,
                        },
                        new BookExam
                        {
                            BookID = guid[2],
                            Title = "估尼",
                            Description = "?????",
                            Author = "作者八號",
                            Photo = guid[2] + ".jpg",
                            CreatedDate = DateTime.Now,
                        },
                        new BookExam
                        {
                            BookID = guid[3],
                            Title = "鬼之副長",
                            Description = "超帥",
                            Author = "作者二號",
                            Photo = guid[3] + ".jpg",
                            CreatedDate = DateTime.Now,
                        },
                        new BookExam
                        {
                            BookID = guid[4],
                            Title = "叭哩補補",
                            Description = "補補里",
                            Author = "作者七號",
                            Photo = guid[4] + ".jpg",
                            CreatedDate = DateTime.Now,
                        }
                    );
                    context.SaveChanges();

                    context.ReBooks.AddRange(
                        new ReBookExam
                        {
                            ReBookID = Guid.NewGuid().ToString(),
                            Description = "111111",
                            Author = "作者一號",
                            CreatedDate = DateTime.Now,
                            BookID = guid[0]
                        },
                        new ReBookExam
                        {
                            ReBookID = Guid.NewGuid().ToString(),
                            Description = "222222",
                            Author = "作者二號",
                            CreatedDate = DateTime.Now,
                            BookID = guid[0]
                        },
                        new ReBookExam
                        {
                            ReBookID = Guid.NewGuid().ToString(),
                            Description = "333333",
                            Author = "作者三號",
                            CreatedDate = DateTime.Now,
                            BookID = guid[2]
                        },
                        new ReBookExam
                        {
                            ReBookID = Guid.NewGuid().ToString(),
                            Description = "444444",
                            Author = "作者四號",
                            CreatedDate = DateTime.Now,
                            BookID = guid[4]
                        },
                        new ReBookExam
                        {
                            ReBookID = Guid.NewGuid().ToString(),
                            Description = "555555",
                            Author = "作者五號",
                            CreatedDate = DateTime.Now,
                            BookID = guid[4]
                        }
                    );
                    context.SaveChanges();

                    string SeedDogPath = Path.Combine(Directory.GetCurrentDirectory(), "SeedDog");
                    string BookExamPhotosPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "BookExamPhotos");

                    string[] files = Directory.GetFiles(SeedDogPath);
                    for (int i = 0; i < files.Length; i++)
                    {
                        string destFile = Path.Combine(BookExamPhotosPath, guid[i] + ".jpg");
                        File.Copy(files[i], destFile);
                    }
                }
            }
        }
    }
}
