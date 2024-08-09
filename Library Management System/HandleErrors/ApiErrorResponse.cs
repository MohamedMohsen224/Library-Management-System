namespace Library_Management_System.HandleErrors
{
    public class ApiErrorResponse
    {
        public string? Message { get; set; }
        public int StatusCode { get; set; }

        public ApiErrorResponse(string message, int statusCode)
        {
            Message = message;
            StatusCode = statusCode;
        }

    }
}
