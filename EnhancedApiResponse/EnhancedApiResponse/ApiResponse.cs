namespace EnhancedApiResponse
{
    public class ApiResponse<T>
    {
        public string Status { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }
        public object Metadata { get; set; }

        public static ApiResponse<T> Success(T data, string message = "Operation completed successfully.", object metadata = null)
        {
            return new ApiResponse<T>
            {
                Status = "Success",
                Message = message,
                Data = data,
                Metadata = metadata
            };
        }

        public static ApiResponse<string> Error(string message, string details = null)
        {
            return new ApiResponse<string>
            {
                Status = "Error",
                Message = message,
                Data = details
            };
        }
    }
}
