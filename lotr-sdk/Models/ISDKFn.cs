using lotr_sdk.Services;

namespace lotr_sdk.Models;

public interface ISDKFn<T>
{
    Task<T> Search(RequestParams @params);
    ISDKFn<T> AddMethod(string name, Func<RequestParams, string?, Task<T>> method);
    Task<T> InvokeMethod(string methodName, RequestParams @params, string? extraParam = null);
}