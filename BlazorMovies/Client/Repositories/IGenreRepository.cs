using BlazorMovies.Shared.Entities;

namespace BlazorMovies.Client.Repositories
{
    public interface IGenreRepository
    {
        Task CreateGenre(Genre genre);
        Task<List<Genre>> GetGenres();
    }
}
