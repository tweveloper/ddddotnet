using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace AllregoSoft.WebManagementSystem.WebAdmin.Extensions
{
    public static class SessionExtensions
    {
        public static void Set(this ISession session, string key, object value) =>
            session.SetString(key, JsonConvert.SerializeObject(value));

        public static T Get<T>(this ISession session, string key)
        {
            var value = session.GetString(key);

            return value == null ? default(T) : JsonConvert.DeserializeObject<T>(value);
        }

        public static List<T> GetList<T>(this ISession session, string key)
        {
            var value = session.GetString(key);

            return value == null ? default(List<T>) : JsonConvert.DeserializeObject<List<T>>(value);
        }
    }
}
