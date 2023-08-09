using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SC.BankApp.Web.Data.Entities;

namespace SC.BankApp.Web.Data.Configurations
{
    public class AccountConfiguration : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.Property(x => x.AccountNumber).IsRequired();
            builder.Property(x => x.Balance).IsRequired();
            builder.Property(x => x.Balance).HasColumnType("decimal(18,4)");
        }
    }
}
