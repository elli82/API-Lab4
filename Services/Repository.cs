using API_Lab4.Data;
using APIModels;
using Microsoft.EntityFrameworkCore;

namespace API_Lab4.Services
{
    public class Repository : IRepository
    {
        private AppDbContext _Context;

        public Repository(AppDbContext context)
        {
            _Context = context;
        }
        public async Task<Link> AddLink(int PId, int HId, string url)
        {
            var personwhobby = await _Context.HobbiesPersonsLinks.FirstOrDefaultAsync(p => p.PersonID == PId && p.HobbyId == HId);

            if (personwhobby == null)
            {
                return null;
            }
            var link = new Link()
            {
                WebLink = url,
                //personHobbyLink = personwhobby                
            };
            var per = new PersonHobbyLink()
            {
                PersonID = PId,
                HobbyId = HId,
                Links = link
            };
            //await _Context.Links.AddAsync(link);
            await _Context.HobbiesPersonsLinks.AddAsync(per);

            await _Context.SaveChangesAsync();
            return link;
        }

        public async Task<PersonHobbyLink> AddHobbytoPerson(PersonHobbyLink entity)
        {
            var query = await _Context.HobbiesPersonsLinks.FirstOrDefaultAsync
            (q => q.PersonID == entity.PersonID && q.HobbyId == entity.HobbyId);

            if (query != null)
            {
                return null;
            }
            await _Context.HobbiesPersonsLinks.AddAsync(entity);

            await _Context.SaveChangesAsync();
            return entity;
        }

        public async Task<IEnumerable<Person>> GetAll()
        {
            return await _Context.Persons.ToListAsync();
        }

        public async Task<IEnumerable<Hobby>> GetPersonsHobbies(int Id)
        {
            var PsHobbies = from phl in _Context.HobbiesPersonsLinks
                            join h in _Context.Hobbies on phl.HobbyId equals h.HobbyId
                            join p in _Context.Persons on phl.PersonID equals p.PersonId
                            where phl.PersonID == Id
                            select h;
            return await PsHobbies.ToListAsync();
        }

        public async Task<IEnumerable<Link>> GetPersonsLinks(int Id)
        {
            var PsLinks = from phl in _Context.HobbiesPersonsLinks
                          join l in _Context.Links on phl.LinkId equals l.LinkId
                          join p in _Context.Persons on phl.PersonID equals p.PersonId
                          where phl.PersonID == Id
                          select l;
            return await PsLinks.ToListAsync();
        }
    }
}
