using Labs.Waters.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Labs.Waters.API.Data
{
    public class LabsDbContext : DbContext
    {
        public LabsDbContext(DbContextOptions<LabsDbContext> options) : base(options)
        {
            
        }

        public DbSet<Register>  Register { get; set; }

    }
}
