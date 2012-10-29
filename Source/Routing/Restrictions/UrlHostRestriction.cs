﻿using System;
using System.Diagnostics;
using System.Web;

using Junior.Common;

namespace Junior.Route.Routing.Restrictions
{
	[DebuggerDisplay("{DebuggerDisplay,nq}")]
	public class UrlHostRestriction : IRouteRestriction, IEquatable<UrlHostRestriction>
	{
		private readonly string _host;

		public UrlHostRestriction(string host)
		{
			host.ThrowIfNull("host");

			_host = host;
		}

		public string Host
		{
			get
			{
				return _host;
			}
		}

		// ReSharper disable UnusedMember.Local
		private string DebuggerDisplay
			// ReSharper restore UnusedMember.Local
		{
			get
			{
				return _host;
			}
		}

		public bool Equals(UrlHostRestriction other)
		{
			if (ReferenceEquals(null, other))
			{
				return false;
			}
			if (ReferenceEquals(this, other))
			{
				return true;
			}
			return String.Equals(_host, other._host);
		}

		public bool MatchesRequest(HttpRequestBase request)
		{
			request.ThrowIfNull("request");

			return String.Equals(_host, request.UrlReferrer.Host, StringComparison.OrdinalIgnoreCase);
		}

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj))
			{
				return false;
			}
			if (ReferenceEquals(this, obj))
			{
				return true;
			}
			if (obj.GetType() != GetType())
			{
				return false;
			}
			return Equals((UrlHostRestriction)obj);
		}

		public override int GetHashCode()
		{
			return (_host != null ? _host.GetHashCode() : 0);
		}
	}
}