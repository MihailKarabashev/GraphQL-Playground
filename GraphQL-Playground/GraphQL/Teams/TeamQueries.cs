using GraphQL_Playground.Data;
using GraphQL_Playground.Models;
using HotChocolate;
using HotChocolate.Data;
using HotChocolate.Types;
using System.Linq;

namespace GraphQL_Playground.GraphQL.Teams
{
    [ExtendObjectType(OperationTypeNames.Query)]
    public class TeamQueries
    {
        [UseDbContext(typeof(AppDbContext))]
        public IQueryable<Team> GetTeams([ScopedService] AppDbContext context)
        {
            return context.Teams;
        }
    }
}
