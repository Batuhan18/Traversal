namespace Traversal.CQRS.Commands.DestinationCommands
{
    public class RemoveDestinationCommands
    {
        public RemoveDestinationCommands(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
