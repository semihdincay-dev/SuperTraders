using SuperTraders.Shared.DTO;
using SuperTraders.Shared.Util.Result;

namespace SuperTraders.BLL.Abstract
{
  public interface ITradeService
  {
    IDataResult<TradingTransactionDTO> Buy(TradeDTO data);
    IDataResult<TradingTransactionDTO> Sell(TradeDTO data);
  }
}
