namespace Repository.CommandQueries
{
    public class CommandText : ICommandText
    {
        public string GetAlbums => "SELECT * FROM [AlbumV0]";
        public string GetAlbumById => "SELECT * FROM [AlbumV0] WHERE Id= @Id";
        public string AddAlbum => @"INSERT INTO AlbumV0 (Id, Title, ArtistName, TypeId, Stock, Cover)
VALUES (@Id, @Title, @ArtistName, @TypeId, @Stock, @Cover)";
        public string UpdateAlbum => @"UPDATE AlbumV0 
SET Title = @Title, ArtistName = @ArtistName, TypeId = @TypeId, Stock = @Stock, Cover = @Cover
WHERE Id = @Id";
        public string RemoveAlbum => "DELETE FROM AlbumV0 WHERE Id= @Id";
    }
}
