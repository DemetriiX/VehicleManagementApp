using System;
using System.Linq;
using VehicleManagement.Service.Models;

public static class FilteringHelper
{
    public static IQueryable<VehicleMake> ApplyFiltering(this IQueryable<VehicleMake> query, string searchString)
    {
        if (!string.IsNullOrEmpty(searchString))
        {
            query = query.Where(s => s.Name.Contains(searchString));
        }
        return query;
    }

    public static IQueryable<VehicleModel> ApplyFiltering(this IQueryable<VehicleModel> query, string searchString)
    {
        if (!string.IsNullOrEmpty(searchString))
        {
            query = query.Where(s => s.Name.Contains(searchString));
        }
        return query;
    }
}