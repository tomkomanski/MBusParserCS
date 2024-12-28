using System.Text.Json.Serialization;
using System.Text.Json;

namespace MBusParserCS
{
    internal class DoubleConverter : JsonConverter<Double> 
    {
        public override Double Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            return reader.GetDouble();
        }

        public override void Write(Utf8JsonWriter writer, Double value, JsonSerializerOptions options)
        {
            if (value == Math.Truncate(value))
            {
                writer.WriteRawValue(value.ToString("F1", System.Globalization.CultureInfo.InvariantCulture));
            }
            else
            {
                writer.WriteNumberValue(value);
            }
        }
    }
}