using APBD_KOLPROB2.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace APBD_KOLPROB2.Configurations
{
    public class FireTruckEFConfiguration : IEntityTypeConfiguration<FireTruck>
    {
        public void Configure(EntityTypeBuilder<FireTruck> builder)
        {
            builder.HasKey(e => e.IdFireTruck).HasName("FireTruck_pk");
            builder.Property(e => e.IdFireTruck).UseIdentityColumn();
            builder.Property(e => e.OperationNumber).IsRequired().HasMaxLength(10);
            builder.Property(e => e.SpecialEquipment).IsRequired();

            //Adding Sample Data
            builder.HasData(
                new FireTruck { IdFireTruck = 1, OperationNumber = "1", SpecialEquipment = true },
                new FireTruck { IdFireTruck = 2, OperationNumber = "11", SpecialEquipment = false },
                new FireTruck { IdFireTruck = 3, OperationNumber = "113", SpecialEquipment = false },
                new FireTruck { IdFireTruck = 4, OperationNumber = "2137", SpecialEquipment = true }
            );

            builder.ToTable("FireTruck");

        }
    }
}
