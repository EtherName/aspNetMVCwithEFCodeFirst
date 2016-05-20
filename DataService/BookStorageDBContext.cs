using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using DataService.Entities;
//using DataService.EntitiesConfig;

namespace DataService
{
    internal class BookStorageDBContext : DbContext
    {
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<BookVisit> BookVisits { get; set; }

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);
        //    modelBuilder.Configurations.Add(new AuthorConfig());
        //    modelBuilder.Configurations.Add(new BookConfig());
        //    modelBuilder.Configurations.Add(new BookVisitConfig());
        //}
    }
}
