using System;
using System.Linq;
using VehicleManagement.Service;
using VehicleManagement.Service.Models;

public static class FilteringHelper
{
    public static IQueryable<VehicleMake> ApplyFiltering(this IQueryable<VehicleMake> query, FilteringParameters parameters)
    {
        if (!string.IsNullOrEmpty(parameters.SearchString))
        {
            query = query.Where(s => s.Name.Contains(parameters.SearchString));
        }
        return query;
    }

    public static IQueryable<VehicleModel> ApplyFiltering(this IQueryable<VehicleModel> query, FilteringParameters parameters)
    {
        if (!string.IsNullOrEmpty(parameters.SearchString))
        {
            query = query.Where(s => s.Name.Contains(parameters.SearchString));
        }
        return query;
    }
}