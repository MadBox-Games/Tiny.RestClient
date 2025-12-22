using System;
using System.Net;
using System.Net.Http;
using System.Threading;
using Moq;

namespace Tiny.RestClient.Tests.Mocks
{
	public static class TinyRestClientMocks
	{
		/// <summary>
		/// Creates a mock that returns a successful HTTP 200 response with the specified JSON content.
		/// </summary>
		/// <param name="jsonResponse">The JSON response content to return</param>
		public static Mock<ITinyRestClient> ReturningSuccess(string jsonResponse = "")
		{
			Mock<ITinyRestClient> mockClient  = new Mock<ITinyRestClient>();
			Mock<IRequest>        mockRequest = new Mock<IRequest>();

			HttpResponseMessage successResponse = new HttpResponseMessage(HttpStatusCode.OK);
			successResponse.Content = new StringContent(jsonResponse);

			mockRequest.Setup(r => r.AddQueryParameter(It.IsAny<string>(), It.IsAny<string>()))
				.Returns(mockRequest.Object);
			mockRequest.Setup(r => r.AddFormParameter(It.IsAny<string>(), It.IsAny<string>()))
				.Returns(mockRequest.Object);
			mockRequest.Setup(r => r.ExecuteAsHttpResponseMessageAsync(It.IsAny<CancellationToken>()))
				.ReturnsAsync(successResponse);

			mockClient.Setup(c => c.PostRequest(It.IsAny<string>()))
				.Returns(mockRequest.Object);

			return mockClient;
		}

		/// <summary>
		/// Creates a mock that returns an HTTP error with the specified status code.
		/// </summary>
		/// <param name="statusCode">The HTTP status code to return</param>
		/// <param name="errorMessage">Optional error message content</param>
		public static Mock<ITinyRestClient> ReturningHttpError(HttpStatusCode statusCode, string errorMessage = "")
		{
			Mock<ITinyRestClient> mockClient  = new Mock<ITinyRestClient>();
			Mock<IRequest>        mockRequest = new Mock<IRequest>();

			HttpResponseMessage errorResponse = new HttpResponseMessage(statusCode);
			errorResponse.Content = new StringContent(errorMessage);

			mockRequest.Setup(r => r.AddFormParameter(It.IsAny<string>(), It.IsAny<string>()))
				.Returns(mockRequest.Object);
			mockRequest.Setup(r => r.ExecuteAsHttpResponseMessageAsync(It.IsAny<CancellationToken>()))
				.ReturnsAsync(errorResponse);

			mockClient.Setup(c => c.PostRequest(It.IsAny<string>()))
				.Returns(mockRequest.Object);

			return mockClient;
		}

		/// <summary>
		/// Creates a mock that throws an exception during request execution.
		/// </summary>
		/// <param name="exception">The exception to throw</param>
		public static Mock<ITinyRestClient> ThrowingException(Exception exception)
		{
			Mock<ITinyRestClient> mockClient  = new Mock<ITinyRestClient>();
			Mock<IRequest>        mockRequest = new Mock<IRequest>();

			mockRequest.Setup(r => r.AddFormParameter(It.IsAny<string>(), It.IsAny<string>()))
				.Returns(mockRequest.Object);
			mockRequest.Setup(r => r.ExecuteAsHttpResponseMessageAsync(It.IsAny<CancellationToken>()))
				.ThrowsAsync(exception);

			mockClient.Setup(c => c.PostRequest(It.IsAny<string>()))
				.Returns(mockRequest.Object);

			return mockClient;
		}
	}
}