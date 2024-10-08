namespace MangaBox.Models
{
    public class MangaRequest
    {
        public string Titulo { get; set; } = string.Empty; 
        public string Mangaka { get; set; } = string.Empty;
        public int CapituloLeido { get; set; }
    }
}
