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
        
        ServiceViewModel serviceViewModel = new ServiceViewModel();

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


        public override ActionResult Index(ContentModel model)
        {


            //get all content from root,we are loop thought all values..
            var rootContent = Umbraco.ContentAtRoot();

            if (rootContent != null)
            {

                foreach (var item in rootContent)
                {
                    if (item != null)
                    {
                        //cover section
                        serviceViewModel.coverTitle = item.Value("coverTitle").ToString();
                        serviceViewModel.coverLead = item.Value("coverLead").ToString();
                        serviceViewModel.coverParagraph = item.Value("coverParagraph").ToString();
                        serviceViewModel.coverPhoneNumber = item.Value("coverPhoneNumber").ToString();
                        serviceViewModel.coverImage = GetCoverImage();




                        //service section
                        serviceViewModel.headingTitle = item.Value("headingTitle").ToString();
                        serviceViewModel.paragraph = item.Value("paragraph").ToString();
                        serviceViewModel.bodyTextService = item.Value("bodyTextService").ToString();
                    }

                    else {
                    
                        //call errprpage--
                    }

               

                }
            }


            serviceViewModel.Services = MapService(serviceViewModel.Services);

          
            return CurrentTemplate(serviceViewModel);
        }


        private IList<ServiceViewModel> MapService(IList<ServiceViewModel> services)
        {
            var list = Umbraco.ContentAtRoot().FirstOrDefault(x => x.ContentType.Alias == "home");
            foreach (var item in list.Children.Where(x=> x.ContentType.Alias== "services").Take(3))
            {
               
                    services.Add(new ServiceViewModel { heading = item.Value("heading").ToString(), icon = item.Value("icon").ToString(), bodyText = item.Value("bodyText").ToString() });
               
            }

            return services;
        }

      
    }
}