namespace GraphQL_Playground.GraphQL.Players
{
    public record AddPlayerInput(
        string name,
        string nationality,
        string position,
        int teamId
        );
    
}
