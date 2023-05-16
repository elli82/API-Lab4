using API_Lab4.Data;
using APIModels;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace API_Lab4.Services
{
    public class HobbyRepository : IAPI<Hobby>
    {
        private AppDbContext _Context;

        public HobbyRepository(AppDbContext appDbContext)
        {
            _Context = appDbContext;
        }
        public Task<Hobby> Add(Hobby newentity)
        {
            throw new NotImplementedException();
        }

        public async List<IEnumerable<Hobby>> GetAllbyId(int id)
        {
            var result = from hobby in _Context.Hobbies
                                join person in _Context.Persons on hobby.HobbyId equals person.PersonId
                                where person.PersonId == id
                                select new
                                {
                                    Name = person.Name,
                                    Title = hobby.Title,
                                    Explains = hobby.Description
                                };
            return result;
        }

        public Task<Hobby> Update(Hobby entity)
        {
            throw new NotImplementedException();
        }
    }
}
