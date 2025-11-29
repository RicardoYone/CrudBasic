namespace Back.Api.Middleware
{
    public class BaseResponseModel<T>
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public T? Data { get; set; }
        public BaseResponseModel()
        {
            StatusCode = 200;
            Message = "";
        }
    }
}
