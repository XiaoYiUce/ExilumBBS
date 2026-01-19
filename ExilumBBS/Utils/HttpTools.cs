using ExilumBBS.Models.Response;
using ExilumBBS.Services;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;

namespace ExilumBBS.Utils
{
    public class HttpTools
    {
        private const string BASE_URL = "https://gf2-bbs-api.exiliumgf.com";

        private HttpClient _httpClient;
        private ITokenService _tokenService;

        public HttpTools(HttpClient httpClient, ITokenService tokenService)
        {
            _httpClient = httpClient;
            _tokenService = tokenService;
            _httpClient.BaseAddress = new Uri(BASE_URL);
        }

        /// <summary>
        /// HTTP GET方法封装
        /// </summary>
        /// <param name="requestUrl">请求地址</param>
        /// <returns></returns>
        public async Task<BBSResponse?> GetAsync(string requestUrl, bool noToken = false)
        {
            if (_httpClient.DefaultRequestHeaders.Contains("Authorization"))
            {

                _httpClient.DefaultRequestHeaders.Remove("Authorization");

            }

            var token = "";
            if (noToken == false)
            {
                token = await _tokenService.GetToken();
                if (token != null)
                {
                    _httpClient.DefaultRequestHeaders.Add("Authorization", token);
                }
            }

            var response = await _httpClient.GetAsync(requestUrl);
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                if (!string.IsNullOrEmpty(json))
                {
                    return JsonSerializer.Deserialize<BBSResponse>(json);
                }
            }

            if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                return new BBSResponse
                {
                    Code = 401,
                    Message = "请重新登录!"
                };
            }

            return null;
        }

        public async Task<BBSResponse?> PostAsync(string requestUrl, object? data, bool noToken = false)
        {
            if (_httpClient.DefaultRequestHeaders.Contains("Authorization"))
            {

                _httpClient.DefaultRequestHeaders.Remove("Authorization");

            }

            var token = "";
            if (noToken == false)
            {
                token = await _tokenService.GetToken();
                if (token != null)
                {
                    _httpClient.DefaultRequestHeaders.Add("Authorization", token);
                }
            }

            var response = await _httpClient.PostAsJsonAsync(requestUrl, data);
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                if (!string.IsNullOrEmpty(json))
                {
                    return JsonSerializer.Deserialize<BBSResponse>(json);
                }
            }

            return null;
        }
    }
}
