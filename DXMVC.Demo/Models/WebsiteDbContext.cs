using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace DXMVC.Demo.Models
{
	 public class WebsiteDbContext : DbContext
	 {
		  public WebsiteDbContext() : base("DefaultConnection") { }
		  public DbSet<Customer> Customers { get; set; }
	 }
}
