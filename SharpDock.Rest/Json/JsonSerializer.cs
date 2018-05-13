using RestSharp;
using RestSharp.SnakeCaseSerializer;
using SimpleJson;
using System;

namespace SharpDock.Rest.Json
{
    public static class JsonSerializer
    {
        public static string SerializeObject(object obj, SerializationStrategy strategyType)
        {
            var strategy = CreateStrategy(strategyType);
            return SimpleJson.SimpleJson.SerializeObject(obj, strategy);
        }

        private static IJsonSerializerStrategy CreateStrategy(SerializationStrategy strategyType)
        {
            switch (strategyType)
            {
                case SerializationStrategy.SnakeCase:
                    return new SnakeCaseSerializationStrategy();
                case SerializationStrategy.SnakeCaseIgnoreNull:
                    return new SnakeCaseSerializationStrategy { IgnoreNullProperties = true };
                default:
                    throw new ArgumentException($"Unknown serialization strategy type {strategyType.ToString()}");
            }
        }
    }
}
