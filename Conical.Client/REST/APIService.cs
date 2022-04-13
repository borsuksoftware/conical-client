using System;
using System.Collections.Generic;
using System.Text.Json;

namespace BorsukSoftware.Conical.Client.REST
{
    /// <summary>
    /// Class to provide access to the underlying REST API 
    /// </summary>
    public partial class ApiService : IApiService
    {
        #region Data Model

        private System.Text.Json.JsonSerializerOptions _serializerOptions;
        private System.Net.Http.HttpClient _httpClient;

        #endregion

        public ApiService(System.Net.Http.HttpClient httpClient)
        {
            if (httpClient == null)
                throw new ArgumentNullException(nameof(httpClient));

            _httpClient = httpClient;
            _serializerOptions = new System.Text.Json.JsonSerializerOptions()
            {
                PropertyNameCaseInsensitive = true,
            };
            _serializerOptions.Converters.Add(new System.Text.Json.Serialization.JsonStringEnumConverter(null, false));
            _serializerOptions.Converters.Add(new ByteArrayConverter());
        }

        /// <summary>
        /// Custom serialization converter to allow the serialization of byte arrays (necessary, at least, for .net assemblies)
        /// </summary>
        private class ByteArrayConverter : System.Text.Json.Serialization.JsonConverter<byte[]>
        {
            public override byte[] Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            {
                var values = new List<byte>(32);

                while (reader.Read())
                {
                    switch (reader.TokenType)
                    {
                        case JsonTokenType.StartArray:
                            break;

                        case JsonTokenType.Number:
                            values.Add(reader.GetByte());
                            break;

                        case JsonTokenType.EndArray:
                            return values.ToArray();

                        default:
                            throw new InvalidOperationException($"Unsupported token type '{reader.TokenType}'");
                    }
                }

                throw new InvalidOperationException("Invalid initial Json state");
            }

            public override void Write(Utf8JsonWriter writer, byte[] value, JsonSerializerOptions options)
            {
                throw new NotImplementedException();
            }
        }

        private class QueryStringHelper
        {
            public string RootUrl { get; }

            private List<Tuple<string, string>> _stringifiedParameters = new List<Tuple<string, string>>();

            public QueryStringHelper( string rootUrl)
            {
                this.RootUrl = rootUrl;
            }

            public void RegisterQueryParameter(string parameterName, string[] array)
            {
                if (array == null)
                    return;

                foreach (var entry in array)
                {
                    _stringifiedParameters.Add(Tuple.Create<string, string>(parameterName, System.Net.WebUtility.UrlEncode(entry)));
                }
            }

            public void RegisterQueryParameter<TEnum>(string parameterName, TEnum[] array) where TEnum : Enum
            {
                if (array == null)
                    return;

                foreach (var entry in array)
                    _stringifiedParameters.Add(Tuple.Create<string, string>(parameterName, entry.ToString()));

            }

            public void RegisterQueryParameter(string parameterName, string value)
            {
                _stringifiedParameters.Add(Tuple.Create<string, string>(parameterName, System.Net.WebUtility.UrlEncode(value)));
            }

            public void RegisterQueryParameter(string parameterName, bool value)
            {
                _stringifiedParameters.Add(Tuple.Create<string, string>(parameterName, value.ToString()));
            }

            public void RegisterQueryParameter(string parameterName, DateTime dateTime)
            {
                _stringifiedParameters.Add(Tuple.Create<string, string>(parameterName, dateTime.ToString("yyyy-MM-ddTHH:mm:ss.fffZ")));
            }

            public void RegisterQueryParameter(string parameterName, DateTime? dateTime)
            {
                if (dateTime.HasValue)
                    this.RegisterQueryParameter(parameterName, dateTime.Value);
            }

            public void RegisterQueryParameter(string parameterName, int @int)
            {
                _stringifiedParameters.Add(Tuple.Create<string, string>(parameterName, @int.ToString()));
            }

            public void RegisterQueryParameter(string parameterName, int? @int)
            {
                if (@int.HasValue)
                    _stringifiedParameters.Add(Tuple.Create<string, string>(parameterName, @int.ToString()));
            }

            public void RegisterQueryParameter<TEnum>( string parameterName, TEnum enumValue ) where TEnum : Enum
            {
                _stringifiedParameters.Add(Tuple.Create<string, string>(parameterName, enumValue.ToString()));
            }

            public void RegisterQueryParameter(string parameterName, long @long)
            {
                _stringifiedParameters.Add(Tuple.Create<string, string>(parameterName, @long.ToString()));
            }

            public string GenerateFullUri()
            {
                if (this._stringifiedParameters.Count == 0)
                    return this.RootUrl;

                var sb = new System.Text.StringBuilder();
                sb.Append(this.RootUrl);
                sb.Append("?");
                
                for( int i = 0; i < this._stringifiedParameters.Count;++i )
                {
                    if (i != 0)
                        sb.Append("&");

                    sb.Append(_stringifiedParameters[i].Item1);
                    sb.Append("=");
                    sb.Append(_stringifiedParameters[i].Item2);
                }

                var output = sb.ToString();
                return output;
            }
        }
    }
}