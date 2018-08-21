using BaiduMapIntergation.Models;
using Sitecore.Data.Fields;
using Sitecore.Data.Items;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace BaiduMapIntergation.Controllers
{
    public class LocationsController : Controller
    {
        // GET: Locations
        public ActionResult GetLocations()
        {
            MultilistField locationsField = Sitecore.Context.Item.Fields["Locations"];
            var locations = new List<LocationDetails>();

            if (locationsField.TargetIDs.Count() > 0)
            {
                foreach (var targetID in locationsField.TargetIDs)
                {
                    Item locationItem = Sitecore.Context.Database.GetItem(targetID);

                    if (locationItem != null)
                    {
                        var location = new LocationDetails();
                        location.Name = locationItem.DisplayName;
                        location.Latitude = locationItem["Latitude"];
                        location.Longitude = locationItem["Longitude"];

                        var sb = new StringBuilder();
                        sb.Append("<b>" + locationItem.DisplayName + "</b><br/>");
                        sb.AppendLine("<span><strong>" + Sitecore.Context.Item["Address Label"] + "：</strong> ");
                        sb.Append(locationItem["Address"] + ", ");
                        sb.Append(locationItem["City"] + ", ");
                        sb.Append(locationItem["State"] + "</span><br/>");
                        sb.AppendLine("<span><strong>" + Sitecore.Context.Item["Telephone Label"] + "：</strong> ");
                        sb.Append(locationItem["Telephone"] + "</span>");

                        location.Address = sb.ToString();

                        locations.Add(location);
                    }
                }

                var model = new LocationsViewModel()
                {
                    Locations = locations,
                };

                return View("/Views/Baidu/Locations.cshtml", model);
            }

            return new EmptyResult();
        }
    }
}