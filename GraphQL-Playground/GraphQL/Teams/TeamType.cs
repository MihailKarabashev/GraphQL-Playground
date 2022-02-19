using GraphQL_Playground.Data;
using GraphQL_Playground.GraphQL.FilterCustomizations;
using GraphQL_Playground.Models;
using HotChocolate;
using HotChocolate.Types;
using System.Linq;

namespace GraphQL_Playground.GraphQL
{
    public class TeamType : ObjectType<Team>
    {
        protected override void Configure(IObjectTypeDescriptor<Team> descriptor)
        {
            descriptor
                 .Field(x => x.Country).Ignore();

            descriptor
                .Field(x => x.Players)
                .ResolveWith<Resolver>(r => r.GetPlayers(default!, default!))
                .UseDbContext<AppDbContext>();
                //.UseFiltering<TeamFilterType>();
        }

        private class Resolver 
        {
            public IQueryable<Player> GetPlayers(Team team , [ScopedService] AppDbContext context)
            {
                return context.Players.Where(x => x.TeamId == team.Id);
            }
        }

    }
}
