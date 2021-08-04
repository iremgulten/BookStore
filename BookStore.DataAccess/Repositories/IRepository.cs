using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.DataAccess.Repositories
{
    public interface IRepository<Entity>
    {
        IList<Entity> GetAll();
        Entity GetById(int id);
        IList<Entity> GetWithCriteria(Expression<Func<Entity, bool>> criteria);
        Entity Add(Entity entity);
        Entity Update(Entity genre);
        void Delete(int id);

    }
}
