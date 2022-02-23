using GraphQL_Playground.Data;
using GraphQL_Playground.Models;
using HotChocolate;
using HotChocolate.Data;
using HotChocolate.Types;
using System.Threading;
using System.Threading.Tasks;

namespace GraphQL_Playground.GraphQL.Teams
{
    [ExtendObjectType(OperationTypeNames.Mutation)]
    public class TeamMutations
    {
        [UseDbContext(typeof(AppDbContext))]
        public async Task<AddTeamPlayload> AddTeamAsync(
            AddTeamInput input,
            [ScopedService] AppDbContext context,
            CancellationToken cancellationToken
            )
        {
            var team = new Team() { Name = input.name, League = input.league, Country = input.country };

            context.Teams.Add(team);
            await context.SaveChangesAsync(cancellationToken);

            return new AddTeamPlayload(team);
        }
    }
}
