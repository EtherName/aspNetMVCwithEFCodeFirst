//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Data.Entity.ModelConfiguration;
//using DataService.Entities;

//namespace DataService.EntitiesConfig
//{
//    internal class BookVisitConfig : EntityTypeConfiguration<BookVisit>
//    {
//        public BookVisitConfig()
//        {
//            HasKey(i => i.Id);
//            Property(i => i.Quantity)
//                .IsRequired();
//            Property(i => i.Date)
//                .IsRequired();
//        }
//    }
//}
