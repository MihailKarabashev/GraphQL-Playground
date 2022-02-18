using GraphQL_Playground.Data;
using GraphQL_Playground.Models;
using HotChocolate;
using HotChocolate.Data;
using System.Linq;

namespace GraphQL_Playground.GraphQL
{
    public class Query
    {
        [UseDbContext(typeof(AppDbContext))]
        [UseProjection]
        public IQueryable<Team> GetTeam([ScopedService] AppDbContext context)
        {
            return context.Teams;
        }

        [UseDbContext(typeof(AppDbContext))]
        [UseProjection]
        public IQueryable<Player> GetPlayers([ScopedService] AppDbContext context)
        {
            return context.Players;
        }
    }
}
