using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Book : Base
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string ISBN { get; set; }
        public int Year { get; set; }
        public string Publisher { get; set; }
        public string Language { get; set; }
        public bool IsAvailable { get; set; }

        public ICollection<Borrowing_Record> borrowing_Records { get; set; }

    }
}
