using System.Web.Mvc;


using Umbraco.Web.Mvc;

using Umbraco.Web.Models;
using mnttito.ViewModels;

namespace mnttito.Controllers
{
    public class HomepageController : RenderMvcController
    {
        string ThumbnailImageUrltest = "dsdsdsds";

        // GET: Homepage
        public override ActionResult Index(ContentModel model)
        {

            var homepageViewModel = new HomepageViewModel(model.Content);

            ThumbnailImageUrltest = homepageViewModel.ThumbnailImageUrl;

            return CurrentTemplate(homepageViewModel);
        }
    }
}