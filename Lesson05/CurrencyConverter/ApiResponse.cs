using System.Text.Json.Serialization;

namespace CurrencyConverter;

public class ApiResponse
{
    [JsonPropertyName("meta")] public required Meta Meta { get; set; }

    [JsonPropertyName("data")] public required Dictionary<string, CurrencyData> Data { get; set; }
}

public class Meta
{
    [JsonPropertyName("last_updated_at")] public required string LastUpdatedAt { get; set; }
}

public class CurrencyData
{
    [JsonPropertyName("code")] public required string Code { get; set; }

    [JsonPropertyName("value")] public required double Value { get; set; }
}