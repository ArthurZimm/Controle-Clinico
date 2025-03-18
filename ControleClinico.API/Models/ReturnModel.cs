namespace ControleClinico.API.Models
{
    public class ReturnModel
    {
        public ReturnModel(int statusCode, string message, object? data)
        {
            StatusCode = statusCode;
            Message = message;
            Data = data;
        }

        public int StatusCode { get; set; }
        public string Message { get; set; }
        public object? Data { get; set; }
    }
}