using SuperTraders.Shared.DTO;
using SuperTraders.Shared.Util.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperTraders.BLL.Abstract
{
  public interface ITradeService
  {
    IDataResult<TradingTransactionDTO> Buy(TradeDTO data);
    IDataResult<TradingTransactionDTO> Sell(TradeDTO data);
  }
}
