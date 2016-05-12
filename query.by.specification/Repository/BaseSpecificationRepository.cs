using System.Collections.Generic;
using System.Linq;
using LinqKit;
using query.@by.specification.Context;
using query.@by.specification.Repository.Extensions;
using query.@by.specification.Specification;

namespace query.@by.specification.Repository
{
    public abstract class BaseSpecificationRepository<T> : ISpecificationRepository<T> where T : class
    {
        private readonly IContext _context;

        protected BaseSpecificationRepository(IContext context)
        {
            _context = context;
        }

        private IQueryable<T> FindBy(BaseSpecification<T> specification)
        {
            return
                _context.Table<T>()
                    .Fetch(specification.GetSpecifications().OfType<IInclude<T>>())
                    .AsExpandable()
                    .Where(specification.Predicate);
        }

        public T First(BaseSpecification<T> specification)
        {
            return FindBy(specification).First();
        }

        public T FirstOrDefault(BaseSpecification<T> specification)
        {
            return FindBy(specification).FirstOrDefault();
        }

        public IList<T> List(BaseSpecification<T> specification)
        {
            return FindBy(specification).ToList();
        }

        public T Single(BaseSpecification<T> specification)
        {
            return FindBy(specification).Single();
        }

        public T SingleOrDefault(BaseSpecification<T> specification)
        {
            return FindBy(specification).SingleOrDefault();
        }
    }
}