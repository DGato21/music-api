namespace Data.Gateway.SpotifyAPI.DTO
{
    /// <summary>
    /// Request Authentication using Client Credentials
    /// - No access to User Data
    /// </summary>
    public class RequestAuthenticationClient : RequestBase
    {
        public string grant_type { get; set; }
        public string client_id { get; set; }
        public string client_secret { get; set; }

        /// <summary>
        /// For Client Credentials (simple requests)
        /// </summary>
        /// <param name="baseUrl"></param>
        /// <param name="client_id"></param>
        /// <param name="client_secret"></param>
        public RequestAuthenticationClient (string baseUrl, string client_id, string client_secret) : base(baseUrl)
        {
            this.client_id = client_id;
            this.client_secret = client_secret;
            this.grant_type = "client_credentials";
        }

        public string getAuthBody => $"grant_type={this.grant_type}&client_id={this.client_id}&client_secret={client_secret}";
    }
}
