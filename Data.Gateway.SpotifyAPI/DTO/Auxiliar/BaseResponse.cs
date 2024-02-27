namespace Data.Gateway.SpotifyAPI.DTO.Auxiliar
{
    public class BaseResponse
    {
        public ExternalURL external_urls { get; set; }
        public string id { get; set; }
        public string name { get; set; }
        public string href { get; set; }
        public string uri { get; set; }
        public ObjectType type { get; set; }
        public int popularity { get; set; }

        //For Pagination Requests
        public int offset { get; set; }
        public string next { get; set; }
        public string previous { get; set; }
    }
}
