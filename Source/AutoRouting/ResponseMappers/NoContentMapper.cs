﻿using System;
using System.Reflection;

using Junior.Common;
using Junior.Route.AutoRouting.Containers;

namespace Junior.Route.AutoRouting.ResponseMappers
{
	public class NoContentMapper : IResponseMapper
	{
		public void Map(Func<IContainer> container, Type type, MethodInfo method, Routing.Route route)
		{
			container.ThrowIfNull("container");
			type.ThrowIfNull("type");
			method.ThrowIfNull("method");
			route.ThrowIfNull("route");

			route.RespondWithNoContent();
		}
	}
}