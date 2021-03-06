﻿using System;
using System.Collections.Generic;
using FluentAssertions;
using MeanderingArray.ConsoleApp;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace MeanderingArray.Tests
{
    public class MeanderingArrayTests
    {
        private readonly Mock<ILogger<Result>> _logger;
        private readonly IResult _result;

        public MeanderingArrayTests()
        {
            _logger = new Mock<ILogger<Result>>();
            _result = new Result(_logger.Object);
        }

        public static IEnumerable<object[]> MeanderingArrayTestData =>
            new List<object[]>
            {
                new object[]
                {
                    new List<int> { 7, 5, 2, 7, 8, -2, 25, 25 },
                    new List<int> { 25, -2, 25, 2, 8, 5, 7 }
                },
                new object[]
                {
                    new List<int> { -27676, 211621, 904304, 161270, -292822, 732004, 860511, -825806, -721722, 536428, -927571, -287004 },
                    new List<int> { 904304, -927571, 860511, -825806, 732004, -721722, 536428, -292822, 211621, -287004, 161270, -27676 }
                }
            };

        [Fact]
        public void MeanderingArray_EmptyInput_Test()
        {
            // Arrange
            const string expected = "Collection cannot be empty (Parameter 'unsorted')";
            List<int> unsorted = new List<int>();

            // Act
            Action actual = () => _result.MeanderingArray(unsorted);

            // Assert
            actual
                .Should()
                .Throw<ArgumentException>()
                .WithMessage(expected);

            _logger.Invocations.Count
                .Should()
                .Be(1);

            _logger.Invocations[0].Arguments[0]
                .Should()
                .Be(LogLevel.Error);

            _logger
                .Verify(x => x.Log(LogLevel.Error,
                    It.IsAny<EventId>(),
                    It.Is<It.IsAnyType>((x, t) => string.Equals(x.ToString(), expected)),
                    It.IsAny<Exception>(),
                    It.Is<Func<It.IsAnyType, Exception, string>>((v, t) => true)),
                    Times.Once());
        }

        [Fact]
        public void MeanderingArray_NullInput_Test()
        {
            // Arrange
            const string expected = "Collection cannot be null (Parameter 'unsorted')";

            // Act
            Action actual = () => _result.MeanderingArray(null);

            // Assert
            actual
                .Should()
                .Throw<ArgumentNullException>()
                .WithMessage(expected);

            _logger.Invocations.Count
                .Should()
                .Be(1);

            _logger.Invocations[0].Arguments[0]
                .Should()
                .Be(LogLevel.Error);

            _logger
                .Verify(x => x.Log(LogLevel.Error,
                    It.IsAny<EventId>(),
                    It.Is<It.IsAnyType>((x, t) => string.Equals(x.ToString(), expected)),
                    It.IsAny<Exception>(),
                    It.Is<Func<It.IsAnyType, Exception, string>>((v, t) => true)),
                    Times.Once());
        }

        [Theory]
        [MemberData(nameof(MeanderingArrayTestData))]
        public void MeanderingArrayTest(List<int> unsorted, List<int> expected)
        {
            // Arrange

            // Act
            List<int> actual = _result.MeanderingArray(unsorted);

            // Assert
            actual
                .Should()
                .NotBeNull()
                .And
                .HaveCount(expected.Count)
                .And
                .Equal(expected);
        }
    }
}