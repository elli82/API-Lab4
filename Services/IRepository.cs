using APIModels;
using Microsoft.AspNetCore.Mvc;

namespace API_Lab4.Services
{
    public interface IRepository
    {
        Task<IEnumerable<Person>> GetAll();        

        Task<IEnumerable<Hobby>> GetPersonsHobbies(int Id);

        Task<IEnumerable<Link>> GetPersonsLinks(int Id);


        Task<PersonHobbyLink> AddHobbytoPerson(PersonHobbyLink entity);
        //Task<int> AddHobbytoPerson(int HId, int PId);

        Task<int> AddHobbyandLink(int PId, int HId, string url);
    }
}
