﻿using System;
using System.Text.RegularExpressions;

using Junior.Common;

namespace Junior.Route.AutoRouting.ClassFilters
{
	public class NameMatchesRegexPatternFilter : IClassFilter
	{
		private readonly RegexOptions _options;
		private readonly string _pattern;

		public NameMatchesRegexPatternFilter(string pattern, RegexOptions options = RegexOptions.None)
		{
			pattern.ThrowIfNull("pattern");

			_pattern = pattern;
			_options = options;
		}

		public bool Matches(Type type)
		{
			type.ThrowIfNull("type");

			return Regex.IsMatch(type.Name, _pattern, _options);
		}
	}
}