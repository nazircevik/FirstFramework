using FirstFramework.Core.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstFramework.Core.DadaAcces.EntityFramework
{
   public class EfQuerableRepository<T>:IQueryableRepository<T>where T:class,IEntity,new()
    {
       private DbContext _context;
        IDbSet<T> _entities;
        public EfQuerableRepository(DbContext context)
        {
            _context = context;

        }
        public IQueryable<T> Table => this.Entities;

        protected virtual IDbSet<T>Entities
        {
            get   { return _entities ?? (_entities = _context.Set<T>());  }
                //if(_entities==null)
                //{
                //    _entities = _context.Set<T>();

                //}
                //return _entities;             
        }
    } 
}
