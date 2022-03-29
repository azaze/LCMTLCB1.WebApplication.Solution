using LCMTLCB1WebApplication.Models;
using LCMTLCB1WebApplication.Services.DataModels;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;

namespace LCMTLCB1WebApplication.Controllers
{
    public class NewsController : Controller
    {
        private readonly ILogger<NewsController> _logger;

        public NewsController(ILogger<NewsController> logger)
        {
            _logger = logger;
        }
        public IActionResult Index()
        {
            var requestCultureFeature = HttpContext.Features.Get<IRequestCultureFeature>();
            var culture = requestCultureFeature.RequestCulture.UICulture;
            ViewData["Lang"] = culture;
            ViewData["Menu"] = "News";
            return View();
        }


        public IActionResult List(int? page)
        {
            var requestCultureFeature = HttpContext.Features.Get<IRequestCultureFeature>();
            var culture = requestCultureFeature.RequestCulture.UICulture;

            NewsListViewModel _listModel = new NewsListViewModel();
            _listModel.paging = new Paging()
            {
                itemsOnPage = 10,
                items = 90,
                pageNumber = page == null ? 1 : (int)page
            };

            _listModel.NewsList = new List<News>();
            for (int i = 1; i <= 10; i++) {
                _listModel.NewsList.Add(new News()
                {
                    NewsID = i,
                    Subject = "News " + i.ToString(),
                    Detail = " Lorem ipsum dolor sit amet, consectetur adipiscing elit. Aenean euismod bibendum laoreet. Proin gravida dolor sit amet lacus accumsan et viverra justo commodo. Proin sodales pulvinar sic tempor. Sociis natoque ... Lorem ipsum dolor sit amet, consectetur adipiscing elit. Aenean euismod bibendum laoreet. Proin gravida dolor sit amet lacus accumsan et viverra justo commodo. Proin sodales pulvinar sic tempor. Sociis natoque   Lorem ipsum dolor sit amet, consectetur adipiscing elit. Aenean euismod bibendum laoreet. Proin gravida dolor sit amet lacus accumsan et viverra justo commodo. Proin sodales pulvinar sic tempor. Sociis natoque Lorem ipsum dolor sit amet, consectetur adipiscing elit. Aenean euismod bibendum laoreet. Proin gravida dolor sit amet lacus accumsan et viverra justo commodo. Proin sodales pulvinar sic tempor. Sociis natoque  <br /><br />"
                    + " Lorem ipsum dolor sit amet,"
                    + " consectetur adipiscing elit.Aenean euismod bibendum laoreet.Proin gravida dolor sit amet lacus accumsan et viverra justo commodo.Proin sodales pulvinar sic tempor.Sociis natoque Lorem ipsum dolor sit amet,"
                    + " consectetur adipiscing elit.Aenean euismod bibendum laoreet.Proin gravida dolor sit amet lacus accumsan et viverra justo commodo.Proin sodales pulvinar sic tempor.Sociis natoque Lorem ipsum dolor sit amet,"
                    + " consectetur adipiscing elit.Aenean euismod bibendum laoreet.Proin gravida dolor sit amet lacus accumsan et viverra justo commodo.Proin sodales pulvinar sic tempor.Sociis natoque ",
                    PublishDate = new DateTime(2022,02,17,0,0,0),
                    Thumbnail = "https://ichef.bbci.co.uk/news/976/cpsprodpb/31F5/production/_112098721_gettyimages-1075953222.jpg",
                    Images = new List<string>()
                    {
                        "https://ichef.bbci.co.uk/news/976/cpsprodpb/31F5/production/_112098721_gettyimages-1075953222.jpg",
                    }
                });
            }

            return PartialView(_listModel);
        }

        public IActionResult Detail(int newsid)
        {
            var requestCultureFeature = HttpContext.Features.Get<IRequestCultureFeature>();
            var culture = requestCultureFeature.RequestCulture.UICulture;
            ViewData["Lang"] = culture;
            ViewData["Menu"] = "News";

            NewsDetailViewModel _model = new NewsDetailViewModel();

            _model.News = new News() {
                NewsID = newsid,
                Subject = "News " + newsid.ToString(),
                Detail = " Lorem ipsum dolor sit amet, consectetur adipiscing elit. Aenean euismod bibendum laoreet. Proin gravida dolor sit amet lacus accumsan et viverra justo commodo. Proin sodales pulvinar sic tempor. Sociis natoque ... Lorem ipsum dolor sit amet, consectetur adipiscing elit. Aenean euismod bibendum laoreet. Proin gravida dolor sit amet lacus accumsan et viverra justo commodo. Proin sodales pulvinar sic tempor. Sociis natoque   Lorem ipsum dolor sit amet, consectetur adipiscing elit. Aenean euismod bibendum laoreet. Proin gravida dolor sit amet lacus accumsan et viverra justo commodo. Proin sodales pulvinar sic tempor. Sociis natoque Lorem ipsum dolor sit amet, consectetur adipiscing elit. Aenean euismod bibendum laoreet. Proin gravida dolor sit amet lacus accumsan et viverra justo commodo. Proin sodales pulvinar sic tempor. Sociis natoque  <br /><br />"
                    + " Lorem ipsum dolor sit amet,"
                    + " consectetur adipiscing elit.Aenean euismod bibendum laoreet.Proin gravida dolor sit amet lacus accumsan et viverra justo commodo.Proin sodales pulvinar sic tempor.Sociis natoque Lorem ipsum dolor sit amet,"
                    + " consectetur adipiscing elit.Aenean euismod bibendum laoreet.Proin gravida dolor sit amet lacus accumsan et viverra justo commodo.Proin sodales pulvinar sic tempor.Sociis natoque Lorem ipsum dolor sit amet,"
                    + " consectetur adipiscing elit.Aenean euismod bibendum laoreet.Proin gravida dolor sit amet lacus accumsan et viverra justo commodo.Proin sodales pulvinar sic tempor.Sociis natoque ",
                PublishDate = new DateTime(2022, 02, 17, 0, 0, 0),
                Thumbnail = "https://ichef.bbci.co.uk/news/976/cpsprodpb/31F5/production/_112098721_gettyimages-1075953222.jpg",
                Images = new List<string>()
                    {
                        "https://ichef.bbci.co.uk/news/976/cpsprodpb/31F5/production/_112098721_gettyimages-1075953222.jpg",
                        "https://ichef.bbci.co.uk/news/976/cpsprodpb/6139/production/_112098842_gettyimages-92162840.jpg",
                        "https://ichef.bbci.co.uk/news/976/cpsprodpb/8015/production/_112098723_gettyimages-1131702041.jpg",
                        "https://ichef.bbci.co.uk/news/976/cpsprodpb/114E9/production/_112098807_gettyimages-1146485134.jpg"
                    }
            };

            return View(_model);
        }
    }
}
