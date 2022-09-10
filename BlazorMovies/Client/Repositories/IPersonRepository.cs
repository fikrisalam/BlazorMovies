using BlazorMovies.Shared.Entities;

namespace BlazorMovies.Client.Repositories
{
    public interface IPersonRepository
    {
        Task CreatePerson(Person person);
    }
}
