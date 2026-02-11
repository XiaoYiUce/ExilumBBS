using ExilumBBS.Models.Response;
using ExilumBBS.Services;
using ExilumBBS.State;
using Masa.Blazor;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Net.Http.Headers;
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

        /// <summary>
        /// HTTP POST封装
        /// </summary>
        /// <param name="requestUrl"></param>
        /// <param name="data"></param>
        /// <param name="noToken"></param>
        /// <returns></returns>
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

        /// <summary>
        /// 上传文件至OSS
        /// </summary>
        /// <param name="ossHost">OSS服务器请求地址</param>
        /// <param name="policy">OSS Policy</param>
        /// <param name="accessKeyId">OSS AccessKeyId</param>
        /// <param name="signature">OSS Signature</param>
        /// <param name="file">从系统内选的文件</param>
        /// <returns>上传后文件名</returns>
        public async Task<string?> UploadToOSS(string ossHost, string policy, string accessKeyId, string dir, string signature, FileResult file)
        {
            try
            {
                using var stream = await file.OpenReadAsync();
                using var memoryStream = new MemoryStream();
                await stream.CopyToAsync(memoryStream);
                var imageBytes = memoryStream.ToArray();

                // 解析原文件扩展名
                string fileName = file.FileName;
                string ext = Path.GetExtension(fileName);

                // 设置上传用的文件名
                var uploadFileName = $"{DateTimeOffset.UtcNow.ToUnixTimeMilliseconds()}{ext}"; //上传后文件名
                var key = dir + "${filename}";

                // 设置文件的Content
                var fileContent = new ByteArrayContent(imageBytes);
                var disposition = new ContentDispositionHeaderValue("form-data")
                {
                    Name = "\"file\"",
                    FileName = $"\"{uploadFileName}\"",
                };

                fileContent.Headers.ContentDisposition = disposition;
                string mimeType = ext.ToLowerInvariant() switch
                {
                    ".png" => "image/png",
                    ".jpg" or ".jpeg" => "image/jpeg",
                    ".gif" => "image/gif",
                    ".webp" => "image/webp",
                    ".bmp" => "image/bmp",
                    _ => "application/octet-stream" // 默认回退
                };

                fileContent.Headers.ContentType = MediaTypeHeaderValue.Parse(mimeType); //设置媒体类型

                // 添加验证数据头
                var nameContent = new StringContent(uploadFileName);
                var keyContent = new StringContent(key);
                var policyContent = new StringContent(policy);
                var accessKeyContent = new StringContent(accessKeyId);
                var successContent = new StringContent("200");
                var signatureContent = new StringContent(signature);

                // 溢出StringContent自带的ContentType
                nameContent.Headers.ContentType = null;
                keyContent.Headers.ContentType = null;
                policyContent.Headers.ContentType = null;
                accessKeyContent.Headers.ContentType = null;
                successContent.Headers.ContentType = null;
                signatureContent.Headers.ContentType = null;

                // 构造上传数据
                using var formData = new MultipartFormDataContent();
                formData.Add(nameContent, "\"name\"");
                formData.Add(keyContent, "\"key\"");
                formData.Add(policyContent, "\"policy\"");
                formData.Add(accessKeyContent, "\"OSSAccessKeyId\"");
                formData.Add(successContent, "\"success_action_status\"");
                formData.Add(signatureContent, "\"signature\"");
                formData.Add(fileContent, "file", $"\"{uploadFileName}\"");

                // 提取自动生成的Boundary值
                string? contentTypeHeader = formData.Headers.ContentType?.ToString();

                string? boundary = null;
                if (contentTypeHeader != null)
                {
                    var mediaType = MediaTypeHeaderValue.Parse(contentTypeHeader);
                    boundary = mediaType.Parameters
                        .FirstOrDefault(p => p.Name.Equals("boundary", StringComparison.OrdinalIgnoreCase))?
                        .Value!.Trim('"');
                }

                // 对dotnet自动生成的Content-Type进行替换，去除自动生成的头里面boundary包含的""号，用以兼容阿里云OSS（Fk OSS）
                formData.Headers.ContentType = new MediaTypeHeaderValue("multipart/form-data")
                {
                    Parameters = { new NameValueHeaderValue("boundary", boundary) }
                };

                // 上传
                using var httpClient = new HttpClient();

                var result = await httpClient.PostAsync(ossHost, formData);

                if (!result.IsSuccessStatusCode)
                {
                    Debug.Fail(await result.Content.ReadAsStringAsync());
                }
                return uploadFileName;
            }
            catch (Exception ex)
            {
                Debug.Fail(ex.Message);
            }

            return string.Empty;
        }
    }
}
