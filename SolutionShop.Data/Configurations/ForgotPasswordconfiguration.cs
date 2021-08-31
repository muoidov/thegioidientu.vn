using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SolutionShop.Data.Entities;

namespace SolutionShop.Data.EF
{
    public class ForgotPasswordconfiguration : IEntityTypeConfiguration<ForgotPassword>
    {
        public void Configure(EntityTypeBuilder<ForgotPassword> builder)
        {
            builder.ToTable("ForgotPasswords");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.UserName).IsRequired(true);
            builder.Property(x => x.Email).IsRequired(true);
            builder.Property(x => x.Description).HasDefaultValue("Quên mật khẩu");
        }
    }
}