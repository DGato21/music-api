namespace Domain.DTO
{
    public class AlbumDTO
    {
        public Guid Id { get; set; }

        public string Title { get; set; }
        public string ArtistName { get; set; }
        public int Stock { get; set;}
        public byte[] Cover { get; set;}

        private string type;
        public string Type
        {
            get { return this.type; }
            set
            {
                if (availableTypes.Contains(value)) { this.type = value; }
                else { throw new Exception("Application.DTO.AlbumDTO.Type: Invalid type property value."); }
            }
        }

        private readonly List<string> availableTypes = new List<string>() { "Vinyl", "CD" };
    }
}
