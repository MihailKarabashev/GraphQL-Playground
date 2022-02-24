using GraphQL_Playground.Data;
using GraphQL_Playground.GraphQL.FilterCustomizations;
using GraphQL_Playground.Models;
using HotChocolate;
using HotChocolate.Data;
using HotChocolate.Types;
using System.Linq;

namespace GraphQL_Playground.GraphQL.Players
{

    [ExtendObjectType(OperationTypeNames.Query)]
    public class PlayerQueries
    {

        [UseDbContext(typeof(AppDbContext))]
        [UseFiltering(typeof(PlayerFilterType))]
        [UseSorting]
        public IQueryable<Player> GetPlayers([ScopedService] AppDbContext context)
        {
            return context.Players;
        }

    }
}
