﻿using System;

using Junior.Common;
using Junior.Route.AutoRouting.Containers;
using Junior.Route.Routing;

namespace Junior.Route.AutoRouting.RestrictionMappers.Attributes
{
	[AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = false)]
	public class UrlRelativePathAttribute : RestrictionAttribute
	{
		private readonly RequestValueComparer? _comparer;
		private readonly string[] _relativePaths;

		public UrlRelativePathAttribute(string relativePath, RequestValueComparer comparer = RequestValueComparer.CaseInsensitivePlain)
		{
			relativePath.ThrowIfNull("relativePath");

			_relativePaths = new[] { relativePath };
			_comparer = comparer;
		}

		public UrlRelativePathAttribute(params string[] relativePaths)
		{
			relativePaths.ThrowIfNull("relativePaths");

			_relativePaths = relativePaths;
		}

		public override void Map(Routing.Route route, IContainer container)
		{
			route.ThrowIfNull("route");
			container.ThrowIfNull("container");

			var httpRuntime = container.GetInstance<IHttpRuntime>();

			if (_comparer != null)
			{
				route.RestrictByUrlRelativePaths(_relativePaths, GetComparer(_comparer.Value), httpRuntime);
			}
			else
			{
				route.RestrictByUrlRelativePaths(_relativePaths, httpRuntime);
			}
		}
	}
}