using System.Collections.Generic;

namespace BookStore.DataAccess.Repositories.Abstract
{
    public interface IGenericRepository<Entity>
    {
        IList<Entity> GetAll();
        Entity GetById(int id);
        Entity Add(Entity entity);
        Entity Update(Entity entity);
        void Delete(Entity entity);

    }
}
