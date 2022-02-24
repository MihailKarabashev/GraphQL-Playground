using GraphQL_Playground.Models;
using HotChocolate.Data.Filters;

namespace GraphQL_Playground.GraphQL.FilterCustomizations
{
    public class TeamFilterType : FilterInputType<Team>
    {
        protected override void Configure(IFilterInputTypeDescriptor<Team> descriptor)
        {
            descriptor.AllowAnd(true).AllowOr(false);
        }
    }
}
