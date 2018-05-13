using RestSharp;
using SharpDock.Rest.Requests;
using System.Threading.Tasks;

namespace SharpDock.Rest
{
    public interface IRestApi
    {
        Task<T> ExecuteAsync<T>(Request request) where T : new();
    }
}
