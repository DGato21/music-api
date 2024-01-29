namespace Repository.CommandQueries
{
    public interface ICommandText
    {
        string GetAlbums { get; }
        string GetAlbumById { get; }
        string AddAlbum { get; }
        string UpdateAlbum { get; }
        string RemoveAlbum { get; }
    }
}
