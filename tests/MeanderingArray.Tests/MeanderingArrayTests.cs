using System.Collections.Generic;
using FluentAssertions;
using MeanderingArray.ConsoleApp;
using Xunit;

namespace MeanderingArray.Tests
{
    public class MeanderingArrayTests
    {
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

        [Theory]
        [MemberData(nameof(MeanderingArrayTestData))]
        public void MeanderingArrayTest(List<int> unsorted, List<int> expected)
        {
            // Arrange

            // Act
            List<int> actual = Result.MeanderingArray(unsorted);

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