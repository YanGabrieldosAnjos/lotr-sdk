using System.Text;
using System.Text.Json;
using lotr_sdk.Models;

namespace lotr_sdk.Services;

public class HttpRequest
{
  private readonly string _apiKey;
  private readonly string _apiUrl;

    public HttpRequest(string apiUrl, string apiKey)
    {
        _apiUrl = apiUrl;
        _apiKey = apiKey;
    }

    private string BuildRequest(RequestParams reqParams)
    {
        var queryBuilder = new StringBuilder();

        if (reqParams.Filters != null || reqParams.Pagination != null)
        {
            queryBuilder.Append("?");
        }

        if (reqParams.Filters != null)
        {
            for (int i = 0; i < reqParams.Filters.Count; i++)
            {
                var filter = reqParams.Filters[i];
                queryBuilder.Append(filter.Key)
                            .Append(filter.Matching)
                            .Append(filter.Value is IEnumerable<string> values
                                ? string.Join(",", values)
                                : filter.Value);

                if (i < reqParams.Filters.Count - 1)
                {
                    queryBuilder.Append("&");
                }
            }
        }

        if (reqParams.Pagination != null)
        {
            if (reqParams.Filters != null)
            {
                queryBuilder.Append("&");
            }

            var paginationProps = reqParams.Pagination.GetType().GetProperties();
            for (int i = 0; i < paginationProps.Length; i++)
            {
                var prop = paginationProps[i];
                var key = prop.Name;
                var value = prop.GetValue(reqParams.Pagination);
                queryBuilder.Append(key)
                            .Append("=")
                            .Append(value);

                if (i < paginationProps.Length - 1)
                {
                    queryBuilder.Append("&");
                }
            }
        }

        return queryBuilder.ToString();
    }

    public async Task<T?> RequestAsync<T>(string endpoint, string method, RequestParams reqParams)
    {
        var query = BuildRequest(reqParams);
        using var httpClient = new HttpClient();
        var requestMessage = new HttpRequestMessage(new HttpMethod(method), $"{_apiUrl}/{endpoint}{query}");
        requestMessage.Headers.Add("Authorization", $"Bearer {_apiKey}");

        var response = await httpClient.SendAsync(requestMessage);

        response.EnsureSuccessStatusCode();

        var content = await response.Content.ReadAsStringAsync();
        return JsonSerializer.Deserialize<T>(content);
    }   
}