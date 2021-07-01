using System.Collections.Generic;
using System.Threading.Tasks;

namespace AmazonTracker.Domain.Repository
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetItemsAsync(string query);
        Task<T> GetItemAsync(string id);
        Task AddItemAsync(T item);
        Task UpdateItemAsync(string id, T item);
        Task DeleteItemAsync(string id);
    }
}

