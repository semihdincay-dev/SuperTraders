using SuperTraders.Shared.Util.ComplexTypes;
using SuperTraders.Shared.Util.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amatis.Shared.Utils
{

  public class DataResult<T> : IDataResult<T>
  {
    public DataResult(ResultStatus resultStatus, T data)
    {
      ResultStatus = resultStatus;
      Data = data;
    }
    public DataResult(ResultStatus resultStatus, string message, T data)
    {
      ResultStatus = resultStatus;
      Data = data;
      Message = message;
    }
    public DataResult(ResultStatus resultStatus, string message, T data, Exception excepction)
    {
      ResultStatus = resultStatus;
      Data = data;
      Message = message;
      Exception = excepction;
    }
    public T Data { get; }

    public ResultStatus ResultStatus { get; }

    public string Message { get; }

    public Exception Exception { get; }

    public ResultStatus Result { get; }

    ResultStatus IResult.Result { get; }
  }
}
