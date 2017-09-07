using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
namespace Data.Extension
{
    public static class IQueryableExtensions
    {

        /// <summary>
        /// Instructs the repository to eager load entities that may be in the type's association path.
        /// </summary>
        /// <param name="query">A previously created query object which the expansion should be applied to.</param>
        /// <param name="path">
        /// The path of the child entities to eager load.
        /// Deeper paths can be specified by separating the path with dots.
        /// </param>
        /// <returns>A new query object to which the expansion was applied.</returns>
        public static IQueryable<T> Expand<T>(this IQueryable<T> query, string path) where T : class
        {
            return query.Include(path);
        }

        /// <summary>
        /// Instructs the repository to eager load entities that may be in the type's association path.
        /// </summary>
        /// <param name="query">A previously created query object which the expansion should be applied to.</param>
        /// <param name="path">The path of the child entities to eager load.</param>
        /// <returns>A new query object to which the expansion was applied.</returns>
        public static IQueryable<T> Expand<T, TProperty>(this IQueryable<T> query, Expression<Func<T, TProperty>> path) where T : class
        {
            return query.Include(path);
        }

    }

}
