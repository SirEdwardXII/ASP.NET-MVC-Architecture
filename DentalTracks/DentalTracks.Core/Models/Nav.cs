using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DentalTracks.Core.Enums;

namespace DentalTracks.Core.Models
{
    public class NavMenu
    {
        public int MenuId { get; set; }

        public string Name { get; set; }

        public string SecurityKey { get; set; }
    }


    public class NavMenuItem
    {
        public NavMenuItem()
        {
            Children = new List<NavMenuItem>();
        }

        public int MenuItemId { get; set; }

        public int MenuId { get; set; }

        public bool Active { get; set; }

        public string Text { get; set; }

        public string NavigateUrl { get; set; }

        public string CssClass { get; set; }

        public int SortOrder { get; set; }

        public bool Enabled { get; set; }

        public List<NavMenuItem> Children { get; set; }
    }


    public class NavMenuItemRelationship
    {
        public int MenuItemRelationshipId { get; set; }

        public int MenuItemId { get; set; }

        public int ParentMenuItemId { get; set; }

        public SecurityLevelEnum SecurityLevel { get; set; }
    }
}
