using Newtonsoft.Json;

namespace Infrastructure.CrossCutting
{
    public static class UrlMethods
    {
        public static string QueryStringBuilder(object obj, IEnumerable<string> filterFields = null)
        {
            string queryStr = string.Empty;

            queryStr = string.Join("&", objectToDictionary(obj)
                .Where(x=> filterFields.Contains(x.Key))
                .Where(y=> !string.IsNullOrEmpty(y.Value))
                .Select(kvp => $"{kvp.Key}='{kvp.Value}'"));

            return queryStr;
        }

        private static Dictionary<string, string> objectToDictionary(object obj)
        {
            var json = JsonConvert.SerializeObject(obj);
            var dictionary = JsonConvert.DeserializeObject<Dictionary<string, string>>(json);
            return dictionary;
        }
    }
}
