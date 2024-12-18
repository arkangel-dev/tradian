﻿using System.Diagnostics.Contracts;

namespace TradianBackend.Database.Entities {
    public class Post {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Title { get; set; }
        public string Description { get; set; } 
        public string Body { get; set; }

        public bool IsSecured { get; set; }

    }
}
