using Data.Gateway.SpotifyAPI.DTO.Auxiliar;
using Infrastructure.CrossCutting;

namespace Data.Gateway.SpotifyAPI.DTO
{
    public class RequestSearchInfo : RequestBase
    {
        public string q { get; set; }
        public IList<ObjectType> type { get; set; }

        public int limit { get; set; } = 20; //0-50
        public int offset { get; set; } = 0; //0-1000

        public RequestSearchInfo(string baseUrl, string filter, IEnumerable<string> typeFilter, int limit = 20, int offset = 0) : base(baseUrl)
        {
            this.q = filter;
            if (typeFilter.Any()) { this.type = new List<ObjectType>(); }
            foreach (var type in typeFilter) { this.type.Add(Enum.Parse<ObjectType>(type)); }
        }

        internal string getAuthQuery() => UrlMethods.QueryStringBuilder(this, 
            new List<string>() { "q", "type", "limit", "offset" });
    }
}
