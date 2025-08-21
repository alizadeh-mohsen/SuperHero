using Serilog;
using SuperHero.MVC.Models;
using System.Net;
using System.Text;
using System.Text.Json;

namespace SuperHero.MVC.Services
{
    public class BaseService : IBaseService
    {
        private readonly HttpClient _httpClient;

        public BaseService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<ResponseDto> SendAsync(RequestDto requestDto)
        {
            try
            {
                Log.Warning(">>>>>>>>>> MVC: inside Base service");

                //var httpClient = _httpClientFactory.CreateClient();
                HttpResponseMessage response = null;

                HttpRequestMessage request = new HttpRequestMessage();
                request.Headers.Add("Accept", "application/json");

                request.RequestUri = !string.IsNullOrEmpty(requestDto.Url)
                    ? new Uri(_httpClient.BaseAddress + requestDto.Url)
                    : new Uri(_httpClient.BaseAddress, requestDto.Url);

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

                Log.Warning($">>>>>>>>>> MVC:  requestDto.Url: {request.RequestUri}");

                response = await _httpClient.SendAsync(request);
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var responseDto = JsonSerializer.Deserialize<ResponseDto>(content, new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });

                    Log.Warning($">>>>>>>>>> MVC:  ResponseDto: {response.StatusCode}{response.ReasonPhrase}");

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
                Log.Warning($">>>>>>>>>> MVC:  ERROR : {ex.Message}");

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
