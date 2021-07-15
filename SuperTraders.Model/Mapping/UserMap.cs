using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperTraders.Model.Mapping
{
  public class UserMap : IEntityTypeConfiguration<User>
  {
    public void Configure(EntityTypeBuilder<User> builder)
    {
      builder.HasKey(z => z.Id);
      builder.Property(z => z.Id).ValueGeneratedOnAdd();
      builder.Property(z => z.Name).IsRequired();
      builder.Property(z => z.Surname).IsRequired();
      builder.Property(z => z.Username).IsRequired();
      builder.Property(z => z.Email).IsRequired();

      builder.HasMany<UserShare>(z => z.UserShares).WithOne(p => p.User);
    }
  }
}
