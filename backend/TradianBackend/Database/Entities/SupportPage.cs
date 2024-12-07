using System.ComponentModel.DataAnnotations;

namespace TradianBackend.Database.Entities {
    public class Page {
        [Key]
        public string SlugId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Body { get; set; }
        public string Image { get; set; }
        public DateTime PostedDate { get; set; }
        public PageType Type { get; set; }
    }

    public enum PageType {
        SupportPage,
        NewsPost
    }
}
