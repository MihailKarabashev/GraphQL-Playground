using GraphQL_Playground.Data;
using GraphQL_Playground.GraphQL.FilterCustomizations;
using GraphQL_Playground.GraphQL.SortingCustomizations;
using GraphQL_Playground.Models;
using HotChocolate;
using HotChocolate.Data;
using HotChocolate.Types;
using HotChocolate.Types.Relay;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GraphQL_Playground.GraphQL.Teams
{
    [ExtendObjectType(OperationTypeNames.Query)]
    public class TeamQueries
    {
        [UseDbContext(typeof(AppDbContext))]
        [UseProjection]
        [UseFiltering(typeof(TeamFilterType))]
        [UseSorting(typeof(TeamSortType))]
        public IQueryable<Team> GetTeams([ScopedService] AppDbContext context)
        {
            return context.Teams;
        }

        public async Task<Team> GetTeamByIdAsync(
            [ID(nameof(Team))] int id,
            TeamByIdDataLoader teamLoader,
            CancellationToken cancellationToken
            )
        {
            return await teamLoader.LoadAsync(id, cancellationToken);
        }

       //use group data loader for fetching multiple entities
    }
}
