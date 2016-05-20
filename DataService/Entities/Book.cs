using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataService.Entities
{
    public class Book
    {
        public Book()
        {
            BookVisits = new HashSet<BookVisit>();
        }
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required(ErrorMessage = "Empty title")]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "Invalid title length")]
        public string Title { get; set; }
        [RegularExpression(@"ISBN\x20(?=.{13}$)\d{1,5}([- ])\d{1,7}\1\d{1,6}\1(\d|X)$", ErrorMessage = "Invalid ISBN")]
        public string ISBN { get; set; }
        public short Years { get; set; }
        [Column("AuthorId")]
        public virtual Author AAuthor { get; set; }
        public virtual IEnumerable<BookVisit> BookVisits { get; set; }
    }
}
