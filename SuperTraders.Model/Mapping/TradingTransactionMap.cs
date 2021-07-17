using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperTraders.Model.Mapping
{
  public class TradingTransactionMap : IEntityTypeConfiguration<TradingTransaction>
  {
    public void Configure(EntityTypeBuilder<TradingTransaction> builder)
    {
      builder.HasKey(z => z.Id);
      builder.Property(z => z.Id).ValueGeneratedOnAdd();
      builder.Property(z => z.Id).IsRequired();
      builder.Property(z => z.Name).IsRequired();
      builder.Property(z => z.Price).HasPrecision(18, 2).IsRequired();
      builder.Property(z => z.Quantity).IsRequired();
      builder.Property(z => z.Result).IsRequired();
      builder.Property(z => z.ResultMessage).HasMaxLength(255).IsRequired();
      builder.Property(z => z.TransactionType).IsRequired();
      builder.Property(z => z.UserId).IsRequired();
      builder.Property(z => z.ShareId).IsRequired();

      builder.HasOne<User>(z => z.User).WithMany(z => z.TradingTransactions);
      builder.HasOne<Share>(z => z.Share).WithMany(z => z.TradingTransactions);
    }
  }
}
