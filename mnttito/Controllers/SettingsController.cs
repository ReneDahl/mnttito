using ClientDependency.Core;
using mnttito.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Web;
using Umbraco.Web.Models;
using Umbraco.Web.Mvc;
using Umbraco.Web.WebApi.Filters;

namespace mnttito.Controllers
{
    public class SettingsController : SurfaceController
    {
        NavigationViewModel navigationViewModel = new NavigationViewModel();

        public PartialViewResult NavigationBar()
        {
            var rootContent = Umbraco.ContentAtRoot();

            foreach (var item in rootContent.Where(x => x.ContentType.Alias == "settings"))
            {
                if (item != null)
                {

                    navigationViewModel.brandname = item.Value("brandname").ToString();
                 
                }
                  
            }

            return PartialView("~/Views/Partials/Options/_Navbar.cshtml", navigationViewModel);
        }
    }
}