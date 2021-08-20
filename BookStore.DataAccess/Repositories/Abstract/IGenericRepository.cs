using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookStore.DataAccess.Repositories.Abstract
{
    public interface IGenericRepository<Entity>
    {
        Task<IList<Entity>> GetAll();
        Task<Entity> GetById(int id);
        Task<Entity> Add(Entity entity);
        Task<Entity> Update(Entity entity);
        Task<Entity> Delete(Entity entity);

    }
}
