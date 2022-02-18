using GraphQL_Playground.Models;
using HotChocolate.Data.Filters;

namespace GraphQL_Playground.GraphQL.FilterCustomizations
{
    public class TeamFilterType : FilterInputType<Team>
    {
        protected override void Configure(IFilterInputTypeDescriptor<Team> descriptor)
        {
            descriptor.BindFieldsExplicitly();

            descriptor.Field(x => x.Name).Type<CustomStringLimitarionInput>();
        }
       
    }

    public class CustomStringLimitarionInput : StringOperationFilterInputType
    {
        protected override void Configure(IFilterInputTypeDescriptor descriptor)
        {
            descriptor.Operation(DefaultFilterOperations.StartsWith);
        }
    }
}
