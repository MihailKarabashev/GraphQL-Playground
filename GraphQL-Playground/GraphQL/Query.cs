using GraphQL_Playground.Data;
using GraphQL_Playground.GraphQL.FilterCustomizations;
using GraphQL_Playground.GraphQL.SortingCustomizations;
using GraphQL_Playground.Models;
using HotChocolate;
using HotChocolate.Data;
using System.Linq;

namespace GraphQL_Playground.GraphQL
{
    public class Query
    {
        [UseDbContext(typeof(AppDbContext))]
        [UseFiltering(typeof(TeamFilterType))]
        [UseSorting(typeof(TeamSortType))]
        public IQueryable<Team> GetTeam([ScopedService] AppDbContext context)
        {
            return context.Teams;
        }

        [UseDbContext(typeof(AppDbContext))]
        //[UseFiltering]
        public IQueryable<Player> GetPlayers([ScopedService] AppDbContext context)
        {
            return context.Players;
        }
    }
}
