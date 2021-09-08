using DentalTracks.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DentalTracks.Core.Models;
namespace DentalTracks.Service
{
    public class ContactService
    {

        private ContactRepository _contactRepository;

        public ContactService()
        {
            _contactRepository = new ContactRepository();
        }

        public string CreateContact(Contact model)
        {
            try
            {
                _contactRepository.CreateContact(model.ToEntitiesContact());
                return model.ToString();
            }
            catch {
                throw;
            }
        }

        public List<Contact> GetContact()
        {
            return _contactRepository.GetContact();
        }
    }

    // extension for mapping core.models.contact to entity model.
    // mapper can be used instead of this code.
    public static class ContactServiceMappingExtensions
    {
        public static DentalTracks.Data.Entities.Contact ToEntitiesContact(this Core.Models.Contact model)
        {
            var dto = new DentalTracks.Data.Entities.Contact();
            dto.FirstName = model.FirstName;
            dto.LastName = model.LastName;
            dto.Message = model.Message;
            dto.Subject = model.Subject;
            dto.EmailAddress = model.EmailAddress;
            dto.CreatedDate = model.CreatedDate;
            return dto;
        }
    }
}
