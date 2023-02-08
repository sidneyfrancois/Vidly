using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.Context
{
    public class VidlyDataContext : DbContext
    {
        public VidlyDataContext()
            :base("VidlyConnectionString")
        {}

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Customer> Customers { get; set; }
    }
}