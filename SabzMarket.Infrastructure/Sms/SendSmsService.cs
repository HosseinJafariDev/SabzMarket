using Newtonsoft.Json;
using SabzMarket.Application.Interfaces.Services;
using System.Text;
using SabzMarket.Infrastructure.Sms.Configuration;

namespace SabzMarket.Infrastructure.Sms
{
    public class SendSmsService : ISendSmsService, IDisposable
    {
        HttpClient httpClient;
        public SendSmsService()
        {
            httpClient = new HttpClient();
        }

        public void Dispose()
        {
            httpClient.Dispose();
        }

        public async Task<bool> SendSmsOtp(string Phone, string otp, CancellationToken token)
        {
            httpClient.DefaultRequestHeaders.Add("x-api-key", "GD3UGtSs42BGAAGY128fKCHpN4foc5y4j0loED2oHuac28lL");

            VerifySendModel model = new VerifySendModel()
            {
                Mobile = Phone,
                TemplateId = 251460,
                Parameters = new VerifySendParameterModel[]
                {
                    new VerifySendParameterModel()
                    {
                        Name = "OTP", Value = otp
                    }
                }
            };

            var payload = JsonConvert.SerializeObject(model);
            StringContent stringContent = new(payload, Encoding.UTF8, "application/json");

            var response = await httpClient.PostAsync("https://api.sms.ir/v1/send/verify", stringContent, token);
            string content = await response.Content.ReadAsStringAsync(token);
            var result = JsonConvert.DeserializeObject<SmsOutput>(content);

            if (result.status == 1)
            {
                return true;
            }
            return false;
        }
    }
}
