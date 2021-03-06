﻿using System;
using System.Text;

namespace Junior.Route.Routing.Responses.Audio
{
	public class BasicResponse : ImmutableResponse
	{
		public BasicResponse(Func<byte[]> content, Action<Response> configurationDelegate = null)
			: base(Response.OK().AudioBasic().Content(content), configurationDelegate)
		{
		}

		public BasicResponse(Func<byte[]> content, Encoding encoding, Action<Response> configurationDelegate = null)
			: base(Response.OK().AudioBasic().ContentEncoding(encoding).Content(content), configurationDelegate)
		{
		}

		public BasicResponse(byte[] content, Action<Response> configurationDelegate = null)
			: base(Response.OK().AudioBasic().Content(content), configurationDelegate)
		{
		}

		public BasicResponse(byte[] content, Encoding encoding, Action<Response> configurationDelegate = null)
			: base(Response.OK().AudioBasic().ContentEncoding(encoding).Content(content), configurationDelegate)
		{
		}
	}
}