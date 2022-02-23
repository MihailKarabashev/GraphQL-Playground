using GraphQL_Playground.Data;
using GraphQL_Playground.GraphQL.FilterCustomizations;
using GraphQL_Playground.GraphQL.Players;
using GraphQL_Playground.Models;
using HotChocolate;
using HotChocolate.Types;
using System.Collections.Generic;
using System.Linq;

namespace GraphQL_Playground.GraphQL
{
    public class TeamType : ObjectType<Team>
    {
        //protected override void Configure(IObjectTypeDescriptor<Team> descriptor)
        //{
        //    descriptor
        //         .Field(x => x.Country).Ignore();

        //    descriptor.Field(f => f.Id).Type<IntType>().Name("Id");
        //    descriptor.Field(f => f.Name).Type<StringType>().Name("Name");
        //    descriptor.Field(f => f.League).Type<StringType>().Name("League");
        //    descriptor.Field(f => f.Players).Type<ListType<PlayerType>>().Name("Players");

        //    descriptor
        //        .Field(x => x.Players)
        //        .ResolveWith<Resolver>(r => r.GetPlayers(default!, default!))
        //        .UseDbContext<AppDbContext>()
        //        .UseProjection();
        //        .UseFiltering<TeamFilterType>();
        //}

        private class Resolver 
        {
            public IQueryable<Player> GetPlayers(Team team , [ScopedService] AppDbContext context)
            {
                return context.Players.Where(x => x.TeamId == team.Id);
            }

            //public List<Team> GetTeam([ScopedService] AppDbContext context)
            //{
            //    return context.Teams.ToList();
            //}
        }

    }
}
