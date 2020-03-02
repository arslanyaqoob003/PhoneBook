using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace PhoneBook.Core.Extensions
{
    // check null value of where in Linq Query
    public static class NullSafePredicate
    {
        public static IQueryable<T> NullSafeWhere<T>(this IQueryable<T> source,
            Expression<Func<T, bool>> predicate)
        {
            return predicate == null ? source : source.Where(predicate);
        }
    }
}
