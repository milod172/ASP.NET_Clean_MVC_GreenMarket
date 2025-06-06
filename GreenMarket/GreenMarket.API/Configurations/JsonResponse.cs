namespace GreenMarket.API.Configurations
{
    public class JsonResponse<T>
    {
        public int Status { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }
        public object Errors { get; set; }
        public DateTime Timestamp { get; set; }

        public JsonResponse(T data, int status = 200, string message = "Success", object errors = null)
        {
            Status = status;
            Message = message;
            Data = data;
            Errors = errors;
            Timestamp = DateTime.UtcNow;
        }
    }
}
