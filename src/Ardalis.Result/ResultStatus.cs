namespace Ardalis.Result
{
    public enum ResultStatus
    {
        Continue = 100,
        Processing = 102,
        Ok = 200,
        Created = 201,
        Accepted = 202,
        NoContent = 204,
        PartialContent = 206,
        AlreadyReported = 208,
        NotModified = 304,
        BadRequest = 400,
        Unauthorized = 401,
        Forbidden = 403,
        NotFound = 404,
        NotAcceptable = 406,
        RequestTimeout = 408,
        Conflict = 409,
        Gone = 410,
        ContentTooLarge = 413,
        UnsupportedMediaType = 415,
        RangeNotSatisfiable = 416,
        AuthenticationTimeout = 419,
        UnprocessableEntity = 422,
        Locked = 423,
        FailedDependency = 424,
        UpgradeRequired = 426,
        PreconditionRequired = 428,
        TooManyRequests = 429,
        InternalServerError = 500,
        NotImplemented = 501,
        ServiceUnavailable = 503,
        InsufficientStorage = 507,

        //Ok,
        //Error,
        //Forbidden,
        //Unauthorized,
        //Invalid,
        //NotFound,
        //Conflict,
        //CriticalError,
        //Unavailable
    }
}

