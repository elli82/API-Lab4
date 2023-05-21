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

    //public async Task<Person> Add(Person entity)
    //{
    //    await _Context.Persons.AddAsync(entity);
    //    await _Context.SaveChangesAsync();
    //    return entity;
    //}

    public async Task<int> AddHobbyandLink(int PId, int HId, string url)
    {
        var personwhobby = await _Context.HobbiesPersonsLinks.FirstOrDefaultAsync(p => p.PersonID == PId && p.HobbyId == HId);

        if (personwhobby == null)
        {
            return 0;
        }
            var link = new Link()
            {
                WebLink = url
            };
        await _Context.Links.AddAsync(link);

        await _Context.AddRangeAsync(personwhobby.Links);

        return await _Context.SaveChangesAsync();
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
    //public async Task<int> AddHobbytoPerson(int HId, int PId)
    //{
    //    var hobby = await _Context.Hobbies.FindAsync(HId);
    //    var person = await _Context.Persons.FindAsync(PId);

    //    if (person == null || hobby == null)
    //    {
    //        return 0;
    //    }
    //    person.Hobbies.Add(hobby);
    //    return await _Context.SaveChangesAsync();
    //}

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
            var PsHobbies = from phl in _Context.HobbiesPersonsLinks
                            join h in _Context.Hobbies on phl.HobbyId equals h.HobbyId
                            join p in _Context.Persons on phl.PersonID equals p.PersonId
                            where phl.PersonID == Id
                            select h;
            return await PsHobbies.ToListAsync();

        //var PsHobbies = await _Context.Persons
        //               .Include(p => p.Hobbies)
        //               .FirstOrDefaultAsync(p => p.PersonId == Id);

        //return PsHobbies.Hobbies;
    }

    public async Task<IEnumerable<Link>> GetPersonsLinks(int Id)
    {
            var PsLinks = from phl in _Context.HobbiesPersonsLinks
                          join l in _Context.Links on phl.LinkId equals l.LinkId
                          join p in _Context.Persons on phl.PersonID equals p.PersonId
                          where phl.PersonID == Id
                          select l;
            return await PsLinks.ToListAsync();

        //var PsLinks = await _Context.Persons
        //             .Include(p => p.Hobbies)
        //             .ThenInclude(p => p.Links)
        //             .FirstOrDefaultAsync(p => p.PersonId == Id);

        //var links = PsLinks.Hobbies
        //    .SelectMany(i => i.Links)
        //    .ToList();

        //return links;
    }

    //public async Task<Person> Update(Person entity)
    //{
    //    _Context.Persons.Update(entity);
    //      await _Context.SaveChangesAsync();
    //    return entity;
    //}
}
}
