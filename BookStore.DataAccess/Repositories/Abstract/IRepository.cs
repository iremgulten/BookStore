using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.DataAccess.Repositories.Abstract
{
    public interface IRepository<Entity>
    {
        IList<Entity> GetAll();
        Entity GetById(int id);
        Entity Add(Entity entity);
        Entity Update(Entity entity);
        void Delete(Entity entity);

    }
}
