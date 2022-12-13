using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using EasyGroceriesAPI.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace EasyGroceriesAPI.DataAccess;
public class EasyGroceriesDBContext : DbContext
{
    protected readonly IConfiguration Configuration;

    public EasyGroceriesDBContext(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public EasyGroceriesDBContext()
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        // connect to sqlite database
        options.UseSqlite(Configuration.GetConnectionString("EasyGroceriesApiDatabase"));
    }

    public DbSet<Product> Products { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderItem> OrderItems { get; set; }
    public DbSet<Customer> Customers { get; set; }
}
