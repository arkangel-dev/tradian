namespace TradianBackend.Database.Entities {
    public class FooterLink {
        public Guid Id { get; set; }
        public FooterSection Section { get; set; }
        public string Value { get; set; }
        public string Link { get; set; }
    }
}
