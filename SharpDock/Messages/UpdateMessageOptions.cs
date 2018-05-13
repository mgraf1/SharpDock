using System.Collections.Generic;

namespace SharpDock.Messages
{
    public class UpdateMessageOptions
    {
        /// <summary>
        /// The message content. Updating content is only possible for your own messages of type message or comment.
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// Any existing tags that aren’t included in this parameter are removed from the message. As in the web UI, anyone can edit the tags of any message they can see.
        /// </summary>
        public IEnumerable<string> Tags { get; set; } 
    }
}
