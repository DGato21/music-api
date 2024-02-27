using Data.Gateway.SpotifyAPI.DTO.Auxiliar;

namespace Data.Gateway.SpotifyAPI.DTO
{
    public class TopItemResponse : BaseResponse
    {
        public IEnumerable<SpotifyItem> items { get; set; }
        public int total { get; set; }
    }
}
