using DentalTracks.Service;
using DentalTracks.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DentalTracks.Web.Controllers
{
    public class ContactController : Controller
    {

        private ContactService _contactService;

        public ContactController()
        {
            // can use dependency injection for loose couple between the classes.
            _contactService = new ContactService();
        }

        // GET: Contact
        public ActionResult Index()
        {
            var model = _contactService.GetContact().ToViewModelContact();
            var civm = new ContactIndexViewModel();
            civm.contactViewModel = model;
            return View(civm);
        }


        // GET: Contact/Create
        public ActionResult Create()
        {
            return View(new CreateContactViewModel());
        }

        // POST: Contact/Create
        [HttpPost]
        public ActionResult Create(CreateContactViewModel viewmodel)
        {
            try
            {
                if (!ModelState.IsValid) {
                    return View(viewmodel);
                }          
                var name = _contactService.CreateContact(viewmodel.contactViewModel.ToDTOContact());
                TempData["createdContact"] = "Contact created of '" + name + "'";
                return RedirectToAction("Index");
            }
            catch
            {
                // logger like log4net to log the error for debugging
                return View(viewmodel);
            }
        }


    }


    // extension these extention are for mapping viewmodel to core.models.contact and vice versa.
    // it will not be required if we use FastMapper or AutoMapper for mapping between 2 models.
    public static class ContactPresentationMappingExtensions
    {
        public static IEnumerable<ContactViewModel> ToViewModelContact(this IEnumerable<Core.Models.Contact> service)
        {
            return service.Select(x => new ContactViewModel()
            {
                Id = x.Id,
                FirstName = x.FirstName,
                LastName = x.LastName,
                EmailAddress = x.EmailAddress,
                CreatedDate = x.CreatedDate,
                Message = x.Message,
                Subject = x.Subject
            });
        }

        public static Core.Models.Contact ToDTOContact(this ContactViewModel model)
        {
            var dto = new Core.Models.Contact();
            dto.FirstName = model.FirstName;
            dto.LastName = model.LastName;
            dto.Message = model.Message;
            dto.Subject = model.Subject;
            dto.EmailAddress = model.EmailAddress;
            dto.CreatedDate = DateTimeOffset.Now;
            return dto;
        }
    }

}
