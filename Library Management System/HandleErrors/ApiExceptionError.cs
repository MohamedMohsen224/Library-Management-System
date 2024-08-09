namespace Library_Management_System.HandleErrors
{
    public class ApiExceptionError : ApiErrorResponse
    {
        public string? Detail { get; set; }
        public ApiExceptionError(string message, string detail, int statusCode) : base(message,statusCode)
        {
            Detail = detail;
        }
    }
    
}
