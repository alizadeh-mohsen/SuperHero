namespace SuperHero.API.Data.Dto
{
    public class RequestDto
    {
        public ApiTypeEnum ApiType { get; set; } = ApiTypeEnum.GET;
        public string? Url { get; set; }
        public object? Data { get; set; }
    }
    public enum ApiTypeEnum
    {
        GET,
        POST,
        PUT,
        DELETE,
        PATCH
    }
}
