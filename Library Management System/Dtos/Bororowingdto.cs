using Core.Entities;

namespace Library_Management_System.Dtos
{
    public class Bororowingdto
    {
        public int BookId { get; set; }
        public int PatronId { get; set; }
        public DateTime BorrowDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public bool IsReturned { get; set; }
    }
}
