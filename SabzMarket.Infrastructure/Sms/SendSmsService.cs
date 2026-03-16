using Newtonsoft.Json;
using SabzMarket.Infrastructure.Configuration.Sms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SabzMarket.Infrastructure.Sms
{
    public class SendSmsService : IDisposable
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

        public async Task<bool> SendSms(string Phone)
        {
            httpClient.DefaultRequestHeaders.Add("x-api-key", "GD3UGtSs42BGAAGY128fKCHpN4foc5y4j0loED2oHuac28lL");

            VerifySendModel model = new VerifySendModel()
            {
                Mobile = "09131334437",
                TemplateId = 251460,
                Parameters = new VerifySendParameterModel[]
                {
                    new VerifySendParameterModel()
                    {
                        Name = "OTP", Value = "5553"
                    }
                }
            };

            var payload = JsonConvert.SerializeObject(model);
            StringContent stringContent = new(payload, Encoding.UTF8, "application/json");

            var response = await httpClient.PostAsync("https://api.sms.ir/v1/send/verify", stringContent);
            string content = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<SmsOutput>(content);

            if (result.status == 1)
            {
                return true;
            }
            return false;
        }
    }
}
