namespace HireHubApplication.DTOs
{
    public class Response
    {
        public bool IsError { get; set; } = false;
        public string Message { get; set; } = string.Empty;
        public object? Data { get; set; }
    }
}
