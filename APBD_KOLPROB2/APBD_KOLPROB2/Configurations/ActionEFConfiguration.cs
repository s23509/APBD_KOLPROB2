using APBD_KOLPROB2.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace APBD_KOLPROB2.Configurations
{
    public class ActionEFConfiguration : IEntityTypeConfiguration<Action>
    {
        public void Configure(EntityTypeBuilder<Action> builder)
        {
            builder.HasKey(e => e.IdAction).HasName("Action_pk");
            builder.Property(e => e.IdAction).UseIdentityColumn();
            builder.Property(e => e.StartTime).IsRequired();
            //EndTime nie jest required
            builder.Property(e => e.NeedSpecialEquipment).IsRequired();

            //Adding Sample Data
            builder.HasData(
                new Action { IdAction = 1, StartTime = System.DateTime.Today.AddDays(-5), EndTime = System.DateTime.Today.AddDays(-4), NeedSpecialEquipment = false },
                new Action { IdAction = 2, StartTime = System.DateTime.Today.AddDays(-12), EndTime = System.DateTime.Today.AddDays(-10), NeedSpecialEquipment = true },
                new Action { IdAction = 3, StartTime = System.DateTime.Today, NeedSpecialEquipment = true}
            );

            builder.ToTable("Action");
        }
    }
}
