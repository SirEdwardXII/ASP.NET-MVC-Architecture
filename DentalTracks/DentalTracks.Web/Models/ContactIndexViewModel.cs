using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using DentalTracks.Service;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DentalTracks.Web.Models
{
    public class ContactIndexViewModel : BaseViewModel
    {
        public ContactIndexViewModel()
        {
            var navService = new NavService();
            this.MenuItems = navService.GetTopLevelMenuItemsByKey("Web");
        }

       public IEnumerable<ContactViewModel> contactViewModel { get; set; }
    }

    public class ContactViewModel
    {
        public int Id { get; set; }

        [Required, DisplayName("First name")]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 3)]
        public string FirstName { get; set; }

        [Required, DisplayName("Last name")]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 3)]
        public string LastName { get; set; }

        [Required, DisplayName("Email")]
        [EmailAddress]
        public string EmailAddress { get; set; }

        [DisplayName("Subject")]
        public string Subject { get; set; }

        [DisplayName("Message")]
        public string Message { get; set; }

        public DateTimeOffset CreatedDate { get; set; }

    }
}