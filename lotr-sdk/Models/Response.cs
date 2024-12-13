namespace lotr_sdk.Models;

public class Response
{
    public List<BaseResponse> docs { get; set; } // Shared base type
    public int total { get; set; }
    public int limit { get; set; }
    public int offset { get; set; }
    public int page { get; set; }
    public int pages { get; set; }
}