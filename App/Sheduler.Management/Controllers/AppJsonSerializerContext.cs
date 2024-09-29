using System.Text.Json.Serialization;
using Sheduler.App;

namespace Sheduler.Management.Controllers;

[JsonSerializable(typeof(ScheduleViewModel[]))]
internal partial class AppJsonSerializerContext : JsonSerializerContext
{
}