namespace CodeVidyalaya.Clean.WebApp.Services.Base
{
    public class SuccessResponse<T>
    {
        public string Message { get; set; }
        public IDictionary<string, string[]> ValidationErrors { get; set; }
        public bool Success { get; set; }
        public T Data { get; set; }
    }

    public class FailureResponse
    {
        public string Type { get; set; }
        public string Title { get; set; }
        public int Status { get; set; }
        public string TraceId { get; set; }
        public Dictionary<string, string[]> Errors { get; set; }
    }

    public class BaseHttpService
    {
        protected SuccessResponse<Guid> ConvertApiExceptions<Guid>(CustomApiException ex)
        {
            if (ex.StatusCode == 400)
            {
                return new SuccessResponse<Guid>() { Message = "Validation errors have occured.", ValidationErrors = null, Success = false };
            }
            else if (ex.StatusCode == 404)
            {
                return new SuccessResponse<Guid>() { Message = "The requested item could not be found.", Success = false };
            }
            else
            {
                return new SuccessResponse<Guid>() { Message = "Something went wrong, please try again.", Success = false };
            }
        }
    }

    public class CustomApiException : Exception
    {
        public int StatusCode { get; } // Property to hold HTTP status code
        public string Messsage { get; }

        public CustomApiException() : base() { }

        public CustomApiException(string message, int statusCode) : base(message)
        {
            StatusCode = statusCode;
            Messsage = message;
        }

        public CustomApiException(string message, int statusCode, Exception innerException) : base(message, innerException)
        {
            StatusCode = statusCode;
            Messsage = message;
        }
    }
}
