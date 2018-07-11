using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using callback.Models;

namespace callback.Db
{
    public class CallbackContext : DbContext
    {

        public DbSet<Models.callback> Callbacks { get; set; }

        public CallbackContext()
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=Callback.db");
        }
    }
}
