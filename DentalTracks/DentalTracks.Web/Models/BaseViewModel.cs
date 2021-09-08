using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using DentalTracks.Core.Models;

namespace DentalTracks.Web.Models
{
    public class BaseViewModel
    {
        public BaseViewModel()
        {
            MenuItems = new List<NavMenuItem>();
        }

        public string PageTitle { get; set; }
        public string MetaDescription { get; set; }
        public string MetaKeywords { get; set; }
        public List<NavMenuItem> MenuItems { get; set; }
    }
}