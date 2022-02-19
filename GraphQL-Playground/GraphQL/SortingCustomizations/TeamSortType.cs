using GraphQL_Playground.Models;
using HotChocolate.Data.Sorting;

namespace GraphQL_Playground.GraphQL.SortingCustomizations
{
    public class TeamSortType : SortInputType<Team>
    {
        protected override void Configure(ISortInputTypeDescriptor<Team> descriptor)
        {
            descriptor.BindFieldsExplicitly();
            descriptor.Field(f => f.Name).Type<AscOnlySortEnumType>();
        }
    }

    public class AscOnlySortEnumType : DefaultSortEnumType
    {
        protected override void Configure(ISortEnumTypeDescriptor descriptor)
        {
            descriptor.Operation(DefaultSortOperations.Ascending);
        }
    }

}
