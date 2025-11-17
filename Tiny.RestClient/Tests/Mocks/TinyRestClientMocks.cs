using System;
using Moq;

namespace Tiny.RestClient.Tests.Mocks
{
	public static class TinyRestClientMocks
	{
		public static Mock<ITinyRestClient> AlwaysReturning200() {
			Mock<ITinyRestClient> mock = new Mock<ITinyRestClient>();
			return mock;
		}
	}
}