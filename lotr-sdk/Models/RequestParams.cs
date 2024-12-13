namespace lotr_sdk.Models;

public class RequestParams
{
    public List<Filtering>? Filters { get; set; }

    public Pagination? Pagination { get; set; }
}