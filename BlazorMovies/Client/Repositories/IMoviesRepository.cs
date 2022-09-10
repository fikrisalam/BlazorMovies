using BlazorMovies.Shared.Entities;

namespace BlazorMovies.Client.Repositories
{
    public interface IMoviesRepository
    {
        Task<int> CreateMovie(Movie movie);
    }
}
