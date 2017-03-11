using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MediaParser.BusinessLogic.YoutubeBL;
using MediaParser.Models.ViewModels;
using System.Net;
using MediaParser.Data;
using MediaParser.Entities.Entities;

namespace MediaParser.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult IndexPost(string link)
        {
            if (!string.IsNullOrEmpty(link))
            {
                try
                {
                    var infoUnit = new YoutubeLogic().GetDownloadUrls(link);
                    using (var unitOfWork = new UnitOfWork())
                    {
                        unitOfWork.InputLinkHistoryRepository.Create(new InputLinkHistoryEntity() { Date = DateTime.Now, Url = link });
                        unitOfWork.Save();
                    }
                    return PartialView("~/Views/FormatDetailsTable/_FormatDetailsTable.cshtml", infoUnit);
                }
                catch
                {
                    return PartialView("~/Views/FormatDetailsTable/_ErrorPartial.cshtml");
                }
            }
            return PartialView("~/Views/FormatDetailsTable/_ErrorPartial.cshtml");
        }

        public ActionResult Contact()
        {
            return View();
        }
    }
}