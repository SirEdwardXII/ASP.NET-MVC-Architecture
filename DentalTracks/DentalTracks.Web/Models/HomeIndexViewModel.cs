using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using DentalTracks.Service;

namespace DentalTracks.Web.Models
{
    public class HomeIndexViewModel : BaseViewModel
    {
        public HomeIndexViewModel()
        {
            var navService = new NavService();
            this.MenuItems = navService.GetTopLevelMenuItemsByKey("Web");
        }
    }
}