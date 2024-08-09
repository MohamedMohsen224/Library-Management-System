namespace Library_Management_System.HandleErrors
{
    public class ErrorCases : ApiErrorResponse
    {
        public ErrorCases(string message, int statusCode) : base(message, statusCode)
        {

        }

        private string? GetDefaultMessage(int? statusCode)
        {
            return StatusCode switch
            {
                500 => "Internal Server Error",
                400 => "Bad Request",
                401 => "UNAuthoritzed",
                404 => "Not Found",
                403 => "Forbidden",
                _ => null
            };

        }
    }
}
