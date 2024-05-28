using System;
using System.Linq;

public static class FilteringHelper
{
    public static IQueryable<T> ApplyFilter<T>(IQueryable<T> source, Func<T, bool> predicate)
    {
        return source.Where(predicate).AsQueryable();
    }
}
