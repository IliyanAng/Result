using Ardalis.Result;
using Microsoft.Azure.Functions.Worker.Http;
using System.Threading.Tasks;

namespace Ardalist.Result.AzureFunctions;

public static partial class ResultExtensions
{

    public static HttpResponseData ToHttpRequestData<T>(this HttpRequestData req, Result<T> result)
    {
        return null;
    }

    public static HttpResponseData ToHttpRequestData(this HttpRequestData req, Ardalis.Result.Result result)
    {
        return null;
    }

    public static HttpResponseData ToHttpRequestData<T>(this Result<T> result, HttpRequestData req)
    {
        return null;
    }

    public static HttpResponseData ToHttpRequestData(this Ardalis.Result.Result result, HttpRequestData req)
    {
        return null;
    }

    internal static async Task<HttpResponseData> ToHttpRequestDataAsync(this HttpRequestData req, IResult result)
    {
        var response = req.CreateResponse(result.Status.ToHttpStatusResult());
        if(result.Errors is not null)
        {
            await response.WriteAsJsonAsync(result.Errors);
        }
        else if(result.ValidationErrors is not null)
        {
            await response.WriteAsJsonAsync(result.ValidationErrors);
        }
        else
        {
            await response.WriteAsJsonAsync(result.GetValue());
        }
        return response;
    }
}