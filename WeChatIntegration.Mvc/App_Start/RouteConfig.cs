using Sitecore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

[assembly: PreApplicationStartMethod(typeof(WeChatIntegration.Mvc.RouteConfig), "Initialize")]

namespace WeChatIntegration.Mvc
{
    public class RouteConfig
    {
        public static void Initialize()
        {
            try
            {
                RegisterRoutes(RouteTable.Routes);
            }
            catch (Exception ex)
            {
                Log.Fatal("Error registering routes", ex, typeof(RouteConfig));
            }
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "CreateMenu",
                url: "api/wechat/createmenu",
                defaults: new { controller = "WeChat", action = "CreateMenu", id = UrlParameter.Optional }
                );

            routes.MapRoute(
                name: "GetQRCode",
                url: "api/wechat/getqrcode",
                defaults: new { controller = "WeChat", action = "GetQRCode", id = UrlParameter.Optional }
                );

            routes.MapRoute(
                name: "GetAccessToken",
                url: "api/wechat/getaccesstoken",
                defaults: new { controller = "WeChat", action = "GetAccessToken", id = UrlParameter.Optional }
                );
        }
    }
}
