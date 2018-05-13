using RestSharp;
using RestSharp.SnakeCaseSerializer;
using System;
using System.Collections.Generic;
using System.Text;

namespace SharpDock.Rest.Requests
{
    public class Request
    {
        private RestRequest _restRequest;

        public Request()
        {
            _restRequest = new RestRequest();
        }

        public Request(RestMethod method)
        {
            _restRequest = new RestRequest((Method)method);
        }

        public Request(string resource)
        {
            _restRequest = new RestRequest();
            Resource = resource;
        }

        public Request(string resource, RestMethod method)
        {
            _restRequest = new RestRequest((Method)method);
            Resource = resource;
        }

        public string Resource
        {
            get { return _restRequest.Resource; }
            set { _restRequest.Resource = value; }
        }

        public Request AddQueryParameter(string name, string value)
        {
            _restRequest.AddQueryParameter(name, value);
            return this;
        }

        public Request AddJsonParameter(string jsonBody)
        {
            _restRequest.AddParameter("application/json", jsonBody, ParameterType.RequestBody);
            return this;
        }

        internal RestRequest ConvertToRestRequest()
        {
            return _restRequest;
        }
    }
}
