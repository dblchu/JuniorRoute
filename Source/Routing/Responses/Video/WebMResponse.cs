﻿using System;
using System.Text;

namespace Junior.Route.Routing.Responses.Video
{
	public class WebMResponse : ImmutableResponse
	{
		public WebMResponse(Func<byte[]> content, Action<Response> configurationDelegate = null)
			: base(Response.OK().VideoWebM().Content(content), configurationDelegate)
		{
		}

		public WebMResponse(Func<byte[]> content, Encoding encoding, Action<Response> configurationDelegate = null)
			: base(Response.OK().VideoWebM().ContentEncoding(encoding).Content(content), configurationDelegate)
		{
		}

		public WebMResponse(byte[] content, Action<Response> configurationDelegate = null)
			: base(Response.OK().VideoWebM().Content(content), configurationDelegate)
		{
		}

		public WebMResponse(byte[] content, Encoding encoding, Action<Response> configurationDelegate = null)
			: base(Response.OK().VideoWebM().ContentEncoding(encoding).Content(content), configurationDelegate)
		{
		}
	}
}