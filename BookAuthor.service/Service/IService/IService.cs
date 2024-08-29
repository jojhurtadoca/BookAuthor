namespace BookAuthor.Service.Service.IService
{
    public interface IService<GetT, CreateT, UpdateT> 
        where GetT : class
        where CreateT : class
        where UpdateT : class
    {
        Task<GetT> Create(CreateT entity);
        Task<GetT> Update(UpdateT entity);
        Task<Boolean> Delete(Guid entity);
        Task<IEnumerable<GetT>> GetAll();

        Task<IEnumerable<GetT>> GetResultPaginated(int page, int limit);
        Task<GetT> GetById(Guid id);
    }
}
