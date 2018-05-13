using System;

namespace SharpDock.Common.Models
{
    public class Subscription
    {
        public bool Trial { get; set; }

        public DateTime? TrialEnds { get; set; }

        public string Plan { get; set; }
    }
}
