using SharpDock.Rest;
using SharpDock.Rest.Json;
using SharpDock.Rest.Requests;
using System.Collections.Generic;

namespace SharpDock.Users
{
    public class UserClient
    {
        private readonly IRestApi _restApi;

        public UserClient(IRestApi restApi)
        {
            _restApi = restApi;
        }

        /// <summary>
        /// List all users visible to the authenticated user, i.e. a combined set of users from all the organizations of the authenticated user.
        /// </summary>
        /// <returns>If the authenticated user is an admin in an organization, all of that organization’s users are returned. Otherwise, only users that are in the same flows as the authenticated user are returned.</returns>
        public List<User> GetAllUsers()
        {
            var request = new Request("users");
            var task = _restApi.ExecuteAsync<List<User>>(request);
            task.Wait();
            return task.Result;
        }

        /// <summary>
        /// List the users of a flow. The user must belong to the organization and have access to the flow.
        /// </summary>
        /// <param name="organization">The parameterized name of the organization.</param>
        /// <param name="flow">The parameterized name of the flow.</param>
        public List<User> GetAllFlowUsers(string organization, string flow)
        {
            var request = new Request($"flows/{organization}/{flow}/users");
            var task = _restApi.ExecuteAsync<List<User>>(request);
            task.Wait();
            return task.Result;
        }

        /// <summary>
        /// List the users of an organization.
        /// </summary>
        /// <param name="organization">The parameterized name of the organization.</param>
        public List<User> GetAllOrganizationUsers(string organization)
        {
            var request = new Request($"organizations/{organization}/users");
            var task = _restApi.ExecuteAsync<List<User>>(request);
            task.Wait();
            return task.Result;
        }

        /// <summary>
        /// Add a user to a flow. The authenticated user and the target user must be members of the organization.
        /// </summary>
        /// <param name="organization">The parameterized name of the organization.</param>
        /// <param name="flow">The parameterized name of the flow.</param>
        /// <param name="options"></param>
        public void AddUserToFlow(string organization, string flow, AddUserToFlowOptions options)
        {
            var request = new Request($"flows/{organization}/{flow}/users", RestMethod.POST);
            var jsonBody = JsonSerializer.SerializeObject(options, SerializationStrategy.SnakeCase);
            request.AddJsonParameter(jsonBody);

            var task = _restApi.ExecuteAsync<object>(request);
            task.Wait();
        }

        /// <summary>
        /// Get information about a single user. The requesting user must be belong to same organization as the target user.
        /// </summary>
        /// <param name="id">The ID of the user.</param>
        public User GetUser(string id)
        {
            var request = new Request($"users/{id}");
            var task = _restApi.ExecuteAsync<User>(request);
            task.Wait();
            return task.Result;
        }

        /// <summary>
        /// Update the user’s own information.
        /// </summary>
        /// <param name="id">The ID of the user to update.</param>
        /// <param name="options"></param>
        public void UpdateUser(string id, UpdateUserOptions options)
        {
            var request = new Request($"users/{id}", RestMethod.PUT);
            var jsonBody = JsonSerializer.SerializeObject(options, SerializationStrategy.SnakeCase);
            request.AddJsonParameter(jsonBody);
            var task = _restApi.ExecuteAsync<object>(request);
            task.Wait();
        }
    }
}
