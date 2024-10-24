using System.Collections.Generic;

namespace JiraTicket
{
    public class Document
    {
        public List<ContentItem> Content { get; set; }
    }

    public class ContentItem
    {
        public string Type { get; set; }
        public List<Content> Content { get; set; } // Allows for both text and table rows
    }

    public class Content
    {
        public string Type { get; set; }
        public string Text { get; set; }
        public List<Mark> Marks { get; set; }
    }

    public class Mark
    {
        public string Type { get; set; }
    }

    public class TableAttrs
    {
        public bool IsNumberColumnEnabled { get; set; }
        public string Layout { get; set; }
        public string LocalId { get; set; }
    }
}
