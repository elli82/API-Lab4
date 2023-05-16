using API_Lab4.Data;
using APIModels;

namespace API_Lab4.Services
{
    public class PersonRepository : IPerson
    {
        private AppDbContext _appDbContext;

        public PersonRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<Person> GetPeople()
        {
            return _appDbContext.Persons;
        }

        public Person GetPersonById(int id)
        {
            return _appDbContext.Persons.FirstOrDefault(p => p.PersonId == id);
        }

        public IEnumerable<Person> GetPersonByName(string name)
        {
            IQueryable<Person> query = _appDbContext.Persons;

            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(p => p.Name.Contains(name));
            }
            return query.ToList();
        }
    }
}
