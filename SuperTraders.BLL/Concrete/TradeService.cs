using AutoMapper;
using SuperTraders.BLL.Abstract;
using SuperTraders.Core.Data.UnitOfWork;
using SuperTraders.Shared.DTO;
using SuperTraders.Shared.Util.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperTraders.BLL.Concrete
{
  public class TradeService : ITradeService
  {
    private readonly IUnitofWork _unitOfWork;
    private readonly IMapper _mapper;

    public TradeService(IUnitofWork unitOfWork, IMapper mapper)
    {
      _unitOfWork = unitOfWork;
      _mapper = mapper;
    }
    
    public IDataResult<TradingTransactionDTO> Buy(TradeDTO data)
    {
      /*
       1-İlgili hissenin güncel fiyatı çekilecek ve bu fiyattan alınacak.
       2-Alınmak istenen hisse, sistemde kayıtlı olmalıdır.
       3-UserShare tablosuna ilgili hisse ile alakalı güncelleme yap. İlgili hisse daha önce alınmışsa miktarı artır.
       */
      throw new NotImplementedException();
    }

    public IDataResult<TradingTransactionDTO> Sell(TradeDTO data)
    {
      /*
       1-Satışı yapılacak hisse, portföyde kayıtlı olacak
       2-İlgili hissenin güncel fiyatı çekilecek ve bu fiyattan satılacak.
       3-UserShare tablosuna ilgili hisse ile alakalı güncelleme yap. İlgili hissenin miktarını satış kadar azalt.
       4-Miktar yeterli olacak
       */
      throw new NotImplementedException();
    }
  }
}
