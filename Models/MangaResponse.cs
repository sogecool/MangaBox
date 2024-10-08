namespace MangaBox.Models
{
    public class MangaResponse
    {
        public bool IsSuccess { get; set; } = false;
        public string Message { get; set; } = string.Empty; 
        public Manga? Data { get; set; }
    }
}
