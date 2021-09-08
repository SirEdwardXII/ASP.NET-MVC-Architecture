using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalTracks.Data.Entities
{
    [Table("Menu", Schema = "Nav")]
    public class Menu
    {
        public int MenuId { get; set; }

        public string Name { get; set; }

        public string SecurityKey { get; set; }
    }

    [Table("MenuItem", Schema = "Nav")]
    public class MenuItem
    {
        public int MenuItemId { get; set; }

        public int MenuId { get; set; }

        public string Text { get; set; }

        public string NavigateUrl { get; set; }

        public string CssClass { get; set; }

        public int SortOrder { get; set; }

        public bool Enabled { get; set; }
    }

    [Table("MenuItemRelationship", Schema = "Nav")]
    public class MenuItemRelationship
    {
        public int MenuItemRelationshipId { get; set; }

        public int MenuItemId { get; set; }

        public int ParentMenuItemId { get; set; }

        public int SecurityLevel { get; set; }
    }
}
