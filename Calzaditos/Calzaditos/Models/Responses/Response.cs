namespace Calzaditos.Models.Responses
{
    public class Response<T> where T : class
    {
        public bool IsSuccess { get; set; }
        public string? Error { get; set; }
        public string? Message { get; set; }
        public T? Data { get; set; }

        public Response(T? data)
        {
            Data = data;
        }
    }
}
