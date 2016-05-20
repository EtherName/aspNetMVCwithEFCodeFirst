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
    public class BookVisit
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required(ErrorMessage = "Empty Date")]
        public DateTime Date { get; set; }
        [DefaultValue(0)]
        //public int Quantity { get; set; }
        //[Column("BookId")]
        public virtual Book ABook { get; set; }
    }
}
