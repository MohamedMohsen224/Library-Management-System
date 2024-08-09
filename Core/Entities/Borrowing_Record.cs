using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Borrowing_Record : Base
    {
        public int BookId { get; set; }
        public Book Book { get; set; }
        public int PatronId { get; set; }
        public Patron Patron { get; set; }
        public DateTime BorrowDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public bool IsReturned { get; set; }

    }
}
