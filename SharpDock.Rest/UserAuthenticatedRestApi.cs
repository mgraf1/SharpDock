using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using RestSharp.Authenticators;
using SharpDock.Rest.Requests;
using SharpDock.Rest.Exceptions;

namespace SharpDock.Rest
{
    public class UserAuthenticatedRestApi : IRestApi
    {
        private const string BaseUrl = "https://api.flowdock.com";

        private readonly string _username;
        private readonly string _password;

        public UserAuthenticatedRestApi(string username, string password)
        {
            _username = username;
            _password = password;
        }

        public async Task<T> ExecuteAsync<T>(Request request) where T : new()
        {
            var restRequest = request.ConvertToRestRequest();
            return await ExecuteAsync<T>(restRequest);
        }

        private async Task<T> ExecuteAsync<T>(IRestRequest request) where T : new()
        {
            var client = new RestClient();
            client.BaseUrl = new System.Uri(BaseUrl);
            client.Authenticator = new HttpBasicAuthenticator(_username, _password);

            var taskCompletionSource = new TaskCompletionSource<T>();

            client.ExecuteAsync<T>(request, (response) =>
            {
                if (!response.StatusCode.IsSuccessStatusCode())
                {
                    var exception = new RequestFailureException($"{response.StatusCode} - {response.Content}");
                    taskCompletionSource.SetException(exception);
                }
                else if (response.ErrorException != null)
                {
                    const string message = "Error retrieving response.  Check inner details for more info.";
                    var exception = new RequestFailureException(message, response.ErrorException);
                    taskCompletionSource.SetException(exception);
                }
                else
                {
                    taskCompletionSource.SetResult(response.Data);
                }

            });

            return await taskCompletionSource.Task;
        }
    }
}
