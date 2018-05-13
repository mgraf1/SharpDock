using SharpDock.Flows;
using SharpDock.Invitations;
using SharpDock.Organizations;
using SharpDock.Rest;
using SharpDock.Users;

namespace SharpDock
{
    public static class ClientFactory
    {
        public static FlowClient CreateFlowClient(string username, string password)
        {
            var restApi = new UserAuthenticatedRestApi(username, password);
            return new FlowClient(restApi);
        }

        public static InvitationClient CreateInvitationClient(string username, string password)
        {
            var restApi = new UserAuthenticatedRestApi(username, password);
            return new InvitationClient(restApi);
        }

        public static OrganizationClient CreateOrganizationClient(string username, string password)
        {
            var restApi = new UserAuthenticatedRestApi(username, password);
            return new OrganizationClient(restApi);
        }

        public static UserClient CreateUserClient(string username, string password)
        {
            var restApi = new UserAuthenticatedRestApi(username, password);
            return new UserClient(restApi);
        }

        public static SharpDock.Messages.MessageClient CreateMessageClient(string username, string password)
        {
            var restApi = new UserAuthenticatedRestApi(username, password);
            return new Messages.MessageClient(restApi);
        }
    }
}
