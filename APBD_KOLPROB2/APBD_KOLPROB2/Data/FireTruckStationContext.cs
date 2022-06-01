using APBD_KOLPROB2.Configurations;
using APBD_KOLPROB2.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace APBD_KOLPROB2.Data
{
    public class FireTruckStationContext : DbContext
    {
        public FireTruckStationContext(DbContextOptions<FireTruckStationContext> options) : base(options) 
        { }

        public virtual DbSet<FireTruck> FireTrucks { get; set; }
        public virtual DbSet<Action> Actions { get; set; } 
        public virtual DbSet<FireTruckAction> FireTruckActions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(
                typeof(ActionEFConfiguration).GetTypeInfo().Assembly
            );
        }

    }
}
