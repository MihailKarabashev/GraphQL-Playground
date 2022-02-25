using AppAny.HotChocolate.FluentValidation;
using AutoMapper;
using GraphQL_Playground.Data;
using GraphQL_Playground.Models;
using HotChocolate;
using HotChocolate.Data;
using HotChocolate.Types;
using System.Threading;
using System.Threading.Tasks;

namespace GraphQL_Playground.GraphQL.Players
{

    [ExtendObjectType(OperationTypeNames.Mutation)]
    public class PlayerMutations
    {
        private readonly IMapper _mapper;

        public PlayerMutations(IMapper mapper)
        {
            _mapper = mapper;
        }

        [UseDbContext(typeof(AppDbContext))]
        public async Task<AddPlayerPlayload> AddPlayer(
            [UseFluentValidation] AddPlayerInput input,
            [ScopedService] AppDbContext context,
            CancellationToken cancellationToken
            )
        {
            var player = _mapper.Map<Player>(input);

            context.Players.Add(player);
            await context.SaveChangesAsync(cancellationToken);

            return new AddPlayerPlayload(player);
        }

        //validation for update
        //if (input is null)
        //{
        //    throw new GraphQLException(new Error("Your input is empty", player_not found));
        //}

    }
}
