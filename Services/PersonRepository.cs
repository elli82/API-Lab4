using API_Lab4.Data;
using APIModels;
using Microsoft.EntityFrameworkCore;
using System;

namespace API_Lab4.Services
{
    public class PersonRepository : Repository<Person>, IPersonRepository<Person>
    {
        private AppDbContext _appDbContext;

        public PersonRepository(AppDbContext appDbContext) : base(appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<int> AddHobbyandLink(int PId, int HId, Link newLink)
        {
            var person = await _appDbContext.Persons.FindAsync(PId);

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
            return await _appDbContext.SaveChangesAsync();

        }

        public async Task<int> AddHobbytoPerson(int HId, int PId)
        {
           var hobby = await _appDbContext.Hobbies.FindAsync(HId);
           var person = await _appDbContext.Persons.FindAsync(PId);

            if (person== null || hobby==null) 
            {
                return 0;
            }
            person.Hobbies.Add(hobby);
            return await _appDbContext.SaveChangesAsync();             
        }

        public async Task<IEnumerable<Hobby>> GetPersonsHobbies(int Id)
        {
            var PsHobbies= await _appDbContext.Persons
                            .Include(p => p.Hobbies)
                            .FirstOrDefaultAsync(p => p.PersonId == Id);
         
                return PsHobbies.Hobbies;            
        }

        public async Task<IEnumerable<Link>> GetPersonsLinks(int Id)
        {
            var PsLinks= await _appDbContext.Persons
                         .Include(p => p.Hobbies)
                         .ThenInclude(p => p.Links)
                         .FirstOrDefaultAsync(p => p.PersonId==Id); 
            
                var links = PsLinks.Hobbies
                    .SelectMany(i => i.Links)
                    .ToList();

                return links;            
        }
    }
}
