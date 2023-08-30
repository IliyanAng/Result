using Ardalis.Result;
using System;
using System.Net;

namespace Ardalist.Result.AzureFunctions;

internal static class ResultStatusExtensions
{
    public static HttpStatusCode ToHttpStatusResult(this ResultStatus statusCode)
    {
        return statusCode switch
        {
            ResultStatus.Ok => HttpStatusCode.OK,
            ResultStatus.Error => HttpStatusCode.UnprocessableEntity,
            ResultStatus.Forbidden => HttpStatusCode.Forbidden,
            ResultStatus.Unauthorized => HttpStatusCode.Unauthorized,
            ResultStatus.Invalid => HttpStatusCode.BadRequest,
            ResultStatus.NotFound => HttpStatusCode.NotFound,
            ResultStatus.Conflict => HttpStatusCode.Conflict,
            _ => throw new NotImplementedException(),
        };
    }
}
