using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Web.Models;

namespace mnttito.ViewModels
{
    public class HomeViewModel  : ContentModel
    {
        public HomeViewModel(IPublishedContent content) : base(content)
        {

        }
    }
}