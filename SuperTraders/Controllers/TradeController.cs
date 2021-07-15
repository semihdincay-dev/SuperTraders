using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SuperTraders.BLL.Abstract;
using SuperTraders.Shared.DTO;
using SuperTraders.Shared.Util.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuperTraders.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class TradeController : ControllerBase
  {
    private ITradeService _tradeService;
    private readonly ILogger<TradeController> _logger;

    public TradeController(ILogger<TradeController> logger, ITradeService tradeService)
    {
      _logger = logger;
      _tradeService = tradeService;
    }

    [HttpPost]
    public IDataResult<TradingTransactionDTO> Buy(TradeDTO data)
    {
      return _tradeService.Buy(data); 
    }

    [HttpPost]
    public IDataResult<TradingTransactionDTO> Sell(TradeDTO data) 
    {
      return _tradeService.Sell(data);
    }
  }
}
