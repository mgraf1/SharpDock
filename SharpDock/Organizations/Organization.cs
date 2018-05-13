using SharpDock.Common.Models;
using SharpDock.Users;
using System.Collections.Generic;

namespace SharpDock.Organizations
{
    /// <summary>
    /// An organization in CA Flowdock represents the organization/company account. Users can belong to several organizations.
    /// </summary>
    public class Organization
    {
        /// <summary>
        /// Organization resource id.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// The organization’s display name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Organization subdomain / alternative resource id (can be changed).
        /// </summary>
        public string ParameterizedName { get; set; }

        /// <summary>
        /// Maximum number of users with the current subscription.
        /// </summary>
        public int UserLimit { get; set; }

        public int UserCount { get; set; }

        public bool Active { get; set; }

        public bool FlowAdmins { get; set; }

        public string Url { get; set; }

        /// <summary>
        /// Information about the CA Flowdock subscription of the organization. An object that contains a boolean trial and either trial_ends or billing_date (depending on the value of trial).
        /// </summary>
        public Subscription Subscription { get; set; }

        public List<User> Users { get; set; }
    }
}
