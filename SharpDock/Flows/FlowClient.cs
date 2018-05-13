using SharpDock.Rest;
using SharpDock.Rest.Json;
using SharpDock.Rest.Requests;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SharpDock.Flows
{
    public class FlowClient
    {
        private readonly IRestApi _restApi;

        public FlowClient(IRestApi restApi)
        {
            _restApi = restApi;
        }

        /// <summary>
        /// Lists the flows that the authenticated user is a member of.
        /// </summary>
        public async Task<IList<Flow>> GetSubscribedFlowsAsync()
        {
            var request = new Request("flows");
            return await _restApi.ExecuteAsync<List<Flow>>(request);
        }

        /// <summary>
        /// Lists the flows that the authenticated user has access to or can join.
        /// </summary>
        public async Task<IList<Flow>> GetAllFlowsAsync()
        {
            var request = new Request("flows/all");
            return await _restApi.ExecuteAsync<List<Flow>>(request);
        }

        /// <summary>
        /// Gets a flow that also contains user details.
        /// </summary>
        /// <param name="organization">The parameterized name of the organization.</param>
        /// <param name="flow">The parameterized name of the flow.</param>
        public async Task<Flow> GetFlowAsync(string organization, string flow)
        {
            var request = new Request($"flows/{organization}/{flow}");
            return await _restApi.ExecuteAsync<Flow>(request);
        }

        /// <summary>
        /// Get a single flow using the flow’s id. The returned data is identical to getting a flow with the flow’s URL.
        /// </summary>
        /// <param name="id">The id of the flow.</param>
        public async Task<Flow> GetFlowByIdAsync(string id)
        {
            var request = new Request($"flows/find");
            request.AddQueryParameter("id", id);
            return await _restApi.ExecuteAsync<Flow>(request);
        }

        /// <summary>
        /// Create a flow for the specified organization.
        /// </summary>
        /// <param name="organization">The parameterized name of the organization.</param>
        /// <param name="options"></param>
        /// <returns>The newly created flow.</returns>
        public async Task<Flow> CreateFlowAsync(string organization, CreateFlowOptions options)
        {
            var request = new Request($"flows/{organization}", RestMethod.POST);
            var jsonBody = JsonSerializer.SerializeObject(options, SerializationStrategy.SnakeCase);
            request.AddJsonParameter(jsonBody);
            return await _restApi.ExecuteAsync<Flow>(request);
        }

        /// <summary>
        /// Update flow information. Only adminstrators can modify certain parts of the flow metadata.
        /// </summary>
        /// <param name="organization">The parameterized name of the organization.</param>
        /// <param name="flow">The parameterized name of the flow.</param>
        /// <param name="options"></param>
        /// <returns></returns>
        public async Task<Flow> UpdateFlowAsync(string organization, string flow, UpdateFlowOptions options)
        {
            var request = new Request($"flows/{organization}/{flow}", RestMethod.PUT);
            var jsonBody = JsonSerializer.SerializeObject(options, SerializationStrategy.SnakeCase);
            request.AddJsonParameter(jsonBody);
            return await _restApi.ExecuteAsync<Flow>(request);
        }
    }
}
