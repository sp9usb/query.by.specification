using System.Data.Entity;
using System.Linq;
using NSubstitute;

namespace query.@by.specification.Tests.Extensions
{
    public static class DbSetExtensions
    {
        public static void Initialize<T>(this IDbSet<T> mock, IQueryable<T> data) where T : class
        {
            mock.Provider.Returns(data.Provider);
            mock.Expression.Returns(data.Expression);
            mock.ElementType.Returns(data.ElementType);
            mock.GetEnumerator().Returns(data.GetEnumerator());
        }
    }
}