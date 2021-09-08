using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DentalTracks.Core.Enums;
using DentalTracks.Core.Models;

namespace DentalTracks.Data.Repositories
{
    public class NavRepository
    {
        public List<NavMenuItem> GetTopLevelMenuItemsByKey(string menuSecurityKey)
        {
            using(var dc = new DataContext())
            {
                var list = dc.Menus
                    .Join(dc.MenuItems, m => m.MenuId, i => i.MenuId, (m, i) => new { Menu = m, Items = i })
                    .Where(x => x.Menu.SecurityKey == menuSecurityKey)
                    .Where(x => x.Items.Enabled)
                    .Select(x => x.Items)
                    .OrderBy(x => x.SortOrder)
                    .ToDomainMenuItem()
                    .ToList();

                return list;
            }
        }




    } // class



    // #################################
    // extension
    public static class NavExtensions
    {
        public static IEnumerable<NavMenuItem> ToDomainMenuItem(this IEnumerable<Entities.MenuItem> entities)
        {
            return entities.Select(x => new NavMenuItem()
                {
                    MenuItemId = x.MenuItemId,
                    MenuId = x.MenuId,
                    Text = x.Text,
                    NavigateUrl = x.NavigateUrl,
                    SortOrder = x.SortOrder,
                    Enabled = x.Enabled,
                    CssClass = x.CssClass,
                    Children = new List<NavMenuItem>()
                });
        }
    }




}
