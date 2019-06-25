using hacker2019_bester.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace hacker2019_bester.Data
{
    public class Context : DbContext
    {
        public IConfiguration Configuration { get; }
        public Context(DbContextOptions<Context> options, IConfiguration configuration) : base(options)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string _connectionString = Configuration.GetConnectionString("postgres");
            optionsBuilder.UseNpgsql(_connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }

        public DbSet<HealthCheck> HealthCheck { get; set; }
    }
}
