using System;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace final
{
    class Program
    {
        public class ZiAuthor
        {
            [Key]
            public int Ziid { get; set; }
            public string ZiAuNam { get; set; }
            public string ZiAuAdd { get; set; }
        }
        public class ZiPub
        {
            [Key]
            public int Ziid { get; set; }
            public string ZiBookTitle { get; set; }
            public double ZiBPrice { get; set; }
            public ZiAuthor ZiAuthor { get; set; }
        }
        class EFContext : DbContext
        {
            public DbSet<ZiAuthor> ZiAuthors { get; set; }
            public DbSet<ZiPub> ZiPubs { get; set; }

        }

        public static void Main(string[] args)


        {
            addUser();

            Console.WriteLine("Press any key to close");
            Console.ReadKey();


            void addUser()
            {
                Console.WriteLine("adding data ");
                ZiAuthor ziAuthor = new ZiAuthor { ZiAuNam = "Sachin", ZiAuAdd = "31 Progress ave." };
                ZiAuthor ziAuthor1 = new ZiAuthor { ZiAuNam = "Saguo", ZiAuAdd = "3105 Progress ave." };
                ZiPub ziPub = new ZiPub { ZiBPrice = 30.5, ZiBookTitle = "Smallfoot", ZiAuthor = ziAuthor };
                ZiPub ziPub1 = new ZiPub { ZiBPrice = 130.5, ZiBookTitle = "Frozen", ZiAuthor = ziAuthor1 };

                try
                {
                    using (var ctx = new EFContext())
                    {
                        ctx.ZiAuthors.Add(ziAuthor);
                        ctx.ZiAuthors.Add(ziAuthor1);
                        ctx.ZiPubs.Add(ziPub);
                        ctx.ZiPubs.Add(ziPub1);
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
