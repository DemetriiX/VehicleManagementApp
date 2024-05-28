using System;
using System.Linq;
using VehicleManagement.Service.Models;

public static class SortingHelper
{
    public static IQueryable<VehicleMake> ApplySorting(this IQueryable<VehicleMake> query, string sortOrder)
    {
        switch (sortOrder)
        {
            case "name_desc":
                query = query.OrderByDescending(s => s.Name);
                break;
            default:
                query = query.OrderBy(s => s.Name);
                break;
        }
        return query;
    }

    public static IQueryable<VehicleModel> ApplySorting(this IQueryable<VehicleModel> query, string sortOrder)
    {
        switch (sortOrder)
        {
            case "name_desc":
                query = query.OrderByDescending(s => s.Name);
                break;
            default:
                query = query.OrderBy(s => s.Name);
                break;
        }
        return query;
    }
}
