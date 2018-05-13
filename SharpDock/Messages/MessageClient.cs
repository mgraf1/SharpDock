using SharpDock.Rest;
using SharpDock.Rest.Requests;
using SharpDock.Rest.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace SharpDock.Messages
{
    /// <summary>
    /// There are several different Message Types: in addition to sending plain chat messages, you can post content to the team inbox, upload files and set the user’s status. Messages are a sub-resource of flows, meaning they should always be accessed in a flow’s context.
    /// </summary>
    public class MessageClient
    {
        private readonly IRestApi _restApi;

        public MessageClient(IRestApi restApi)
        {
            _restApi = restApi;
        }

        /// <summary>
        /// Send a chat message.
        /// </summary>
        /// <param name="organization">The parameterized name of the organization.</param>
        /// <param name="flow">The parameterized name of the flow.</param>
        /// <param name="options"></param>
        public Message SendMessage(string organization, string flow, SendMessageOptions options)
        {
            var request = new Request($"flows/{organization}/{flow}/messages", RestMethod.POST);
            var jsonBody = JsonSerializer.SerializeObject(options, SerializationStrategy.SnakeCaseIgnoreNull);
            request.AddJsonParameter(jsonBody);

            var task = _restApi.ExecuteAsync<Message>(request);
            task.Wait();
            return task.Result;
        }

        /// <summary>
        /// Comment in a thread.
        /// </summary>
        /// <param name="organization">The parameterized name of the organization.</param>
        /// <param name="flow">The parameterized name of the flow.</param>
        /// <param name="options"></param>
        public Message SendComment(string organization, string flow, SendCommentOptions options)
        {
            var request = new Request($"flows/{organization}/{flow}/messages/{options.Message}/comments", RestMethod.POST);
            var jsonBody = JsonSerializer.SerializeObject(options, SerializationStrategy.SnakeCaseIgnoreNull);
            request.AddJsonParameter(jsonBody);

            var task = _restApi.ExecuteAsync<Message>(request);
            task.Wait();
            return task.Result;
        }

        /// <summary>
        /// Set a user’s status.
        /// </summary>
        /// <param name="organization">The parameterized name of the organization.</param>
        /// <param name="flow">The parameterized name of the flow.</param>
        /// <param name="options"></param>
        public Message SetStatus(string organization, string flow, SetStatusOptions options)
        {
            var request = new Request($"flows/{organization}/{flow}/messages", RestMethod.POST);
            var jsonBody = JsonSerializer.SerializeObject(options, SerializationStrategy.SnakeCaseIgnoreNull);
            request.AddJsonParameter(jsonBody);

            var task = _restApi.ExecuteAsync<Message>(request);
            task.Wait();
            return task.Result;
        }

        /// <summary>
        /// Lists messages from a flow, filtered by parameters.
        /// </summary>
        /// <param name="organization">The parameterized name of the organization.</param>
        /// <param name="flow">The parameterized name of the flow.</param>
        public List<Message> GetMessages(string organization, string flow)
        {
            var request = new Request($"flows/{organization}/{flow}/messages");
            var task = _restApi.ExecuteAsync<List<Message>>(request);
            task.Wait();
            return task.Result;
        }

        /// <summary>
        /// Retrieve a message with the specified id.
        /// </summary>
        /// <param name="organization">The parameterized name of the organization.</param>
        /// <param name="flow">The parameterized name of the flow.</param>
        /// <param name="id">The id of the message to retrieve</param>
        /// <returns></returns>
        public Message GetMessage(string organization, string flow, string id)
        {
            var request = new Request($"flows/{organization}/{flow}/messages/{id}");
            var task = _restApi.ExecuteAsync<Message>(request);
            task.Wait();
            return task.Result;
        }

        /// <summary>
        /// Updates a message with the specified id. Note: only certain types and certain content can be edited, as defined by the message event type.
        /// </summary>
        /// <param name="organization">The parameterized name of the organization.</param>
        /// <param name="flow">The parameterized name of the flow.</param>
        /// <param name="id">The id of the message to retrieve</param>
        /// <param name="options"></param>
        public void UpdateMessage(string organization, string flow, string id, UpdateMessageOptions options)
        {
            var request = new Request($"flows/{organization}/{flow}/messages/{id}", RestMethod.PUT);
            var jsonBody = JsonSerializer.SerializeObject(options, SerializationStrategy.SnakeCaseIgnoreNull);
            request.AddJsonParameter(jsonBody);

            var task =_restApi.ExecuteAsync<object>(request);
            task.Wait();
        }

        /// <summary>
        /// Deletes the message with the specified id.
        /// </summary>
        /// <param name="organization">The parameterized name of the organization.</param>
        /// <param name="flow">The parameterized name of the flow.</param>
        /// <param name="id">The id of the message to retrieve</param>
        public void DeleteMessage(string organization, string flow, string id)
        {
            var request = new Request($"flows/{organization}/{flow}/messages/{id}", RestMethod.DELETE);
            var task = _restApi.ExecuteAsync<Message>(request);
            task.Wait();
        }
    }
}
