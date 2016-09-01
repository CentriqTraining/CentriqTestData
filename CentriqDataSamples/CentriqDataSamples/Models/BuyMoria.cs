using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CentriqDataSamples.Models
{
    public class BuyMoria : DbContext
    {
        public BuyMoria() : base("Data Source=eycwy8k7jl.database.windows.net;Initial Catalog=ChuckData;Persist Security Info=True;User ID=paradigmone;Password=Paradigm1") { }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Expense> Expenses { get; set; }
    }
}