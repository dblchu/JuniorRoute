﻿using System.Collections.Generic;

using Junior.Common;
using Junior.Route.Common;
using Junior.Route.Diagnostics.Web;
using Junior.Route.Routing;

namespace Junior.Route.Diagnostics
{
	public interface IDiagnosticConfiguration
	{
		IEnumerable<Routing.Route> GetRoutes(IGuidFactory guidFactory, IUrlResolver urlResolver, IHttpRuntime httpRuntime, string diagnosticsRelativeUrl);
		IEnumerable<DiagnosticViewLink> GetLinks(string diagnosticsUrl);
	}
}