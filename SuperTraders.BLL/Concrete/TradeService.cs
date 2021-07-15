using Amatis.Shared.Utils;
using AutoMapper;
using SuperTraders.BLL.Abstract;
using SuperTraders.Core.Data.UnitOfWork;
using SuperTraders.Model;
using SuperTraders.Shared.DTO;
using SuperTraders.Shared.Enum;
using SuperTraders.Shared.Util.ComplexTypes;
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
      TradingTransaction tradingTransaction = new TradingTransaction();
      tradingTransaction.Name = data.name;
      tradingTransaction.Quantity = data.quantity;
      tradingTransaction.TransactionType = ETradingTransactionType.Buy;

      var share = _unitOfWork.GetRepository<Share>().Get(s => s.Id == data.share_id);

      if (share == null) //Alınmak istenen hissenin, sistemde kayıtlı olup olmadığının kontrolü
      {
        tradingTransaction.Result = ETradingTransactionResult.Failed;
        tradingTransaction.ResultMessage = "Alınmak istenen hisse, sistemde kayıtlı olmalıdır.";
      }
      else
      {
        var lastPrice = share.lastprice;
        tradingTransaction.Price = lastPrice;
        var userShare = _unitOfWork.GetRepository<UserShare>().Get(s => s.share_id == data.share_id);
        if (userShare == null)//Alış yapılacak hisse, portföyde yoksa yeni kayıt oluşturulmalı
        {
          userShare = new UserShare();
          userShare.name = data.name;
          userShare.price = lastPrice;
          userShare.quantity = data.quantity;
          userShare.created_by = data.user_id;
          userShare.created_on = DateTime.Now;
          tradingTransaction.ResultMessage = "Seçilen hisse başarıyla alındı ve portföye eklendi.";
        }
        else //Alış yapılacak hisse, portföyde varsa, miktar güncellenmeli
        {
          userShare.quantity = userShare.quantity + data.quantity;
          userShare.modified_by = data.user_id;
          userShare.modified_on = DateTime.Now;
          tradingTransaction.ResultMessage = "Seçilen hisse başarıyla alındı ve portföydeki miktarı güncellendi.";
        }
        userShare.user_id = data.user_id;
        userShare.share_id = data.share_id;
        tradingTransaction.Result = ETradingTransactionResult.Success;
      }
      _unitOfWork.SaveChanges();

      var tradingTransactionDto = _mapper.Map<TradingTransactionDTO>(tradingTransaction);
      if (tradingTransactionDto.Result == ETradingTransactionResult.Success)
      {
        return new DataResult<TradingTransactionDTO>(ResultStatus.Success, tradingTransactionDto);
      }
      else
      {
        return new DataResult<TradingTransactionDTO>(ResultStatus.Error, tradingTransactionDto);
      }
    }

    public IDataResult<TradingTransactionDTO> Sell(TradeDTO data)
    {
      /*
       1-Satışı yapılacak hisse, portföyde kayıtlı olacak
       2-İlgili hissenin güncel fiyatı çekilecek ve bu fiyattan satılacak.
       3-UserShare tablosuna ilgili hisse ile alakalı güncelleme yap. İlgili hissenin miktarını satış kadar azalt.
       4-Miktar yeterli olacak
       */
      TradingTransaction tradingTransaction = new TradingTransaction();
      tradingTransaction.Name = data.name;
      tradingTransaction.Quantity = data.quantity;
      tradingTransaction.TransactionType = ETradingTransactionType.Sell;

      var share = _unitOfWork.GetRepository<Share>().Get(s => s.Id == data.share_id);
      if (share == null) //Satılmak istenen hissenin, sistemde kayıtlı olup olmadığının kontrolü
      {
        tradingTransaction.Result = ETradingTransactionResult.Failed;
        tradingTransaction.ResultMessage = "Satılmak istenen hisse, sistemde kayıtlı olmalıdır.";
      }
      else
      {
        var lastPrice = share.lastprice;
        tradingTransaction.Price = lastPrice;
        var userShare = _unitOfWork.GetRepository<UserShare>().Get(s => s.share_id == data.share_id);
        if (userShare == null) //Satılmak istenen hissenin, portföyde olup olmadığının kontrolü
        {
          tradingTransaction.Result = ETradingTransactionResult.Failed;
          tradingTransaction.ResultMessage = "Satılmak istenen hisse, portföyde kayıtlı olmalıdır.";
        }
        else if (userShare != null && userShare.quantity < data.quantity) //Satılmak istenen hissenin miktar kontrolü
        {
          tradingTransaction.Result = ETradingTransactionResult.Failed;
          tradingTransaction.ResultMessage = "Satılmak istenen hisse miktarı, portföydeki hisse miktarından fazla olamaz.";
        }
        else
        {
          userShare.quantity = userShare.quantity - data.quantity;
          userShare.modified_by = data.user_id;
          userShare.modified_on = DateTime.Now;
          userShare.user_id = data.user_id;
          userShare.share_id = data.share_id;
          tradingTransaction.Result = ETradingTransactionResult.Success;
          tradingTransaction.ResultMessage = "Seçilen hisse başarıyla satıldı ve portföydeki miktarı güncellendi.";
        }
      }

      _unitOfWork.SaveChanges();

      var tradingTransactionDto = _mapper.Map<TradingTransactionDTO>(tradingTransaction);
      if (tradingTransactionDto.Result == ETradingTransactionResult.Success)
      {
        return new DataResult<TradingTransactionDTO>(ResultStatus.Success, tradingTransactionDto);
      }
      else
      {
        return new DataResult<TradingTransactionDTO>(ResultStatus.Error, tradingTransactionDto);
      }
    }
  }
}
