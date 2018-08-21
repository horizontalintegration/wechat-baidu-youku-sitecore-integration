using BaiduMapIntergation.Models;
using Sitecore.Mvc.Presentation;
using System.Web.Mvc;

namespace BaiduMapIntergation.Controllers
{
    public class YoukuVideoController : Controller
    {
        // GET: YoukuVideo
        public ActionResult GetYoukuVideoId()
        {
            var datasourceId = RenderingContext.CurrentOrNull.Rendering.DataSource;
            var datasource = Sitecore.Context.Database.GetItem(datasourceId);

            if (datasource == null) return new EmptyResult();

            var viewModel = new YoukuVideoViewModel()
            {
                VideoId = datasource["Youku Video Id"]
            };

            return View("/Views/Youku/YoukuVideo.cshtml", viewModel);
        }
    }
}