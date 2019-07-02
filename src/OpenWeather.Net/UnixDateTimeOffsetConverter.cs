using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace OpenWeather
{
    internal class UnixDateTimeOffsetConverter : JsonConverter<DateTimeOffset>
    {
        public override DateTimeOffset Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            return new DateTimeOffset(1970, 1, 1, 0, 0, 0, new TimeSpan()).AddSeconds(reader.GetDouble());
        }

        public override void Write(Utf8JsonWriter writer, DateTimeOffset value, JsonSerializerOptions options)
        {
            var seconds = (value - new DateTimeOffset(1970, 1, 1, 0, 0, 0, new TimeSpan())).TotalSeconds;
            writer.WriteNumberValue(seconds);
        }
    }
}
