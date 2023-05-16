using APIModels;

namespace API_Lab4.Services
{
    public interface IPerson
    {
        IEnumerable<Person> GetPeople();
        Person GetPersonById(int id);
        IEnumerable<Person> GetPersonByName(string name);
    }
}
