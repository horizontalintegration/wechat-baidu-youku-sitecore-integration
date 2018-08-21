using Sitecore.Diagnostics;
using System.Web.Mvc;
using WeChat.Service;

namespace WeChatIntegration.Mvc.Controllers
{
    public class HomepageController : Controller
    {
        // GET: Homepage
        public ActionResult Homepage()
        {
            //if (Request.Cookies["SC_ANALYTICS_GLOBAL_COOKIE"] != null)
            //    Log.Info("Analytics Global Cookie" + Request.Cookies["SC_ANALYTICS_GLOBAL_COOKIE"].Value, this);
            //else
            //    Log.Info("Analytics Global Cookie Null", this);

            string code = Request.QueryString["code"];

            var userInfo = UserInfoService.GetUserInfo(code);

            if (userInfo != null)
            {                
                ContactService.AddContact(userInfo);                
            }

            return View("/Views/Homepage.cshtml");
        }
    }
}