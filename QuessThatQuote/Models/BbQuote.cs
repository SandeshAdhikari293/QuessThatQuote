namespace QuessThatQuote.Models
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using System.Collections.Generic;

    using System.Globalization;

    public partial class BbQuote
    {
        [JsonProperty("quote")]
        public string Quote { get; set; }

        [JsonProperty("author")]
        public string Author { get; set; }
    }

    public partial class BbQuote
    {
        public static List<BbQuote> FromJson(string json) => JsonConvert.DeserializeObject<List<BbQuote>>(json, Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this List<BbQuote> self) => JsonConvert.SerializeObject(self, Converter.Settings);
    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }
}
