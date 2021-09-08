using DentalTracks.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DentalTracks.Web.Models
{
    public class CreateContactViewModel : BaseViewModel
    {
        public CreateContactViewModel()
        {
            var navService = new NavService();
            this.MenuItems = navService.GetTopLevelMenuItemsByKey("Web");
        }

        public ContactViewModel contactViewModel { get; set; }
    }
}