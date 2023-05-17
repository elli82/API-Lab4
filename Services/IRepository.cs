using APIModels;
using Microsoft.AspNetCore.Mvc;

namespace API_Lab4.Services
{
    public interface IRepository
    {
        Task<IEnumerable<Person>> GetAll();

        //Task<Person> GetById(int id);

        //Task<Person> Update(Person entity);

        //Task<Person> DeleteById(int id);

        //Task<Person> Add(Person entity);

        Task<IEnumerable<Hobby>> GetPersonsHobbies(int Id);

        Task<IEnumerable<Link>> GetPersonsLinks(int Id);

        Task<int> AddHobbytoPerson(int HId, int PId);

        Task<int> AddHobbyandLink(int PId, int HId, Link newLink);
    }
}
