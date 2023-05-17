using APIModels;

namespace API_Lab4.Services
{
    public interface IPersonRepository<T> : IRepository<Person>
    {
        Task<IEnumerable<Hobby>> GetPersonsHobbies(int Id);

        Task<IEnumerable<Link>> GetPersonsLinks(int Id);

        Task <int> AddHobbytoPerson(int HId, int PId);

        Task<int> AddHobbyandLink(int PId, int HId, Link newLink);
    }
}
