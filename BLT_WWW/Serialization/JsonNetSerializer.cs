using Nancy;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace BLT.WWW.Serialization
{
    public class JsonNetSerializer : ISerializer
    {
        private readonly JsonSerializer _serializer;
        internal static readonly JsonSerializerSettings SERIALIZATION_SETTINGS = new JsonSerializerSettings
        {
            ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
            ContractResolver = new CamelCasePropertyNamesContractResolver(),
            Formatting = Formatting.None
        };
        public JsonNetSerializer()
        {
            _serializer = JsonSerializer.Create(JsonNetSerializer.SERIALIZATION_SETTINGS);
        }

        public bool CanSerialize(string contentType)
        {
            return contentType == "application/json";
        }

        public void Serialize<TModel>(string contentType, TModel model, Stream outputStream)
        {
            using (var writer = new JsonTextWriter(new StreamWriter(outputStream)))
            {
                _serializer.Serialize(writer, model);
                writer.Flush();
            }
        }


        public IEnumerable<string> Extensions
        {
            get { yield return "json"; }
        }
    }

    public static class JsonSerializationExtensions
    {
        public static string ToJson(this object obj)
        {
            return JsonConvert.SerializeObject(obj, JsonNetSerializer.SERIALIZATION_SETTINGS);
        }
    }
}