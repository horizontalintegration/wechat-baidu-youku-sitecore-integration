using Sitecore.Diagnostics;
using System;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Xml.Linq;
using System.Linq;
using System.Xml.XPath;
using WeChat.Service;

namespace WeChatIntegration.Mvc
{
    /// <summary>
    /// Summary description for Verification
    /// </summary>
    public class Verification : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            var token = "Q1W2E3R4T5Y";
            var signature = context.Request.QueryString["signature"];
            var timestamp = context.Request.QueryString["timestamp"];
            var nonce = context.Request.QueryString["nonce"];
            var echostr = context.Request.QueryString["echostr"];

            string[] parameters = { token, timestamp, nonce };

            Array.Sort(parameters);

            var combinedParams = new StringBuilder();

            foreach (var param in parameters)
                combinedParams.Append(param);

            SHA1 sha = new SHA1CryptoServiceProvider();

            // This is one implementation of the abstract class SHA1.
            byte[] hashData = sha.ComputeHash(Encoding.UTF8.GetBytes(combinedParams.ToString()));

            //storing hashed vale into byte data type
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < hashData.Length; i++)
            {
                sb.Append(hashData[i].ToString("x2"));
            }

            if (!string.IsNullOrWhiteSpace(signature) && signature.Equals(sb.ToString()))
            {
                if (!string.IsNullOrWhiteSpace(echostr))
                {
                    context.Response.ContentType = "text/plain";
                    context.Response.Write(echostr);
                }
                //else
                //{
                //    string[] keys = context.Request.Form.AllKeys;

                //    var doc = XDocument.Parse(keys[0]);

                //    if (doc != null && doc.Root.Elements().Any())
                //    {
                //        var baseElement = doc.XPathSelectElement("/xml");

                //        if (baseElement != null && !baseElement.IsEmpty)
                //        {
                //            if (baseElement.Element("Event").Value.Equals("<![CDATA[subscribe]]>"))
                //            {
                //                context.Response.ContentType = "application/xml";
                //                string response = $"<xml><ToUserName>{baseElement.Element("FromUserName")}</ToUserName><FromUserName>{baseElement.Element("ToUserName")}</FromUserName><CreateTime>{(Int32)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds}</CreateTime><MsgType><![CDATA[text]]></MsgType><Content><![CDATA[Hello]]></Content></xml>";
                //                context.Response.Write(response);
                //            }
                //        }
                //    }
                //}
            }
            else
            {
                context.Response.ContentType = "text/plain";
                context.Response.Write("You are not supposed to be here.");
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}