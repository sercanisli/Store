﻿using System.Text.Json;

namespace Store.Infrastructure.Extensions
{
    public static class SessionExtension
    {
        public static void SetJson(this ISession session, string key, object value)
        {
            session.SetString(key, JsonSerializer.Serialize(value));
        }
        public static void SetJson<T>(this ISession session, string key, T value)
        {
            session.SetString(key,JsonSerializer.Serialize(value));
        }
        public static T? GetJson<T>(this ISession session,string key)
        {
            var data = session.GetString(key);
            if (data == null)
            {
                return default(T);
            }

            return JsonSerializer.Deserialize<T>(data);
        }
    }
}
