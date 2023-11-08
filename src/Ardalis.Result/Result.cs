using System;

namespace Ardalis.Result;

public class Result<T> : IResult
{
    protected Result() { }

    public Result(T value)
    {
        Value = value;
        if (Value != null)
        {
            ValueType = Value.GetType();
        }
    }

    protected internal Result(T value, string successMessage) : this(value)
    {
        SuccessMessage = successMessage;
    }


    public static implicit operator T(Result<T> result) => result.Value;
    public static implicit operator Result<T>(T value) => new Result<T>(value);

    public static implicit operator Result<T>(Result result) => new Result<T>(default(T))
    {
        Status = result.Status,
        ResultError = result.ResultError,
        SuccessMessage = result.SuccessMessage,
        CorrelationId = result.CorrelationId,
    };

    public T Value { get; }

    public Type ValueType { get; private set; }
    public ResultStatus Status { get; set; } = ResultStatus.Ok;
    public bool IsSuccess => Status == ResultStatus.Ok;
    public string SuccessMessage { get; protected set; } = string.Empty;
    public string CorrelationId { get; protected set; } = string.Empty;
    public ResultError ResultError { get; protected set; } = new();

    public void ClearValueType() => ValueType = null;

    /// <summary>
    /// Returns the current value.
    /// </summary>
    /// <returns></returns>
    public object GetValue()
    {
        return this.Value;
    }

    /// <summary>
    /// Converts PagedInfo into a PagedResult<typeparamref name="T"/>
    /// </summary>
    /// <param name="pagedInfo"></param>
    /// <returns></returns>
    public PagedResult<T> ToPagedResult(PagedInfo pagedInfo)
    {
        var pagedResult = new PagedResult<T>(pagedInfo, Value)
        {
            Status = Status,
            SuccessMessage = SuccessMessage,
            CorrelationId = CorrelationId,
            ResultError = ResultError,
        };

        return pagedResult;
    }

    /// <summary>
    /// Represents a successful operation and accepts a values as the result of the operation
    /// </summary>
    /// <param name="value">Sets the Value property</param>
    /// <returns>A Result<typeparamref name="T"/></returns>
    public static Result<T> Success(T value)
    {
        return new Result<T>(value);
    }

    public static Result<T> Success(T value, ResultStatus status)
    {
        return new Result<T>(value) { Status = status, };
    }

    /// <summary>
    /// Represents a successful operation and accepts a values as the result of the operation
    /// Sets the SuccessMessage property to the provided value
    /// </summary>
    /// <param name="value">Sets the Value property</param>
    /// <param name="successMessage">Sets the SuccessMessage property</param>
    /// <returns>A Result<typeparamref name="T"/></returns>
    public static Result<T> Success(T value, string successMessage)
    {
        return new Result<T>(value, successMessage);
    }

    public static Result<T> Success(T value, ResultStatus status, string successMessage)
    {
        return new Result<T>(value, successMessage) { Status = status };
    }

    public static Result<T> Error(params string[] errorMessages)
    {

        return new Result<T>()
        {
            Status = ResultStatus.BadRequest,
            ResultError = new ResultError
            {
                ErrorMessage = string.Join(" ", errorMessages),
            }
        };
    }

    public static Result<T> Error(string errorCode, params string[] errorMessages)
    {
        return new Result<T>()
        {
            Status = ResultStatus.BadRequest,
            ResultError = new ResultError
            {
                ErrorMessage = string.Join(" ", errorMessages),
                ErrorCode = errorCode,
            }
        };
    }

    public static Result<T> Error(string errorCode, ValidationSeverity validationSeverity, params string[] errorMessages)
    {
        return new Result<T>()
        {
            Status = ResultStatus.BadRequest,
            ResultError = new ResultError
            {
                ErrorCode = errorCode,
                Severity = validationSeverity,
                ErrorMessage = string.Join(" ", errorMessages),
            }
        };
    }

    public static Result<T> Error(string errorCode, ResultStatus status, params string[] errorMessages)
    {
        return new Result<T>()
        {
            Status = status,
            ResultError = new ResultError
            {
                ErrorCode = errorCode,
                ErrorMessage = string.Join(" ", errorMessages),
            }
        };
    }

    public static Result<T> Error(string errorCode, ResultStatus status, ValidationSeverity severity, params string[] errorMessages)
    {
        return new Result<T>()
        {
            Status = status,
            ResultError = new ResultError
            {
                ErrorCode = errorCode,
                Severity = severity,
                ErrorMessage = string.Join(" ", errorMessages),
            }
        };
    }

    public static Result<T> Error(ValidationSeverity severity, params string[] errorMessages)
    {
        return new Result<T>()
        {
            ResultError = new ResultError
            {
                ErrorMessage = string.Join(" ", errorMessages),
                Severity = severity,
            }
        };
    }

    public static Result<T> Error(ResultStatus status, params string[] errorMessages)
    {
        return new Result<T>()
        {
            Status = status,
            ResultError = new ResultError
            {
                ErrorMessage = string.Join(" ", errorMessages),
            }
        };
    }

    public static Result<T> Error(ResultStatus status, ValidationSeverity severity, params string[] errorMessages)
    {
        return new Result<T>()
        {
            Status = status,
            ResultError = new ResultError
            {
                Severity = severity,
                ErrorMessage = string.Join(" ", errorMessages),
            }
        };
    }

    public static Result<T> Error(ResultError error)
    {
        return new Result<T>()
        {
            Status = ResultStatus.BadRequest,
            ResultError = error
        };
    }

    public static Result<T> Error(ResultStatus status, ResultError error)
    {
        return new Result<T>()
        {
            Status = status,
            ResultError = error
        };
    }
}

