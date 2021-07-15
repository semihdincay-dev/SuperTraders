using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperTraders.Model.Mapping
{
  public class ShareMap : IEntityTypeConfiguration<Share>
  {
    public void Configure(EntityTypeBuilder<Share> builder)
    {
      builder.HasKey(z => z.Id);
      builder.Property(z => z.Id).ValueGeneratedOnAdd();
      builder.Property(z => z.Name).IsRequired();
      builder.Property(z => z.Symbol).HasMaxLength(3).IsRequired();
      builder.Property(z => z.Price).HasPrecision(2).IsRequired();
      builder.Property(z => z.Quantity).IsRequired();
      builder.Property(z => z.Time).IsRequired();

      builder.HasMany<UserShare>(z => z.UserShares).WithOne(p => p.Share);
    }
  }
}
