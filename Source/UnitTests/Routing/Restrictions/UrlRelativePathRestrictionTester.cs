﻿using System;
using System.Web;

using Junior.Route.Routing;
using Junior.Route.Routing.RequestValueComparers;
using Junior.Route.Routing.Restrictions;

using NUnit.Framework;

using Rhino.Mocks;

namespace Junior.Route.UnitTests.Routing.Restrictions
{
	public static class UrlRelativePathRestrictionTester
	{
		[TestFixture]
		public class When_comparing_equal_instances
		{
			[SetUp]
			public void SetUp()
			{
				_httpRuntime = MockRepository.GenerateMock<IHttpRuntime>();
				_restriction1 = new UrlRelativePathRestriction("relative", CaseInsensitivePlainComparer.Instance, _httpRuntime);
				_restriction2 = new UrlRelativePathRestriction("relative", CaseInsensitivePlainComparer.Instance, _httpRuntime);
			}

			private UrlRelativePathRestriction _restriction1;
			private UrlRelativePathRestriction _restriction2;
			private IHttpRuntime _httpRuntime;

			[Test]
			public void Must_be_equal()
			{
				Assert.That(_restriction1.Equals(_restriction2), Is.True);
			}
		}

		[TestFixture]
		public class When_comparing_inequal_instances
		{
			[SetUp]
			public void SetUp()
			{
				_httpRuntime = MockRepository.GenerateMock<IHttpRuntime>();
				_restriction1 = new UrlRelativePathRestriction("relative", CaseInsensitivePlainComparer.Instance, _httpRuntime);
				_restriction2 = new UrlRelativePathRestriction("relative", CaseSensitivePlainComparer.Instance, _httpRuntime);
			}

			private UrlRelativePathRestriction _restriction1;
			private UrlRelativePathRestriction _restriction2;
			private IHttpRuntime _httpRuntime;

			[Test]
			public void Must_not_be_equal()
			{
				Assert.That(_restriction1.Equals(_restriction2), Is.False);
			}
		}

		[TestFixture]
		public class When_creating_instance
		{
			[SetUp]
			public void SetUp()
			{
				_httpRuntime = MockRepository.GenerateMock<IHttpRuntime>();
				_restriction = new UrlRelativePathRestriction("relative", CaseInsensitivePlainComparer.Instance, _httpRuntime);
			}

			private UrlRelativePathRestriction _restriction;
			private IHttpRuntime _httpRuntime;

			[Test]
			public void Must_set_properties()
			{
				Assert.That(_restriction.RelativePath, Is.EqualTo("relative"));
				Assert.That(_restriction.Comparer, Is.SameAs(CaseInsensitivePlainComparer.Instance));
			}
		}

		[TestFixture]
		public class When_testing_if_matching_restriction_matches_request
		{
			[SetUp]
			public void SetUp()
			{
				_httpRuntime = MockRepository.GenerateMock<IHttpRuntime>();
				_httpRuntime.Stub(arg => arg.AppDomainAppVirtualPath).Return("/virtual");
				_restriction = new UrlRelativePathRestriction("relative", CaseInsensitivePlainComparer.Instance, _httpRuntime);
				_request = MockRepository.GenerateMock<HttpRequestBase>();
				_request.Stub(arg => arg.Url).Return(new Uri("http://localhost/virtual/relative"));
			}

			private UrlRelativePathRestriction _restriction;
			private HttpRequestBase _request;
			private IHttpRuntime _httpRuntime;

			[Test]
			public void Must_match()
			{
				Assert.That(_restriction.MatchesRequest(_request), Is.True);
			}
		}

		[TestFixture]
		public class When_testing_if_non_matching_restriction_matches_request
		{
			[SetUp]
			public void SetUp()
			{
				_httpRuntime = MockRepository.GenerateMock<IHttpRuntime>();
				_httpRuntime.Stub(arg => arg.AppDomainAppVirtualPath).Return("/virtual");
				_restriction = new UrlRelativePathRestriction("relative", CaseInsensitivePlainComparer.Instance, _httpRuntime);
				_request = MockRepository.GenerateMock<HttpRequestBase>();
				_request.Stub(arg => arg.Url).Return(new Uri("http://localhost/virtual/r"));
			}

			private UrlRelativePathRestriction _restriction;
			private HttpRequestBase _request;
			private IHttpRuntime _httpRuntime;

			[Test]
			public void Must_not_match()
			{
				Assert.That(_restriction.MatchesRequest(_request), Is.False);
			}
		}
	}
}