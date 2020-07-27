using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Reflection;

namespace LoginEntityFramework
{
    public class LoginContext : DbContext
    {
        private readonly IConfiguration _Configuration;

        public LoginContext(DbContextOptions<LoginContext> options, IConfiguration Configuration) : base(options)
        {
            _Configuration = Configuration;
        }

        public DbSet<User> User { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly()); //.Entity<LoginContext>(); //(typeof(LoginContext).Assembly);
        }
    }
}
