using System;
using System.Collections.Generic;
using System.Text;

namespace SharpDock.Messages
{
    public class SendFileOptions
    {
        public string Event => "file";

        public string ContentType { get; set; }

        public string FileName { get; set; }

        public string Content { get; set; }

        public string Data { get; set; }
    }
}
