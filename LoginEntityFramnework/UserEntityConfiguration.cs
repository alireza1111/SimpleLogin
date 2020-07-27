using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LoginEntityFramework
{
    public class UserEntityConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("users");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .HasColumnName("user_id");

            builder.Property(e => e.Name)
                .HasColumnName("name")
                .HasColumnType("VARCHAR(100)");

            builder.Property(e => e.Password)
                .HasColumnName("password")
                .HasColumnType("VARCHAR(100)");

            builder.Property(e => e.Age)
                .HasColumnName("age")
                .HasColumnType("INTEGER");

        }
    }
}