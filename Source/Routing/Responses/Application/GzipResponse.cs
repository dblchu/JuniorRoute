using System;
using System.Text;

namespace Junior.Route.Routing.Responses.Application
{
	public class GzipResponse : ImmutableResponse
	{
		public GzipResponse(Func<byte[]> content, Action<Response> configurationDelegate = null)
			: base(Response.OK().ApplicationGzip().Content(content), configurationDelegate)
		{
		}

		public GzipResponse(Func<byte[]> content, Encoding encoding, Action<Response> configurationDelegate = null)
			: base(Response.OK().ApplicationGzip().ContentEncoding(encoding).Content(content), configurationDelegate)
		{
		}

		public GzipResponse(byte[] content, Action<Response> configurationDelegate = null)
			: base(Response.OK().ApplicationGzip().Content(content), configurationDelegate)
		{
		}

		public GzipResponse(byte[] content, Encoding encoding, Action<Response> configurationDelegate = null)
			: base(Response.OK().ApplicationGzip().ContentEncoding(encoding).Content(content), configurationDelegate)
		{
		}
	}
}