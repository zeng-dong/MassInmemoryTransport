namespace MassInmemoryTransport.Messages.Contracts
{
    public class ItemCreated
    {
        public int Id { get; set; }
        public int ItemId { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
    }
}
