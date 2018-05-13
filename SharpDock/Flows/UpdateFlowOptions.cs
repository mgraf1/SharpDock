using System;
using System.Collections.Generic;
using System.Text;

namespace SharpDock.Flows
{
    public class UpdateFlowOptions
    {
        private const int MaxNameLength = 100;

        private string _name;

        /// <summary>
        /// New name of the flow (max. 100 characters). Note that changing name does not change the flow’s email address or id.
        /// </summary>
        public string Name
        {
            get { return _name; }
            set
            {
                if (value.Length > MaxNameLength)
                {
                    throw new ArgumentOutOfRangeException("Flow name length cannot 100 characters");
                }

                _name = value;
            }
        }

        /// <summary>
        /// If true, if the user has not previously joined the flow, the user will automatically be added to the flow.
        /// </summary>
        public bool Open { get; set; }

        /// <summary>
        /// When set to true, the flow will disappear from users, users will no longer be able to send messages to it and users will not be able to join the flow. The flow can be considered to be archived.
        /// </summary>
        public bool Disabled { get; set; }

        /// <summary>
        /// How users see and access the flow. Possible values are invitation (the flow is invite-only – new members have to be explicitly invited or added by existing members), link (anyone can join the flow by using the join_url) or organization (in addition to using the link, anyone in the organization can join the flow.)
        /// </summary>
        public string AccessMode { get; set; } // TODO: use enum.

        public UpdateFlowOptions()
        {
            AccessMode = "organization";
        }
    }
}
