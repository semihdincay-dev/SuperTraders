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
      try
      {
        TradingTransaction tradingTransaction = new TradingTransaction();
        UserShare userShare = null;
        tradingTransaction.Name = data.Name;
        tradingTransaction.Quantity = data.Quantity;
        tradingTransaction.TransactionType = ETradingTransactionType.Buy;
        tradingTransaction.ShareId = data.ShareId;
        tradingTransaction.UserId = data.UserId;
        tradingTransaction.CreatedBy = data.UserId;
        tradingTransaction.CreatedOn = DateTime.Now;

        var share = _unitOfWork.GetRepository<Share>().Get(s => s.Id == data.ShareId);

        if (share == null) //Alınmak istenen hissenin, sistemde kayıtlı olup olmadığının kontrolü
        {
          tradingTransaction.Result = ETradingTransactionResult.Failed;
          tradingTransaction.ResultMessage = "Alınmak istenen hisse, sistemde kayıtlı olmalıdır.";
        }
        else
        {
          var lastPrice = share.Price;
          tradingTransaction.Price = lastPrice;
          userShare = _unitOfWork.GetRepository<UserShare>().Get(s => s.ShareId == data.ShareId);
          if (userShare == null)//Alış yapılacak hisse, portföyde yoksa yeni kayıt oluşturulmalı
          {
            userShare = new UserShare();
            userShare.Name = data.Name;
            userShare.Price = lastPrice;
            userShare.Quantity = data.Quantity;
            userShare.CreatedBy = data.UserId;
            userShare.CreatedOn = DateTime.Now;
            tradingTransaction.ResultMessage = "Seçilen hisse başarıyla alındı ve portföye eklendi.";
            _unitOfWork.GetRepository<UserShare>().Add(userShare);
          }
          else //Alış yapılacak hisse, portföyde varsa, miktar güncellenmeli
          {
            userShare.Quantity = userShare.Quantity + data.Quantity;
            userShare.ModifiedBy = data.UserId;
            userShare.ModifiedOn = DateTime.Now;
            tradingTransaction.ResultMessage = "Seçilen hisse başarıyla alındı ve portföydeki miktarı güncellendi.";
            _unitOfWork.GetRepository<UserShare>().Update(userShare);
          }
          userShare.UserId = data.UserId;
          userShare.ShareId = data.ShareId;
          tradingTransaction.Result = ETradingTransactionResult.Success;
        }
        _unitOfWork.GetRepository<TradingTransaction>().Add(tradingTransaction);
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
      catch (Exception ex)
      {
        return new DataResult<TradingTransactionDTO>(ResultStatus.Error, ex.Message, null, ex);
      }
    }

    public IDataResult<TradingTransactionDTO> Sell(TradeDTO data)
    {
      try
      {
        TradingTransaction tradingTransaction = new TradingTransaction();
        UserShare userShare = null;
        tradingTransaction.Name = data.Name;
        tradingTransaction.Quantity = data.Quantity;
        tradingTransaction.TransactionType = ETradingTransactionType.Sell;
        tradingTransaction.ShareId = data.ShareId;
        tradingTransaction.UserId = data.UserId;
        tradingTransaction.CreatedBy = data.UserId;
        tradingTransaction.CreatedOn = DateTime.Now;

        var share = _unitOfWork.GetRepository<Share>().Get(s => s.Id == data.ShareId);
        if (share == null) //Satılmak istenen hissenin, sistemde kayıtlı olup olmadığının kontrolü
        {
          tradingTransaction.Result = ETradingTransactionResult.Failed;
          tradingTransaction.ResultMessage = "Satılmak istenen hisse, sistemde kayıtlı olmalıdır.";
        }
        else
        {
          var lastPrice = share.Price;
          tradingTransaction.Price = lastPrice;
          userShare = _unitOfWork.GetRepository<UserShare>().Get(s => s.ShareId == data.ShareId);
          if (userShare == null) //Satılmak istenen hissenin, portföyde olup olmadığının kontrolü
          {
            tradingTransaction.Result = ETradingTransactionResult.Failed;
            tradingTransaction.ResultMessage = "Satılmak istenen hisse, portföyde kayıtlı olmalıdır.";
          }
          else if (userShare != null && userShare.Quantity < data.Quantity) //Satılmak istenen hissenin miktar kontrolü
          {
            tradingTransaction.Result = ETradingTransactionResult.Failed;
            tradingTransaction.ResultMessage = "Satılmak istenen hisse miktarı, portföydeki hisse miktarından fazla olamaz.";
          }
          else
          {
            userShare.Quantity = userShare.Quantity - data.Quantity;
            userShare.ModifiedBy = data.UserId;
            userShare.ModifiedOn = DateTime.Now;
            userShare.UserId = data.UserId;
            userShare.ShareId = data.ShareId;
            tradingTransaction.Result = ETradingTransactionResult.Success;
            tradingTransaction.ResultMessage = "Seçilen hisse başarıyla satıldı ve portföydeki miktarı güncellendi.";
            _unitOfWork.GetRepository<UserShare>().Update(userShare);
          }
          _unitOfWork.GetRepository<TradingTransaction>().Add(tradingTransaction);
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
      catch (Exception ex)
      {
        return new DataResult<TradingTransactionDTO>(ResultStatus.Error, ex.Message, null, ex);
      }
    }
  }
}
