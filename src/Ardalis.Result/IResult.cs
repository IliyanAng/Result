using System;

namespace Ardalis.Result
{
    public interface IResult
    {
        ResultStatus Status { get; }
        ResultError ResultError { get; }
        Type ValueType { get; }
        Object GetValue();
    }
}
