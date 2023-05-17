using APIModels;
using Microsoft.AspNetCore.Mvc;

namespace API_Lab4.Services
{
    public interface IRepository<T>
    {
        Task<IEnumerable<T>> GetAll();

        Task<T> GetById(int id);

        Task<T> Update(T entity);

        Task<T> DeleteById(int id);

        Task<T> Add(T entity);

        //added by VS
        //Task<ActionResult<Person>> Update(Person pers);
    }
}
