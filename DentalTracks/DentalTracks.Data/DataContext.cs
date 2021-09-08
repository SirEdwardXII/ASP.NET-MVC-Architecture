using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.SqlServer;

using DentalTracks.Data.Entities;

namespace DentalTracks.Data
{
    public class DataContext :DbContext
    {
        public DataContext() : base("DentalTracks") { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<DataContext>(null);

            base.OnModelCreating(modelBuilder);
        }

        // nav entities
        public DbSet<Menu> Menus { get; set; }
        public DbSet<MenuItem> MenuItems { get; set; }
        public DbSet<MenuItemRelationship> MenuItemRelationships { get; set; }

        // Contact
        public DbSet<Contact> Contact { get; set; }
    }
}
