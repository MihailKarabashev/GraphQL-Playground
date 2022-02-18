using GraphQL_Playground.Data;
using GraphQL_Playground.Models;
using HotChocolate;
using HotChocolate.Types;
using System.Linq;

namespace GraphQL_Playground.GraphQL.Players
{
    public class PlayerType : ObjectType<Player>
    {
        protected override void Configure(IObjectTypeDescriptor<Player> descriptor)
        {
            descriptor
                .Field(x => x.Team)
                .ResolveWith<Resolver>(r => r.GetTeam(default!, default!))
                .UseDbContext<AppDbContext>();
                //.UseFiltering();
        }

        private class Resolver
        {
            public Team GetTeam(Player player , [ScopedService] AppDbContext context)
            {
                return context.Teams.FirstOrDefault(x => x.Id == player.TeamId);
            } 
        }
    }
}
