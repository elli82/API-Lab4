using APIModels;

namespace API_Lab4.Services
{
    public interface IAPI<T>
    {
        Task<T> GetAllbyId(int id);
        Task<T> Update(T entity);
        Task<T> Add(T newentity);
    }
}
