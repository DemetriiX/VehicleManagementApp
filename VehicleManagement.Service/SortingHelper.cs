using System;
using System.Linq;

public static class SortingHelper
{
    public static IQueryable<T> ApplySort<T>(IQueryable<T> source, string propertyName, bool ascending)
    {
        if (string.IsNullOrEmpty(propertyName))
            return source;

        var property = typeof(T).GetProperty(propertyName);
        if (property == null)
            return source;

        return ascending ? source.OrderBy(x => property.GetValue(x, null)) : source.OrderByDescending(x => property.GetValue(x, null));
    }
}
