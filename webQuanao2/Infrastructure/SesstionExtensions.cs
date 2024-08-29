using Microsoft.CodeAnalysis.CSharp.Syntax;
using Renci.SshNet;
using System.Text.Json;

namespace webQuanao2.Infrastructure
{
	public static class SessionExtensions
	{
		public static void SetJson<T>(this ISession session, string key, T value)
		{
			session.SetString(key, JsonSerializer.Serialize(value));
		}

		public static T? GetJson<T>(this ISession session, string key)
		{
			var sesionData = session.GetString(key);
			return sesionData == null ? default(T): JsonSerializer.Deserialize<T>(sesionData);
		}
	}
}