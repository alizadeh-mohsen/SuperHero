using SuperHero.MVC.Models;
using System.Net;
using System.Text;
using System.Text.Json;

namespace SuperHero.MVC.Services
{
    public class BaseService(IHttpClientFactory _httpClientFactory) : IBaseService
    {
        public async Task<ResponseDto> SendAsync(RequestDto requestDto)
        {
            try
            {
                var httpClient = _httpClientFactory.CreateClient();
                HttpResponseMessage response = null;

                HttpRequestMessage request = new HttpRequestMessage();
                request.Headers.Add("Accept", "application/json");
                request.RequestUri = new Uri(requestDto.Url);
                if (requestDto.Data != null)
                {
                    request.Content = new StringContent(JsonSerializer.Serialize(requestDto.Data),
                        Encoding.UTF8, "application/json"
                    );
                }

                request.Method = requestDto.ApiType switch
                {
                    ApiTypeEnum.GET => HttpMethod.Get,
                    ApiTypeEnum.POST => HttpMethod.Post,
                    ApiTypeEnum.PUT => HttpMethod.Put,
                    ApiTypeEnum.DELETE => HttpMethod.Delete,
                    ApiTypeEnum.PATCH => new HttpMethod("PATCH"),
                    _ => throw new NotImplementedException()
                };


                response = await httpClient.SendAsync(request);
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var responseDto = JsonSerializer.Deserialize<ResponseDto>(content, new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });
                    return responseDto;
                }

                return new ResponseDto
                {
                    IsSuccess = false,
                    Message = response.ReasonPhrase,
                    StatusCode = response.StatusCode
                };

            }
            catch (Exception ex)
            {
                return new ResponseDto
                {
                    IsSuccess = false,
                    Message = ex.Message,
                    StatusCode = HttpStatusCode.InternalServerError
                };
            }
        }
    }
}
