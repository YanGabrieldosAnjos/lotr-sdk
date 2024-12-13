namespace lotr_sdk.Models;

public enum MatchType
{
    Equals,
    NotEquals,
    LessThan,
    GreaterThan,
    LessThanOrEqual,
    GreaterThanOrEqual
}

public class Filtering
{
    public string Key { get; set; }
    public object Value { get; set; }
    public MatchType Matching { get; set; }
}