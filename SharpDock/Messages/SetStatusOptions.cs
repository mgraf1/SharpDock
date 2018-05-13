using System;
using System.Collections.Generic;
using System.Text;

namespace SharpDock.Messages
{
    public class SetStatusOptions
    {
        public string Event => "status";

        /// <summary>
        /// Required. The message content. The format of the content depends on the event type.
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// An optional client-generated unique string identifier. It is the client’s responsibility to ensure the uniqueness (in the scope of the flow) of the uuid.
        /// </summary>
        public string Uuid { get; set; }
    }
}
