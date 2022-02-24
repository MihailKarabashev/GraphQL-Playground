using GraphQL_Playground.Models;
using HotChocolate.Data.Filters;

namespace GraphQL_Playground.GraphQL.FilterCustomizations
{
    public class PlayerFilterType : FilterInputType<Player>
    {
        protected override void Configure(IFilterInputTypeDescriptor<Player> descriptor)
        {
            descriptor
                .BindFieldsExplicitly()
                .Field(x => x.Name)
                .Type<PlayerOperationFilterInput>();

            descriptor.Ignore(x => x.Position);
        }
    }

    public class PlayerOperationFilterInput : StringOperationFilterInputType
    {
        protected override void Configure(IFilterInputTypeDescriptor descriptor)
        {
            descriptor
                .Operation(DefaultFilterOperations.Equals)
                .Operation(DefaultFilterOperations.NotEquals);
            //.Operation(DefaultFilterOperations.Contains)
            //.Operation(DefaultFilterOperations.NotContains);

            base.Configure(descriptor);
        }
    }
}
