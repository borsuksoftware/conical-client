using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text;

namespace BorsukSoftware.Conical.Client.REST
{
	/// <summary>
	/// Helper converter to ensure that the byte array can be serialized as a byte array rather than as a string which is the default 
	/// behaviour in the new version of .net core
	/// </summary>
	internal class ByteArrayConverter : JsonConverter<byte[]>
	{
		public override bool CanConvert(Type typeToConvert)
		{
			if (typeToConvert != typeof(byte[]))
				return false;

			return true;
		}

		public override byte[] Read(ref Utf8JsonReader reader,
			Type typeToConvert,
			JsonSerializerOptions options)
		{

			short[] sByteArray = JsonSerializer.Deserialize<short[]>(ref reader);
			byte[] value = new byte[sByteArray.Length];
			for (int i = 0; i < sByteArray.Length; i++)
			{
				value[i] = (byte)sByteArray[i];
			}

			return value;
		}

		public override void Write(Utf8JsonWriter writer, byte[] value, JsonSerializerOptions options)
		{
			writer.WriteStartArray();

			foreach (var val in value)
			{
				writer.WriteNumberValue(val);
			}

			writer.WriteEndArray();
		}
	}
}
