namespace UrlShortener.DTOs
{
    public class Response<T>
    {
        public bool HasError { get; set; }
        public string? ErrorMessage { get; set; }

        public Response(bool hasError)
        {
            HasError = hasError;
        }
        public Response(bool hasError, string errorMessage)
        {
            HasError = hasError;
            ErrorMessage = errorMessage;
        }
        public Response(bool hasError, dynamic? result)
        {
            HasError = hasError;
            Result = result;
        }
        public T? Result { get; set; }
    }
}
