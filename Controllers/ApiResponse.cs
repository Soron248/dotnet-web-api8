namespace testapiproject.Controllers
{
    public class ApiResponse<T>
    {
        public bool Success { get; set; }

        public string Message { get; set; } = string.Empty;

        public int Status { get; set; }

        public T? Data { get; set; }

        public List<string>? Errors { get; set; }

        public DateTime TimeStamp { get; set; }

        //Constructor for successfull responce
        private ApiResponse(bool success, string message, T? data, List<string> errors, int statusCode)
        {
            Success = success;
            Message = message;
            Status = statusCode;
            Data = data;
            Errors = errors;
            TimeStamp = DateTime.Now;
        }

        //Static method for successfull responce
        public static ApiResponse<T> SuccessResponse(T data, int statusCode, string message = "")
        {
            return new ApiResponse<T>(true, message, data, null, statusCode);
        }

        //Constructor for error responce
        public static ApiResponse<T> ErrorResponse(T data, int statusCode, string message = "")
        {
            return new ApiResponse<T>(true, message, data, null, statusCode);
        }
    }

}
