using HttpClientToCurl;
using Newtonsoft.Json;
using Polly;
using Polly.Retry;
using SabzMarket.Share;
using SabzMarket.Share.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;


namespace SabzMarket.Http
{
    public sealed class HttpClientHelper
    {
        private readonly HttpClient client;

        private static readonly Lazy<HttpClientHelper> _instance =
          new Lazy<HttpClientHelper>(() => new HttpClientHelper());

        private readonly AsyncRetryPolicy<HttpResponseMessage> _retryPolicy;

        private static readonly HttpClient logClient = new HttpClient()
        {
            BaseAddress = new Uri(RouteConstants.BaseUrl),
            Timeout = TimeSpan.FromSeconds(30)
        };


        private HttpClientHelper()
        {
            client = new HttpClient
            {
                BaseAddress = new Uri(RouteConstants.BaseUrl),
                Timeout = TimeSpan.FromSeconds(60)
            };


            _retryPolicy = Policy
                            .HandleResult<HttpResponseMessage>(r =>
                          !r.IsSuccessStatusCode)
                            .Or<HttpRequestException>()
                            .Or<TaskCanceledException>()
                            .WaitAndRetryAsync(
          retryCount: 3,
          sleepDurationProvider: attempt => TimeSpan.FromSeconds(2)
    );
        }

        public static HttpClientHelper Instance
        {
            get
            {
                return _instance.Value;
            }
        }
        public async Task<T> GetAsync<T>(string route)
        {
            string curl = "";
            try
            {
                var req = new HttpRequestMessage(HttpMethod.Get, new Uri(RouteConstants.BaseUrl + route));


                curl = client.GenerateCurlInString(req);
                var response = await _retryPolicy.ExecuteAsync(() => client.SendAsync(req));
                if (!response.IsSuccessStatusCode)
                {


                    var result1 = await LogError<T, ErrorLogDTO>(new ErrorLogDTO
                    {
                        Curl = curl,
                        Layer = GetType().Name,
                        Message = string.Format("StatusCode= {0}", response.StatusCode)
                    });
                    return result1;
                }
                string content = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<T>(content);
                return result;
            }
            catch (Exception ex)
            {
                var resulr = await LogError<T, ErrorLogDTO>(new ErrorLogDTO
                {
                    Curl = curl,
                    Layer = GetType().Name,
                    Message = ex.Message,
                    Route = route,
                    Source = ex.Source,
                    StackTrace = ex.StackTrace
                });
                return resulr;
            }
        }

        public async Task<Tout> PostWithFileAsync<Tout, Tin>(string route, string filePath, Tin data)
        {
            var form = new MultipartFormDataContent();
            string curl = "";
            try
            {
                PropertyInfo[] properties = typeof(Tin).GetProperties();

                foreach (var property in properties)
                {
                    var value = property.GetValue(data);

                    if (value == null)
                    {
                        continue;
                    }

                    var propertyName = property.Name;

                    form.Add(new StringContent(value.ToString()!), propertyName);
                }

                if (!string.IsNullOrEmpty(filePath) && File.Exists(filePath))
                {
                    var bytes = await File.ReadAllBytesAsync(filePath);
                    var fileContent = new ByteArrayContent(bytes);

                    form.Add(fileContent, "file", Path.GetFileName(filePath));
                }

                var req = new HttpRequestMessage(HttpMethod.Post, new Uri(RouteConstants.BaseUrl + route))
                {
                    Content = form,
                };
                curl = client.GenerateCurlInString(req);
                var response = await _retryPolicy.ExecuteAsync(() => client.SendAsync(req));
                if (!response.IsSuccessStatusCode)
                {
                    var result1 = await LogError<Tout, ErrorLogDTO>(new ErrorLogDTO
                    {
                        Curl = curl,
                        Layer = GetType().Name,
                        Message = string.Format("StatusCode= {0}", response.StatusCode)
                    });
                    return result1;
                }
                string content = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<Tout>(content);
                return result;
            }
            catch (Exception ex)
            {
                var result = await LogError<Tout, ErrorLogDTO>(new ErrorLogDTO
                {
                    Curl = curl,
                    Layer = GetType().Name,
                    Message = ex.Message,
                    Route = route,
                    Source = ex.Source,
                    StackTrace = ex.StackTrace
                });
                return result;
            }
        }


        public async Task<Tout> PostAsync<Tout, Tin>(string route, Tin data)
        {
            string curl = "";
            try
            {
                string json = JsonConvert.SerializeObject(data);
                StringContent stringContent = new StringContent(json, Encoding.UTF8, "application/json");
                var req = new HttpRequestMessage(HttpMethod.Post, new Uri(RouteConstants.BaseUrl + route))
                {
                    Content = stringContent,
                };
                curl = client.GenerateCurlInString(req);
                var response = await _retryPolicy.ExecuteAsync(() => client.SendAsync(req));
                if (!response.IsSuccessStatusCode)
                {
                    var result1 = await LogError<Tout, ErrorLogDTO>(new ErrorLogDTO
                    {
                        Curl = curl,
                        Layer = GetType().Name,
                        Message = string.Format("StatusCode= {0}", response.StatusCode)
                    });
                    return result1;
                }
                string content = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<Tout>(content);
                return result;
            }
            catch (Exception ex)
            {
                var result = await LogError<Tout, ErrorLogDTO>(new ErrorLogDTO
                {
                    Curl = curl,
                    Layer = GetType().Name,
                    Message = ex.Message,
                    Route = route,
                    Source = ex.Source,
                    StackTrace = ex.StackTrace
                });
                return result;
            }

        }
        private async Task<Tout> LogError<Tout, Tin>(Tin error)
        {
            try
            {
                string json = JsonConvert.SerializeObject(error);
                var stringContent = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await logClient.PostAsync(ApiRoutes.LogError, stringContent);
                string content = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<Tout>(content);
                return result;
            }
            catch (Exception ex)
            {
                await FileLogService.SaveFailedLogAsync(ex, GetType().Name);
                return default(Tout);
            }

        }
    }
}
