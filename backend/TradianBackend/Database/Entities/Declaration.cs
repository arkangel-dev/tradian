namespace TradianBackend.Database.Entities {
    public class Declaration {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string CNumber { get; set; } 
        public string RNumber { get; set; }
        public string Status { get; set; }
    }
}
