namespace Domain.Contracts.Behaviors
{
    public interface IFullyUpdateable<T> where T : class
    {
        Task<T> UpdateAsync(T entity);
    }
}
