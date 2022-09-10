using BlazorMovies.Server.Helpers;
using BlazorMovies.Shared.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlazorMovies.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IFileStorageService fileStorageService;
        private string containerName = "movies";

        public MoviesController(ApplicationDbContext context,
            IFileStorageService fileStorageService)
        {
            this.context = context;
            this.fileStorageService = fileStorageService;
        }

        [HttpPost]
        public async Task<ActionResult<int>> Post(Movie movie)
        {
            if (!string.IsNullOrWhiteSpace(movie.Poster))
            {
                var poster = Convert.FromBase64String(movie.Poster);
                movie.Poster = await fileStorageService.SaveFile(poster, "jpg", containerName);
            }

            if (movie.MoviesActors != null)
            {
                for (int i = 0; i < movie.MoviesActors.Count; i++)
                {
                    movie.MoviesActors[i].Order = i + 1;
                }
            }

            context.Add(movie);
            await context.SaveChangesAsync();
            return movie.Id;
        }
    }
}
