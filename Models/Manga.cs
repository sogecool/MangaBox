namespace MangaBox.Models
{
    public class Manga
    {
        public int Id { get; set; } 
        public string Titulo { get; set; } = string.Empty; 
        public string Mangaka { get; set; } = string.Empty; 
        public int CapituloLeido { get; set; } 
    }
}
