﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Web;
using Umbraco.Web.Composing;
using Umbraco.Web.Models;


namespace mnttito.ViewModels
{
    public class ServiceViewModel : ContentModel
    {
        public ServiceViewModel() : base(Current.UmbracoContext.PublishedRequest.PublishedContent)
        {
            //data from here, we are going to print it in a list.
            Services = new List<ServiceViewModel>();
        


        }

        public string heading { get; set; }

        public string icon { get; set; }
        public string bodyText { get; set; }

        public string headingTextService { get; set; }
        public string titleTextService { get; set; }
        public string bodyTextService { get; set; }

        public IList<ServiceViewModel> Services { get; set; }
       
    }
}