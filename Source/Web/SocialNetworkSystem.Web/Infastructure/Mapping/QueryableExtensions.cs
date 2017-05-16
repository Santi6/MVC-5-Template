using System;
using System.Linq;
using System.Linq.Expressions;
using AutoMapper.QueryableExtensions;

namespace SocialNetworkSystem.Web.Infastructure.Mapping
{
    public static class QueryableExtensions
    {
        public static IQueryable<TDestination> To<TDestination>(this IQueryable source, params Expression<Func<TDestination, object>>[] membersToExpand)
        {
            return source.ProjectTo(AutoMapperConfig.Configuration, membersToExpand);
        }
    }
}