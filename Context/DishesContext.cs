using Microsoft.EntityFrameworkCore;
using PR49.Modell;
using System;

namespace PR49.Context
{
    public class DishesContext : DbContext
    {
        public DbSet<Dishes> Dishes { get; set; }
        public DishesContext()
        {
            Database.EnsureCreated();
            Dishes.Load();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseMySql("server=127.0.0.1;" +
            "port=3306;" +
            "uid=root;" +
            "pwd=;" +
            "database=Dishes;",
            new MySqlServerVersion(new Version(8, 0, 11)));
    }
}
