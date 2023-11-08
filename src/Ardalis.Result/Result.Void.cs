namespace Ardalis.Result
{
    public class Result : Result<Result>
    {
        public Result() : base() { }

        /// <summary>
        /// Represents a successful operation without return type
        /// </summary>
        /// <returns>A Result</returns>
        public static Result Success()
        {
            return new Result();
        }

        public static Result Success(ResultStatus status)
        {
            return new Result() { Status = status };
        }

        /// <summary>
        /// Represents a successful operation and accepts a values as the result of the operation
        /// </summary>
        /// <param name="value">Sets the Value property</param>
        /// <returns>A Result<typeparamref name="T"/></returns>
        public static Result<T> Success<T>(T value)
        {
            return new Result<T>(value);
        }

        public static Result<T> Success<T>(T value, ResultStatus status)
        {
            return new Result<T>(value) { Status = status };
        }

        public static Result<T> Success<T>(T value, ResultStatus status, string successMessage)
        {
            return new Result<T>(value, successMessage) { Status = status };
        }

        /// <summary>
        /// Represents a successful operation without return type
        /// </summary>
        /// <param name="successMessage">Sets the SuccessMessage property</param>
        /// <returns>A Result></returns>
        public static Result SuccessWithMessage(string successMessage)
        {
            return new Result() { SuccessMessage = successMessage };
        }

        public static Result SuccessWithMessage(string successMessage, ResultStatus status)
        {
            return new Result() { SuccessMessage = successMessage, Status = status };
        }


        /// <summary>
        /// Represents a successful operation and accepts a values as the result of the operation
        /// Sets the SuccessMessage property to the provided value
        /// </summary>
        /// <param name="value">Sets the Value property</param>
        /// <param name="successMessage">Sets the SuccessMessage property</param>
        /// <returns>A Result<typeparamref name="T"/></returns>
        public static Result<T> Success<T>(T value, string successMessage)
        {
            return new Result<T>(value, successMessage);
        }



        public static Result Error(params string[] errorMessages)
        {

            return new Result()
            {
                Status = ResultStatus.BadRequest,
                ResultError = new ResultError
                {
                    ErrorMessage = string.Join(" ", errorMessages),
                }
            };
        }

        public static Result Error(string errorCode, params string[] errorMessages)
        {
            return new Result()
            {
                Status = ResultStatus.BadRequest,
                ResultError = new ResultError
                {
                    ErrorMessage = string.Join(" ", errorMessages),
                    ErrorCode = errorCode,
                }
            };
        }

        public static Result Error(string errorCode, ValidationSeverity validationSeverity, params string[] errorMessages)
        {
            return new Result()
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

        public static Result Error(string errorCode, ResultStatus status, params string[] errorMessages)
        {
            return new Result()
            {
                Status = status,
                ResultError = new ResultError
                {
                    ErrorCode = errorCode,
                    ErrorMessage = string.Join(" ", errorMessages),
                }
            };
        }

        public static Result Error(string errorCode, ResultStatus status, ValidationSeverity severity, params string[] errorMessages)
        {
            return new Result()
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

        public static Result Error(ValidationSeverity severity, params string[] errorMessages)
        {
            return new Result()
            {
                ResultError = new ResultError
                {
                    ErrorMessage = string.Join(" ", errorMessages),
                    Severity = severity,
                }
            };
        }

        public static Result Error(ResultStatus status, params string[] errorMessages)
        {
            return new Result()
            {
                Status = status,
                ResultError = new ResultError
                {
                    ErrorMessage = string.Join(" ", errorMessages),
                }
            };
        }

        public static Result Error(ResultStatus status, ValidationSeverity severity, params string[] errorMessages)
        {
            return new Result()
            {
                Status = status,
                ResultError = new ResultError
                {
                    Severity = severity,
                    ErrorMessage = string.Join(" ", errorMessages),
                }
            };
        }

        public static Result Error(ResultError error)
        {
            return new Result()
            {
                Status = ResultStatus.BadRequest,
                ResultError = error
            };
        }

        public static Result Error(ResultStatus status, ResultError error)
        {
            return new Result()
            {
                Status = status,
                ResultError = error
            };
        }
    }
}