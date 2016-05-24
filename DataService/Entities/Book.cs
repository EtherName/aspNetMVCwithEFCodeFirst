using Google.DataTable.Net.Wrapper;
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

        public string GoogleChartData
        {
            get
            {

                //let's instantiate the DataTable.
                var dt = new DataTable();
                dt.AddColumn(new Column(ColumnType.Date, "Day", "Day"));
                dt.AddColumn(new Column(ColumnType.Number, "Count", "Count"));

                foreach (var visit in BookVisits)
                {
                    Row r = dt.NewRow();
                    r.AddCellRange(new Cell[]
                    {
                        new Cell(visit.Date),
                        new Cell(visit.Quantity)
                    });
                    dt.AddRow(r);
                }

                //Let's create a Json string as expected by the Google Charts API.
                return dt.GetJson();
            }
        }
    }
}
