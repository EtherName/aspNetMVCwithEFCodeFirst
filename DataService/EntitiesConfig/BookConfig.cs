//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Data.Entity.ModelConfiguration;
//using DataService.Entities;

//namespace DataService.EntitiesConfig
//{
//    internal class BookConfig : EntityTypeConfiguration<Book>
//    {
//        public BookConfig()
//        {
//            HasKey(i => i.Id);
//            HasKey(i => i.ISBN);
//            Property(i => i.Title)
//                .IsRequired()
//                .HasMaxLength(100)
//                .IsUnicode();
//            Property(i => i.ISBN)
//                .IsRequired()
//                .HasMaxLength(100)
//                .IsUnicode();
//        }
//    }
//}
