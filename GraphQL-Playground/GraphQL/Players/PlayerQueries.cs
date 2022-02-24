using GraphQL_Playground.Data;
using GraphQL_Playground.DataLoader.Player;
using GraphQL_Playground.GraphQL.FilterCustomizations;
using GraphQL_Playground.Models;
using HotChocolate;
using HotChocolate.Data;
using HotChocolate.Types;
using HotChocolate.Types.Relay;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GraphQL_Playground.GraphQL.Players
{

    [ExtendObjectType(OperationTypeNames.Query)]
    public class PlayerQueries
    {

        [UseDbContext(typeof(AppDbContext))]
        [UseProjection]
        [UseFiltering(typeof(PlayerFilterType))]
        [UseSorting]
        public IQueryable<Player> GetPlayers([ScopedService] AppDbContext context)
        {
            return context.Players;
        }

        public async Task<Player> GetPlayerByIdAsync(
            [ID(nameof(Player))] int id,
            PlayerByIdDataLoader playerByIdDataLoader,
            CancellationToken cancellationToken
            )
        {
            return await playerByIdDataLoader.LoadAsync(id, cancellationToken);
        }

    }
}
