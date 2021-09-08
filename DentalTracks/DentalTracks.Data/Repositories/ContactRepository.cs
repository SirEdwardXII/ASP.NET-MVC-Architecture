using DentalTracks.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalTracks.Data.Repositories
{
    public class ContactRepository
    {
        public bool CreateContact(Entities.Contact model)
        {
            try
            {
                using (var dc = new DataContext())
                {
                    dc.Contact.Add(model);
                    dc.SaveChanges();
                    return true;
                }
            }
            catch
            {
                throw;
            }

        }

        public List<Contact> GetContact()
        {
            using (var dc = new DataContext())
            {
                var list = dc.Contact
                    .OrderByDescending(x => x.Id)
                    .ToDomainContact()
                    .Take(20)
                    .ToList();

                return list;
            }
        }
    }

    // extension
    public static class ContactExtensions
    {
        public static IEnumerable<Contact> ToDomainContact(this IEnumerable<Entities.Contact> entities)
        {
            return entities.Select(x => new Contact()
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


    }
}
