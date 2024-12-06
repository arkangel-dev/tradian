namespace TradianBackend.Database.Entities {
    public class FooterSection {
        public Guid Id { get; set; }
        public string Section { get; set; }
        public List<FooterLink> Links { get; set; }

    }
}
