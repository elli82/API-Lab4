using API_Lab4.Data;
using APIModels;
using Microsoft.EntityFrameworkCore;

namespace API_Lab4.Services
{
    public class Repository: IRepository
    {
        private AppDbContext _Context;
        //private DbSet<T> _dbSet;

        public Repository(AppDbContext context)
        {
            _Context = context;
            //_dbSet = context.Set<T>();
        }

        //public async Task<Person> Add(Person entity)
        //{
        //    await _Context.Persons.AddAsync(entity);
        //    await _Context.SaveChangesAsync();
        //    return entity;
        //}        

        public async Task<int> AddHobbyandLink(int PId, int HId, Link newLink)
        {
            var person = await _Context.Persons.FindAsync(PId);

            if (person == null)
            {
                return 0;
            }
            var hobby = person.Hobbies.FirstOrDefault(i => i.HobbyId == HId);

            if (hobby == null)
            {
                return 0;
            }
            hobby.Links.Add(newLink);
            return await _Context.SaveChangesAsync();
        }

        public async Task<int> AddHobbytoPerson(int HId, int PId)
        {
            var hobby = await _Context.Hobbies.FindAsync(HId);
            var person = await _Context.Persons.FindAsync(PId);

            if (person == null || hobby == null)
            {
                return 0;
            }
            person.Hobbies.Add(hobby);
            return await _Context.SaveChangesAsync();
        }

        //public async Task<Person> DeleteById(int id)
        //{
        //    var entity = await _Context.Persons.FindAsync(id);
        //    if (entity == null)
        //    {
        //        return null;
        //    }

        //    _Context.Persons.Remove(entity);
        //    await _Context.SaveChangesAsync();
        //    return entity;
        //}

        public async Task<IEnumerable<Person>> GetAll()
        {
            return await _Context.Persons.ToListAsync();
        }

        //public async Task<Person> GetById(int id)
        //{
        //    return await _Context.Persons.FindAsync(id);
        //}

        public async Task<IEnumerable<Hobby>> GetPersonsHobbies(int Id)
        {
            var PsHobbies = await _Context.Persons
                           .Include(p => p.Hobbies)
                           .FirstOrDefaultAsync(p => p.PersonId == Id);

            return PsHobbies.Hobbies;
        }

        public async Task<IEnumerable<Link>> GetPersonsLinks(int Id)
        {
            var PsLinks = await _Context.Persons
                         .Include(p => p.Hobbies)
                         .ThenInclude(p => p.Links)
                         .FirstOrDefaultAsync(p => p.PersonId == Id);

            var links = PsLinks.Hobbies
                .SelectMany(i => i.Links)
                .ToList();

            return links;
        }

        //public async Task<Person> Update(Person entity)
        //{
        //    _Context.Persons.Update(entity);
        //    await _Context.SaveChangesAsync();
        //    return entity;
        //}
    }
}
