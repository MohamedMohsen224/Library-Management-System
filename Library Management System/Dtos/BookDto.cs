namespace Library_Management_System.Dtos
{
    public class BookDto
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string ISBN { get; set; }
        public int Year { get; set; }
        public string Publisher { get; set; }
        public string Language { get; set; }
        public bool IsAvailable { get; set; }

    }
}
