namespace lotr_sdk.Models;

public class Quote: BaseResponse
{
    public string dialog {get; set; } 
    public string movie {get; set; } 
    public string character {get; set; } 
    public string id  {get; set; }
}