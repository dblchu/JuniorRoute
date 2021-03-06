﻿using System;

using Junior.Common;

namespace Junior.Route.AutoRouting.ClassFilters
{
	public class HasNamespaceAncestorFilter : IClassFilter
	{
		private readonly string _namespace;

		public HasNamespaceAncestorFilter(string @namespace)
		{
			@namespace.ThrowIfNull("@namespace");

			_namespace = @namespace;
		}

		public bool Matches(Type type)
		{
			type.ThrowIfNull("type");

			return type.NamespaceStartsWith(_namespace);
		}
	}
}