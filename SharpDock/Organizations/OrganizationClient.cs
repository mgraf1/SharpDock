using System.Collections.Generic;
using SharpDock.Rest;
using SharpDock.Rest.Requests;
using SharpDock.Rest.Json;

namespace SharpDock.Organizations
{
    public class OrganizationClient
    {
        private readonly IRestApi _restApi;

        public OrganizationClient(IRestApi restApi)
        {
            _restApi = restApi;
        }

        /// <summary>
        /// List organizations of the authenticated user.
        /// </summary>
        /// <returns></returns>
        public List<Organization> GetAllOrganizations()
        {
            var request = new Request("organizations");
            var task = _restApi.ExecuteAsync<List<Organization>>(request);
            task.Wait();
            return task.Result;
        }

        /// <summary>
        /// Gets an information that the user is a member of.
        /// </summary>
        /// <param name="organization">The parameterized name of the organization</param>
        public Organization GetOrganization(string organization)
        {
            var request = new Request($"organizations/{organization}");
            var task = _restApi.ExecuteAsync<Organization>(request);
            task.Wait();
            return task.Result;
        }

        /// <summary>
        /// <para>Get information about an organization using the persistent organization id.</para>
        /// <para>The authenticated user must belong to the organization. </para>
        /// </summary>
        /// <param name="id">Organization resource id.</param>
        /// <returns>The returned data is identical to getting an organization using it’s parametrized name.</returns>
        public Organization GetOrganizationById(string id)
        {
            var request = new Request($"organizations/find");
            request.AddQueryParameter("id", id);
            var task = _restApi.ExecuteAsync<Organization>(request);
            task.Wait();
            return task.Result;
        }

        /// <summary>
        /// Update organization information. Only admins can modify organization information.
        /// </summary>
        /// <param name="organization">The parameterized name of the organization.</param>
        /// <param name="options">Options containing the fields to update.</param>
        /// <returns></returns>
        public Organization UpdateOrganization(string organization, UpdateOrganizationOptions options)
        {
            var request = new Request($"organizations/{organization}", RestMethod.PUT);
            string jsonBody = JsonSerializer.SerializeObject(options, SerializationStrategy.SnakeCase);
            request.AddJsonParameter(jsonBody);
            var task = _restApi.ExecuteAsync<Organization>(request);
            task.Wait();
            return task.Result;
        }

        /// <summary>
        /// <para>Removes a user from the specified organization. </para>
        /// <para>To remove a user from an organization, you will need to have administrator rights to the organization.</para>
        /// </summary>
        /// <param name="organization"></param>
        /// <param name="id"></param>
        public void RemoveUserFromOrganization(string organization, string id)
        {
            var request = new Request($"organizations/{organization}/users/{id}", RestMethod.DELETE);
            var task = _restApi.ExecuteAsync<object>(request);
            task.Wait();
        }
    }
}
