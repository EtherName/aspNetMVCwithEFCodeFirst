using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataService.Entities
{
    public class Author
    {
        public Author()
        {
            Books = new HashSet<Book>();
        }
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required(ErrorMessage = "Empty first name")]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "Invalid first name length")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Empty last name")]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "Invalid last name length")]
        public string LastName { get; set; }
        [DefaultValue(0)]
        public int? BookAmount { get; set; }

        public virtual IEnumerable<Book> Books { get; set;}
    }
}
