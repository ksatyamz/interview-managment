using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using PanelMicroservice.Models.Domain;

namespace PanelMicroservice.Data
{
    public class PanelDbContext : DbContext
    {
        public PanelDbContext(DbContextOptions options) : base(options)
        {
            try
            {
                var databaseCreator = Database.GetService<IDatabaseCreator>() as RelationalDatabaseCreator;
                if (databaseCreator != null)
                {
                    if (!databaseCreator.CanConnect()) databaseCreator.Create();
                    if (!databaseCreator.HasTables()) databaseCreator.CreateTables();
                }

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }

        }
        public DbSet<Panel> panels { get; set; }
    }
}
