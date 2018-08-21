using System.Web.Mvc;
using WeChat.Service;

namespace WeChatIntegration.Mvc.Controllers
{
    public class WeChatController : Controller
    {        
        public ActionResult CreateMenu()
        {
            return Content(CreateMenuService.CreateMenu());         
        }

        public ActionResult GetAccessToken()
        {
            return Content(AccessTokenService.GetAccessToken());
        }

        public ActionResult GetQRCode()
        {
            return Content(QRCodeService.CreateQRCode());
        }
    }
}