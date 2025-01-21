namespace Server.GraphQL.Types;

public record Item
{
    public string[] GetValues(
        [Parent] Item parent,
        string groupId
    ) => [];
}