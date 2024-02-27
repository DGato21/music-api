namespace Infrastructure.Exceptions.Spotify
{
    public class SpotifyMissingLoginException : Exception
    {
        public string ExceptionMessage { get; set; }

        public SpotifyMissingLoginException(string exception)
        {
            this.ExceptionMessage = exception;
        }
    }
}
