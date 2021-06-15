using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FeedMe.DataAccess.Settings.G_Captcha.Interface
{
    public interface ICaptchaValidator
    {
        Task<bool> IsCaptchaPassedAsync(string token);
        Task<JObject> GetCaptchaResultDataAsync(string token);
        void UpdateSecretKey(string key);
    }
}
