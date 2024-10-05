using System.Text.Json.Serialization;
using Google.Apis.Auth.OAuth2;

namespace Sheduler.Timers.GoogleQueue;

[JsonSourceGenerationOptions(PropertyNamingPolicy = JsonKnownNamingPolicy.SnakeCaseLower)]
[JsonSerializable(typeof(JsonCredentialParameters))]
internal partial class AppJsonSerializerContext : JsonSerializerContext
{
}