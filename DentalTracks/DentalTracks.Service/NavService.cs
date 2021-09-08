using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DentalTracks.Core.Models;
using DentalTracks.Core.Enums;
using DentalTracks.Data.Repositories;

namespace DentalTracks.Service
{
    public class NavService
    {
        private NavRepository _navRepository;

        public NavService()
        {
            _navRepository = new NavRepository();
        }

        public List<NavMenuItem> GetTopLevelMenuItemsByKey(string menuSecurityKey)
        {
            return _navRepository.GetTopLevelMenuItemsByKey(menuSecurityKey);
        }





    } // class
}
