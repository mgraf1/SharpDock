using System;
using System.Collections.Generic;
using System.Text;

namespace SharpDock.Messages
{
    public class Message
    {
        public string Id { get; set; }

        public string Event { get; set; }

        public string Content { get; set; }

        public List<string> Tags { get; set; }

        public string User { get; set; }

        public string Uuid { get; set; }

        public long Sent { get; set; }

        public string App { get; set; }

        public List<string> Attachments { get; set; }
    }
}
