/*using System.Text.Json;
using System.Text.Json.Serialization;
using IncrementedIdentifierTest.Infrastructure.Exceptions;
using Sqids;
using Vogen;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace IncrementedIdentifierTest.Common.ValueObjects;

/// <summary>
/// Struct <c>Identifier</c> serves as the primary identifier for a resource.
/// Internally, an integer is used for quicker database indexing. However,
/// displaying an auto-incrementing identifier publicly can lead to indexing attacks.
/// To mitigate this risk, this special identifier value object employs Sqid to encode
/// the integer ID into a YouTube-like ID.
/// </summary>
[ValueObject<int>(conversions: Conversions.TypeConverter | Conversions.EfCoreValueConverter)]
[JsonConverter(typeof(JsonConverter))]
public sealed partial class Identifier
{

    private static readonly SqidsEncoder<int> SqidEncoder = new(new SqidsOptions
    {
        MinLength = 8,
        Alphabet = "2mA659soCatID8GWugdrOPBMRyiqnNbU4FZ7K1LSeQhkv0pEHVlf3jXJYzxTwc",
    });

    public static Identifier From(string rawSqid)
    {
        if (string.IsNullOrEmpty(rawSqid)) throw Error.Validation("Identifier.CannotBeNullOrEmpty", "The given value is either null or empty, which is invalid as identifier.");
        return From(SqidEncoder.Decode(rawSqid)[0]);
    }

    private static Validation Validate(int input)
    {
        if (input > 0) return Validation.Ok;;

        throw Error.Validation("Identifier.InvalidValue", "This is not a valid identifier value");
        return Validation.Invalid();
    }


    public static bool TryParse(string? s, IFormatProvider? provider, out Identifier result)
    {
        try
        {
            result = From(s);
            return true;
        }
        catch
        {
            result = Identifier.From(0);
            return false;
        }
    }

    public static bool TryParse(string? value, out Identifier result) => TryParse(value, provider: null, out result);

    public static Identifier Parse(string value)
    {
        if (!TryParse(value, out Identifier result))
            throw Error.Failure("Identifier.Invalid", "The given identifier was unable to be parsed.");
        return result;
    }

    public override string ToString() => SqidEncoder.Encode(_value, 0);

    public sealed class JsonConverter : JsonConverter<Identifier>
    {
        public override Identifier Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var str = reader.GetString()!;
            ArgumentException.ThrowIfNullOrEmpty(str);

            return __Deserialize(From(str).Value);
        }

        public override void Write(Utf8JsonWriter writer, Identifier identifier, JsonSerializerOptions options)
        {
            JsonSerializer.Serialize(writer, identifier.ToString(), options);
        }

        public override Identifier ReadAsPropertyName(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var str = reader.GetString()!;

            ArgumentException.ThrowIfNullOrEmpty(str);


            return __Deserialize(From(str).Value);
        }

        public override void WriteAsPropertyName(Utf8JsonWriter writer, Identifier identifier, JsonSerializerOptions options)
        {
            writer.WritePropertyName(identifier.ToString());
        }
    }
}*/

// Simpler test example
using IncrementedIdentifierTest.Infrastructure.Exceptions;
using Vogen;

namespace IncrementedIdentifierTest.Common.ValueObjects;

[ValueObject<int>]
public sealed partial class Identifier
{
    private static Validation Validate(int input)
    {
        if (input > 0) return Validation.Ok;

        
        throw Error.Validation("Identifier.InvalidValue", "This is not a valid identifier value");
    }
}