using AutoMapper;
using GraphQL_Playground.GraphQL.Players;
using GraphQL_Playground.Models;

namespace GraphQL_Playground.Profiles
{
    public class ProfileMappings : Profile
    {
        public ProfileMappings()
        {
            CreateMap<AddPlayerInput, Player>();
        }
    }
}
