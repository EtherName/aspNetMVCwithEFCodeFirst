//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Data.Entity.ModelConfiguration;
//using DataService.Entities;

//namespace DataService.EntitiesConfig
//{
//    internal class AuthorConfig : EntityTypeConfiguration<Author>
//    {
//        public AuthorConfig()
//        {
//            HasKey(i => i.Id);
//            HasKey(i => i.FirstName);
//            HasKey(i => i.LastName);
//            Property(i => i.FirstName)
//                .IsRequired()
//                .HasMaxLength(20)
//                .IsUnicode();
//            Property(i => i.LastName)
//                .IsRequired()
//                .HasMaxLength(20)
//                .IsUnicode();
//        }
//    }
//}
