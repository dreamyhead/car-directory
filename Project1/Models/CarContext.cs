using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace Project1.Models
{
    public class CarContext : DbContext
    {
        public DbSet<Car> Cars { get; set; } = null!;
        public CarContext(DbContextOptions<CarContext> options)
            : base(options)
        {
        }
    }
}