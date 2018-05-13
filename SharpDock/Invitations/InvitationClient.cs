using SharpDock.Rest;
using SharpDock.Rest.Json;
using SharpDock.Rest.Requests;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SharpDock.Invitations
{
    public class InvitationClient
    {
        private readonly IRestApi _restApi;

        public InvitationClient(IRestApi restApi)
        {
            _restApi = restApi;
        }

        /// <summary>
        /// Lists the open (not yet accepted) invitations of a flow.
        /// </summary>
        /// <param name="organization">The parameterized name of the organization.</param>
        /// <param name="flow">The parameterized name of the flow.</param>
        public async Task<IList<Invitation>> GetInvitationsAsync(string organization, string flow)
        {
            var request = new Request($"flows/{organization}/{flow}/invitations");
            return await _restApi.ExecuteAsync<List<Invitation>>(request);
        }

        /// <summary>
        /// Get a single invitation. Shows accepted invitations as well. Data format and fields are the same as in invitations listing.
        /// </summary>
        /// <param name="organization">The parameterized name of the organization.</param>
        /// <param name="flow">The parameterized name of the flow.</param>
        /// <param name="id">The ID of the invitation.</param>
        public async Task<Invitation> GetInvitationAsync(string organization, string flow, string id)
        {
            var request = new Request($"flows/{organization}/{flow}/invitations/{id}");
            return await _restApi.ExecuteAsync<Invitation>(request);
        }

        /// <summary>
        /// Can be used to create or resend invitation. To resend an invitation, use the same email address that was originally used.
        /// </summary>
        /// <param name="organization">The parameterized name of the organization.</param>
        /// <param name="flow">The parameterized name of the flow.</param>
        /// <param name="options"></param>
        public async Task<Invitation> CreateInvitationAsync(string organization, string flow, CreateInvitationOptions options)
        {
            var request = new Request($"flows/{organization}/{flow}/invitations", RestMethod.POST);
            var jsonBody = JsonSerializer.SerializeObject(options, SerializationStrategy.SnakeCase);
            request.AddJsonParameter(jsonBody);
            return await _restApi.ExecuteAsync<Invitation>(request);
        }

        /// <summary>
        /// Deletes a single invitation. Only pending invitations can be deleted. Used to decline or cancel an invitation.
        /// </summary>
        /// <param name="organization">The parameterized name of the organization.</param>
        /// <param name="flow">The parameterized name of the flow.</param>
        /// <param name="id">The ID of the invitation.</param>
        public async Task DeleteInvitationAsync(string organization, string flow, string id)
        {
            var request = new Request($"flows/{organization}/{flow}/invitations/{id}", RestMethod.DELETE);
            await _restApi.ExecuteAsync<object>(request);
        }
    }
}
