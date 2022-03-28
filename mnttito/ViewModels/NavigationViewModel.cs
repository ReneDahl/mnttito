using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Web;
using Umbraco.Web.Composing;
using Umbraco.Web.Models;

namespace mnttito.ViewModels
{
    public class NavigationViewModel : ContentModel
    {
        public NavigationViewModel() : base(Current.UmbracoContext.PublishedRequest.PublishedContent)
        {
          

        }


        public string brandname { get; set; }

        public string brandnamecolor { get; set; }
        
    }
}