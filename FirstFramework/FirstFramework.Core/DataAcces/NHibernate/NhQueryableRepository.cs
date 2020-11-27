using FirstFramework.Core.DadaAcces;
using FirstFramework.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstFramework.Core.DataAcces.NHibernate
{
    public class NhQueryableRepository<T> : IQueryableRepository<T> where T : class, IEntity, new()
    {
        private NHibernateHelper _nHibernateHelper;
        private IQueryable<T> _entities;

       

        public NhQueryableRepository(NHibernateHelper nhibernateHelper)
        {

            _nHibernateHelper = nhibernateHelper;
        }
        public IQueryable<T> Table
        {
            get { return this.Entities; }
        }

        public virtual IQueryable<T> Entities
        {
            get { return _entities ?? (_entities = _nHibernateHelper.OpenSession().Query<T>()); }
            //{
            //    if(_entites==null)
            //    {
            //        _entites = _nHibernateHelper.OpenSession().Query<T>();
            //    }
            //    return _entites;
            //}
        }
    }
}
