
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Models
{
    public class WeatherForecastDBContext : DbContext
    {
        public DbSet<WeatherForecast> wf { get; set; }

        public WeatherForecastDBContext()
        {
        }

        public WeatherForecastDBContext(DbContextOptions<WeatherForecastDBContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server= (local);Database=EFCoreExampleDB;Trusted_Connection=True; TrustServerCertificate=True ");
        }
    }
}
