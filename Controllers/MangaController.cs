using Microsoft.AspNetCore.Mvc;
using MangaBox.Models;

namespace MangaBox.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MangaController : Controller // Heredando de Controller
    {
        private static System.Collections.Generic.List<Manga> mangas = new System.Collections.Generic.List<Manga>();
        private static int nextId = 1;

        [HttpPost]
        public ActionResult<MangaResponse> AddManga([FromBody] MangaRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.Titulo) || string.IsNullOrWhiteSpace(request.Mangaka))
            {
                return BadRequest(new MangaResponse
                {
                    IsSuccess = false,
                    Message = "El título y el mangaka son requeridos."
                });
            }

            var manga = new Manga
            {
                Id = nextId++,
                Titulo = request.Titulo,
                Mangaka = request.Mangaka,
                CapituloLeido = request.CapituloLeido
            };

            mangas.Add(manga);

            return Ok(new MangaResponse
            {
                IsSuccess = true,
                Message = "Manga agregado exitosamente.",
                Data = manga
            });
        }

        [HttpGet]
        public ActionResult<System.Collections.Generic.List<Manga>> GetMangas()
        {
            return Ok(mangas);
        }

        [HttpGet("{id}")]
        public ActionResult<Manga> GetMangaById(int id)
        {
            var manga = mangas.FirstOrDefault(m => m.Id == id);
            if (manga == null)
            {
                return NotFound(new MangaResponse
                {
                    IsSuccess = false,
                    Message = "Manga no encontrado."
                });
            }
            return Ok(manga);
        }

        [HttpPut("{id}")]
        public ActionResult<MangaResponse> UpdateManga(int id, [FromBody] MangaRequest request)
        {
            var manga = mangas.FirstOrDefault(m => m.Id == id);
            if (manga == null)
            {
                return NotFound(new MangaResponse
                {
                    IsSuccess = false,
                    Message = "Manga no encontrado."
                });
            }

            if (string.IsNullOrWhiteSpace(request.Titulo) || string.IsNullOrWhiteSpace(request.Mangaka))
            {
                return BadRequest(new MangaResponse
                {
                    IsSuccess = false,
                    Message = "El título y el mangaka son requeridos."
                });
            }

            manga.Titulo = request.Titulo;
            manga.Mangaka = request.Mangaka;
            manga.CapituloLeido = request.CapituloLeido;

            return Ok(new MangaResponse
            {
                IsSuccess = true,
                Message = "Manga actualizado exitosamente.",
                Data = manga
            });
        }

        [HttpDelete("{id}")]
        public ActionResult<MangaResponse> DeleteManga(int id)
        {
            var manga = mangas.FirstOrDefault(m => m.Id == id);
            if (manga == null)
            {
                return NotFound(new MangaResponse
                {
                    IsSuccess = false,
                    Message = "Manga no encontrado."
                });
            }

            mangas.Remove(manga);

            return Ok(new MangaResponse
            {
                IsSuccess = true,
                Message = "Manga eliminado exitosamente."
            });
        }
    }
}
