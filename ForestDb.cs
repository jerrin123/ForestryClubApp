using ForestryClubApp.Controllers;
using ForestryClubApp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ForestryClubApp
{
    public class ForestDb: DbContext
    {

        public DbSet<AdminTable> AdminTables { get; set; }

        public DbSet<Category> CategoryTables { get; private set; }

        public DbSet<House_Table> HouseTables { get; set; }

       public DbSet<Contact_Table> HomeControllers { get; set; }

        public DbSet<User> Users { get; set; }
    }
}