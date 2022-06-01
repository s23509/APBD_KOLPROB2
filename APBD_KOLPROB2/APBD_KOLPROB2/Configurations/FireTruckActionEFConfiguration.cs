using APBD_KOLPROB2.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace APBD_KOLPROB2.Configurations
{
    public class FireTruckActionEFConfiguration : IEntityTypeConfiguration<FireTruckAction>
    {
        public void Configure(EntityTypeBuilder<FireTruckAction> builder)
        {
            builder.HasKey(e => new { e.IdFireTruck, e.IdAction }).HasName("FireTruckAction.pk");
            builder.Property(e => e.AssignmentDate).IsRequired().HasDefaultValue(System.DateTime.Now);
            builder.HasOne(e => e.IdFireTruckNavigation)
                .WithMany(e => e.FireTruckActions)
                .HasForeignKey(e => e.IdFireTruck)
                .HasConstraintName("FireTruckAction_FireTruck")
                .OnDelete(DeleteBehavior.ClientSetNull);
            builder.HasOne(e => e.IdActionNavigation)
                .WithMany(e => e.FireTruckActions)
                .HasForeignKey(e => e.IdAction)
                .HasConstraintName("FireTruckAction_Action")
                .OnDelete(DeleteBehavior.ClientSetNull);

            //Adding Sample Data
            builder.HasData(
                new FireTruckAction { IdFireTruck = 1, IdAction = 2, AssignmentDate = System.DateTime.Today.AddDays(-12)},
                new FireTruckAction { IdFireTruck = 4, IdAction = 2, AssignmentDate= System.DateTime.Today.AddDays(-12)},
                new FireTruckAction { IdFireTruck = 2, IdAction = 1, AssignmentDate = System.DateTime.Today.AddDays(-5)},
                new FireTruckAction { IdFireTruck = 4, IdAction = 3, AssignmentDate = System.DateTime.Today},
                new FireTruckAction { IdFireTruck = 3, IdAction = 2, AssignmentDate = System.DateTime.Today.AddDays(-11)}
            );

            builder.ToTable("FireTruck_Action");
        }
    }
}
