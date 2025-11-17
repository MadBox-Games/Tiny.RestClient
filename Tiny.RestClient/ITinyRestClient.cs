using System.Net.Http;

namespace Tiny.RestClient
{
    /// <summary>
    /// Interface for <see cref="TinyRestClient"/>.
    /// </summary>
    public interface ITinyRestClient
    {
        /// <summary>
        /// Settings of <see cref="TinyRestClient"/>.
        /// </summary>
        RestClientSettings Settings { get; }

        /// <summary>
        /// Create a new request.
        /// </summary>
        /// <param name="httpMethod">The httpMethod.</param>
        /// <param name="route">The route.</param>
        /// <returns>The new request.</returns>
        IRequest NewRequest(HttpMethod httpMethod, string route = null);

        /// <summary>
        /// Create a new GET request.
        /// </summary>
        /// <param name="route">The route.</param>
        /// <returns>The new request.</returns>
        IRequest GetRequest(string route = null);

        /// <summary>
        /// Create a new POST request.
        /// </summary>
        /// <param name="route">The route.</param>
        /// <returns>The new request.</returns>
        IRequest PostRequest(string route = null);

        /// <summary>
        /// Create a new POST request.
        /// </summary>
        /// <param name="content">The content of the request.</param>
        /// <param name="formatter">The formatter use to serialize the content.</param>
        /// <param name="compression">Add compresion system use to compress content.</param>
        /// <returns>The new request.</returns>
        IParameterRequest PostRequest<TContent>(TContent content, IFormatter formatter = null, ICompression compression = null)
            where TContent : class;

        /// <summary>
        /// Create a new POST request.
        /// </summary>
        /// <param name="route">The route.</param>
        /// <param name="content">The content of the request.</param>
        /// <param name="formatter">The formatter use to serialize the content.</param>
        /// <param name="compression">Add compresion system use to compress content.</param>
        /// <returns>The new request.</returns>
        IParameterRequest PostRequest<TContent>(string route, TContent content, IFormatter formatter = null, ICompression compression = null)
            where TContent : class;

        /// <summary>
        /// Create a new PUT request.
        /// </summary>
        /// <param name="route">The route.</param>
        /// <returns>The new request.</returns>
        IRequest PutRequest(string route = null);

        /// <summary>
        /// Create a new PUT request.
        /// </summary>
        /// <param name="content">The content of the request.</param>
        /// <param name="formatter">The formatter use to serialize the content.</param>
        /// <param name="compression">Add compresion system use to compress content.</param>
        /// <returns>The new request.</returns>
        IParameterRequest PutRequest<TContent>(TContent content, IFormatter formatter = null, ICompression compression = null)
            where TContent : class;

        /// <summary>
        /// Create a new PUT request.
        /// </summary>
        /// <param name="route">The route.</param>
        /// <param name="content">The content of the request.</param>
        /// <param name="formatter">The formatter use to serialize the content.</param>
        /// <param name="compression">Add compresion system use to compress content.</param>
        /// <returns>The new request.</returns>
        IParameterRequest PutRequest<TContent>(string route, TContent content, IFormatter formatter = null, ICompression compression = null)
            where TContent : class;

        /// <summary>
        /// Create a new PATCH request.
        /// </summary>
        /// <param name="route">The route.</param>
        /// <returns>The new request.</returns>
        IRequest PatchRequest(string route = null);

        /// <summary>
        /// Create a new PATCH request.
        /// </summary>
        /// <param name="content">The content of the request.</param>
        /// <param name="serializer">The serializer use to serialize it.</param>
        /// <param name="compression">Add compresion system use to compress content.</param>
        /// <returns>The new request.</returns>
        IParameterRequest PatchRequest<TContent>(TContent content, IFormatter serializer = null, ICompression compression = null)
            where TContent : class;

        /// <summary>
        /// Create a new PATCH request.
        /// </summary>
        /// <param name="route">The route.</param>
        /// <param name="content">The content of the request.</param>
        /// <param name="serializer">The serializer use to serialize it.</param>
        /// <param name="compression">Add compresion system use ton compress content.</param>
        /// <returns>The new request.</returns>
        IParameterRequest PatchRequest<TContent>(string route, TContent content, IFormatter serializer = null, ICompression compression = null)
            where TContent : class;

        /// <summary>
        /// Create a new DELETE request.
        /// </summary>
        /// <param name="route">The route.</param>
        /// <returns>The new request.</returns>
        IRequest DeleteRequest(string route = null);
    }
}
