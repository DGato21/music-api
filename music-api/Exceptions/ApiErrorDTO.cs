namespace music_api.Exceptions
{
    public class ApiErrorDTO
    {
        public string ErrorMessage { get; set; }

        public ApiErrorDTO(string errorMessage) 
        {
            this.ErrorMessage = errorMessage;
        }
    }
}
