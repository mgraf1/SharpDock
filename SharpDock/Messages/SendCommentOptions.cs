﻿using System.Collections.Generic;

namespace SharpDock.Messages
{
    public class SendCommentOptions
    {
        public string Event => "comment";

        /// <summary>
        /// Required. The message content. The format of the content depends on the event type.
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// List of tags to be added to the message.
        /// </summary>
        public List<string> Tags { get; set; }

        /// <summary>
        /// Name that appears as the message sender. This will change the message to an anonymous message, as if it was sent from the Push API.
        /// </summary>
        public string ExternalUserName { get; set; }

        /// <summary>
        /// An optional client-generated unique string identifier. It is the client’s responsibility to ensure the uniqueness (in the scope of the flow) of the uuid.
        /// </summary>
        public string Uuid { get; set; }

        /// <summary>
        /// Required for comments. The id of the commented parent message (which must not be a comment).
        /// </summary>
        public string Message { get; set; }
    }
}