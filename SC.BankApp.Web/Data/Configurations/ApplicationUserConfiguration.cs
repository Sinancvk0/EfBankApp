using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SC.BankApp.Web.Data.Entities;

namespace SC.BankApp.Web.Data.Configurations
{
    public class ApplicationUserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder.Property(x => x.Name).IsRequired();
            builder.Property(x=>x.Name).HasMaxLength(200);

            builder.Property(x => x.SurName).IsRequired();
            builder.Property(x => x.SurName).HasMaxLength(200);

            builder.HasMany(x => x.Accounts).WithOne(y => y.ApplicationUser).HasForeignKey(x => x.ApplicationUserId);
        }
    }
}
