using Newtonsoft.Json;
using System;
using System.Web;

namespace WeChat.Service
{
    public class AccessTokenService
    {
        private static readonly string appId = "wxe50bdb27143920a2";
        private static readonly string appsecret = "819a7a07c583a1e425e00ca6135a5569";

        public static string GetAccessToken()
        {
            HttpCookie cookie = HttpContext.Current.Request.Cookies.Get("accessToken");

            // Check if cookie exists in the current request.
            if (cookie == null)
            {
                AccessToken token = (AccessToken)JsonConvert.DeserializeObject(AppService.HttpRequestGet("https://api.weixin.qq.com/cgi-bin/token?grant_type=client_credential&appid=" + appId + "&secret=" + appsecret), typeof(AccessToken));

                if (token != null && !string.IsNullOrWhiteSpace(token.Access_Token))
                {
                    cookie = new HttpCookie("accessToken")
                    {
                        Value = token.Access_Token,
                        // Set cookie to expire in 2 hours.
                        Expires = DateTime.Now.AddHours(2)
                    };
                    // Insert the cookie in the current HttpResponse.
                    HttpContext.Current.Response.Cookies.Add(cookie);

                    return token.Access_Token;
                }
                else
                {
                    return "Try again in sometime.";
                }
            }
            else
            {
                return cookie.Value;
            }
        }

    }

    public class AccessToken
    {
        // Properties
        public string Access_Token { get; set; }

        public int Expires_In { get; set; }
    }



}
