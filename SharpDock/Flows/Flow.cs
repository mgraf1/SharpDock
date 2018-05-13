using SharpDock.Organizations;
using SharpDock.Users;
using System.Collections.Generic;

namespace SharpDock.Flows
{
    public class Flow
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string ParameterizedName { get; set; }

        public Organization Organization { get; set; }

        public int UnreadMentions { get; set; }

        public bool Open { get; set; }

        public bool Joined { get; set; }

        public string Url { get; set; }

        public string WebUrl { get; set; }

        public string JoinUrl { get; set; }

        public string AccessMode { get; set; }

        public List<User> Users { get; set; }
    }
}
