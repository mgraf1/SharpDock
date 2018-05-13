using System;
using System.Collections.Generic;
using System.Text;

namespace SharpDock.Invitations
{
    public class CreateInvitationOptions
    {
        /// <summary>
        /// <bold>Required</bold> The email address to invite.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// An optional message that is added to the invitation.
        /// </summary>
        public string Message { get; set; }
    }
}
