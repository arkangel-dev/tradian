namespace TradianBackend.Database.Entities {
    public class Container {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string ContainerName { get; set; }   
        public string Status { get; set; }
    }
}
