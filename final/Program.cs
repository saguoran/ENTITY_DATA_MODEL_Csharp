using System;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace final
{
    class Program
    {
        public class Author
        {
            [Key]
            public int id { get; set; }
            public string AuNam { get; set; }
            public string AuAdd { get; set; }
        }
        public class Pub
        {
            [Key]
            public int id { get; set; }
            public string BookTitle { get; set; }
            public double BPrice { get; set; }
            public Author Author { get; set; }
        }
        class EFContext : DbContext
        {
            public DbSet<Author> Authors { get; set; }
            public DbSet<Pub> Pubs { get; set; }

        }

        public static void Main(string[] args)


        {
            addUser();

            Console.WriteLine("Press any key to close");
            Console.ReadKey();


            void addUser()
            {
                Console.WriteLine("adding data ");
                Author Author = new Author { AuNam = "Sachin", AuAdd = "31 Progress ave." };
                Author Author1 = new Author { AuNam = "Saguo", AuAdd = "3105 Progress ave." };
                Pub Pub = new Pub { BPrice = 30.5, BookTitle = "Smallfoot", Author = Author };
                Pub Pub1 = new Pub { BPrice = 130.5, BookTitle = "Frozen", Author = Author1 };

                try
                {
                    using (var ctx = new EFContext())
                    {
                        ctx.Authors.Add(Author);
                        ctx.Authors.Add(Author1);
                        ctx.Pubs.Add(Pub);
                        ctx.Pubs.Add(Pub1);
                        ctx.SaveChanges();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
