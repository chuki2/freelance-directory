using System;
using FreelancerDirectoryAPI.Application.Common.Exceptions;
using FluentAssertions;
using NUnit.Framework;

namespace FreelancerDirectoryAPI.Application.UnitTests.Common.Exceptions
{
    public class ValidateModelExceptionTests
    {
        [Test]
        public void DefaultConstructorCreatesAnEmptyErrorDictionary()
        {
            var actual = new ValidateModelException().Errors;

            actual.Keys.Should().BeEquivalentTo(Array.Empty<string>());
        }

    }
}
