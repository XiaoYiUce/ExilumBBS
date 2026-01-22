using ExilumBBS.Models.Response;
using ExilumBBS.Services;
using ExilumBBS.State;
using Masa.Blazor;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        private IPopupService _popupService;
        private IUserService _userService;
        private UserState _userState;

        public HttpTools(HttpClient httpClient, ITokenService tokenService, IPopupService popupService, IUserService userService, UserState userState)
        {
            _httpClient = httpClient;
            _tokenService = tokenService;
            _popupService = popupService;
            _userService = userService;
            _userState = userState;
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
                token = await _tokenService.GetTokenAsync();
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
                await _popupService.EnqueueSnackbarAsync("请重新登录!", AlertTypes.Warning);
                if (!string.IsNullOrEmpty(_userState.Token))
                {
                    await _tokenService.DeleteTokenAsync(_userState.Token);

                }

                if (_userState.CurrentUserProfile != null)
                {
                    await _userService.DeleteUserProfile(_userState.CurrentUserProfile.Uid);
                }

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

#if DEBUG
            Debug.WriteLine($"HttpTools Post Method RequestUrl:{requestUrl}");
#endif

            var token = "";
            if (noToken == false)
            {
                token = await _tokenService.GetTokenAsync();
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

            if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
#if DEBUG
                Debug.WriteLine($"HttpTools Post Method RequestUrl:{requestUrl},StatusCode:401");
#endif
                await _popupService.EnqueueSnackbarAsync("请重新登录!", AlertTypes.Warning);
                if (!string.IsNullOrEmpty(_userState.Token))
                {
                    await _tokenService.DeleteTokenAsync(_userState.Token);

                }

                if (_userState.CurrentUserProfile != null)
                {
                    await _userService.DeleteUserProfile(_userState.CurrentUserProfile.Uid);
                }
            }

            return null;
        }
    }
}
