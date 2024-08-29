namespace UserRoles.Data.Repository.IRepository
{
    public interface IRepository<T> where T : class
    {
        Task<T> GetById(Guid id);
        Task<IEnumerable<T>> GetAll();
        Task<T> Add(T entity);
        Task<T> Update(T entity);
        Task<Boolean> Delete(Guid id);
    }
}
