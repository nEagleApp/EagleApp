namespace Eagle.Core.Exceptions
{
    public class ApiException : Exception
    {
        public ApiException()
        {
            StatusCode = 400;
        }

        public ApiException(int statusCode)
        {
            StatusCode = statusCode;
        }

        public int StatusCode { get; set; }
    }
}
