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
            AddPlayerInput input,
            [ScopedService] AppDbContext context,
            CancellationToken cancellationToken
            )
        {
            //var player = new Player()
            //{
            //    Name = input.name,
            //    Nationality = input.nationality,
            //    Position = input.position,
            //    TeamId = input.teamId
            //};

            var player = _mapper.Map<Player>(input);

            context.Players.Add(player);
            await context.SaveChangesAsync();

            return new AddPlayerPlayload(player);
        }
    }
}
