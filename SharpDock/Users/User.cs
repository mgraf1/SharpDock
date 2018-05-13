namespace SharpDock.Users
{
    public class User
    {
        public string Id { get; set; }

        public string Nick { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Avatar { get; set; }

        public string Status { get; set; }

        public bool Disabled { get; set; }

        public long LastActivity { get; set; }

        public long LastPing { get; set; }

        public string Website { get; set; }

        public bool TeamNotifications { get; set; }

        public bool InFlow { get; set; }
    }
}
