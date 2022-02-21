using System.Web.Mvc;


using Umbraco.Web.Mvc;

using Umbraco.Web.Models;
using mnttito.ViewModels;
using System.Linq;
using Umbraco.Core;
using Umbraco.Web;
using System.Collections.Generic;
using System;

namespace mnttito.Controllers
{
    public class HomeController : RenderMvcController
    {

        private string GetCoverImage() 
        {
            string imageId = "";
            string path = "";
            var rootImage = Umbraco.MediaAtRoot();

            foreach (var item in rootImage)
            {

                //finding the newest image, by created date.
                foreach (var items in item.Children.OrderByDescending(g => g.CreateDate).Take(1))
                {
                    var folderName = "coverimage";

                    if (folderName == items.Parent.Name)
                    {
                        imageId = items.Id.ToString();

                        path = Umbraco.Media(imageId).Url;

                    }


                }

            }
            return path;
      

        }

        // GET: Home
        public override ActionResult Index(ContentModel model)
        {

            

              var serviceViewModel = new ServiceViewModel();
       

            //get all content from root,we are loop thought all values..
            var rootContent = Umbraco.ContentAtRoot();

            if (rootContent != null)
            {

                foreach (var item in rootContent)
                {
                    //cover section
                    serviceViewModel.coverTitle = item.Value("coverTitle").ToString();
                    serviceViewModel.coverLead = item.Value("coverLead").ToString();
                    serviceViewModel.coverParagraph = item.Value("coverParagraph").ToString();
                    serviceViewModel.coverPhoneNumber = item.Value("coverPhoneNumber").ToString();
                    serviceViewModel.coverImage = GetCoverImage();




                    //service section
                    serviceViewModel.headingTextService = item.Value("headingTextService").ToString();
                    serviceViewModel.titleTextService = item.Value("titleTextService").ToString();
                    serviceViewModel.bodyTextService = item.Value("bodyTextService").ToString();

                }
            }


          

            //Returns all the services.
            serviceViewModel.Services = MapServices(serviceViewModel.Services);

            //Returns title, headline and content to the view.
           

            return CurrentTemplate(serviceViewModel);
        }

    



        private IList<ServiceViewModel> MapServices(IList<ServiceViewModel> services)
        {

            //add viewModel to it will be shown on cshtml page.

            var list = Umbraco.ContentAtRoot().FirstOrDefault().ChildrenOfType("services")
            .Where(x => x.IsVisible()).Take(3);

            if (list != null)
            {
                foreach (var item in list)
                {


                    foreach (var items in item.DescendantsOrSelf())
                    {
                        services.Add(new ServiceViewModel { heading = items.Value("heading").ToString(),icon = items.Value("icon").ToString(), bodyText= items.Value("bodyText").ToString() });
                   
                    }

                }

            }

            return services;
        }

      
    }
}