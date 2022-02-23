using HotChocolate.Types;

namespace GraphQL_Playground.GraphQL.Teams
{
    public class AddTeamInputType : InputObjectType<AddTeamInput>
    {
        protected override void Configure(IInputObjectTypeDescriptor<AddTeamInput> descriptor)
        {
            descriptor.
                Field(x => x.name)
                .Description("Represents the name for the team");
        }
    }
}
