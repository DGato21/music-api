using Data.Gateway.SpotifyAPI.DTO.Auxiliar;

namespace Data.Gateway.SpotifyAPI.DTO
{
    public class RequestTopItem : RequestBase
    {
        public TopItemObjectType type { get; set; }
        public TopItemTimeRange time_range { get; set; }
        public int limit { get; set; } = 20; //0-50
        public int offset { get; set; } = 0; //0-limit

        public RequestTopItem(string baseUrl, string type, string time_range = "medium_term", int limit = 20, int offset = 0) : base(baseUrl)
        {
            this.type = Enum.Parse<TopItemObjectType>(type);
            this.time_range = Enum.Parse<TopItemTimeRange>(time_range);
            this.limit = limit;
            this.offset = offset;
        }
    }

    public enum TopItemObjectType
    {
        artists,
        tracks
    }

    public enum TopItemTimeRange
    {
        long_term,
        medium_term,
        short_term
    }
}
