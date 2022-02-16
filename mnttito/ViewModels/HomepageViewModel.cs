using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Web.Models;

namespace mnttito.ViewModels
{
    public class HomepageViewModel : ContentModel
    {
        public HomepageViewModel(IPublishedContent content) : base(content)
        {

        }

        public string ThumbnailImageUrl { get; set; }
    }
}