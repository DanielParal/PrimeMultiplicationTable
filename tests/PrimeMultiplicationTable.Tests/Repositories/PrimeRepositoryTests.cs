using PrimeMultiplicationTable.Web.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace PrimeMultiplicationTable.Tests.Repositories
{
    public class PrimeRepositoryTests
    {
        private readonly PrimeRepository _systemUnderTest;

        public PrimeRepositoryTests()
        {
            _systemUnderTest = new PrimeRepository();
        }

        [Theory]
        [InlineData(1, false)]
        [InlineData(2, true)]
        [InlineData(4, false)]
        [InlineData(823, true)]
        [InlineData(889, false)]
        [InlineData(2411, true)]
        public void IsPrime_ShouldReturnTrueIfNumberIsPrime(int inputValue, bool expectedResult)
        {
            bool isInuputPrime = _systemUnderTest.IsPrime(inputValue);

            Assert.Equal(expectedResult, isInuputPrime);
        }

        [Theory]
        [InlineData(1, 1)]
        [InlineData(10, 10)]
        [InlineData(100, 100)]
        public void GetPrimesList_ShouldReturnNResults_WhereNIsInputValue(int inputValue, int expectedResult)
        {
            List<int> primeList = _systemUnderTest.GetPrimesList(inputValue);

            Assert.Equal(expectedResult, primeList.Count);
        }

        [Theory]
        [MemberData(nameof(GetPrimeNumbersTestData))]
        public void GetPrimesList_CheckFirstFewPrimeNumbers(int inputValue, List<int> expectedResult)
        {
            List<int> primeList = _systemUnderTest.GetPrimesList(inputValue);

            Assert.True(Enumerable.SequenceEqual(primeList, expectedResult));
        }

        public static IEnumerable<object[]> GetPrimeNumbersTestData()
        {
            yield return new object[] { 2, new List<int>() { 2, 3 } };
            yield return new object[] { 5, new List<int>() { 2, 3, 5, 7, 11 } };
            yield return new object[] { 7, new List<int>() { 2, 3, 5, 7, 11, 13, 17 } };
            yield return new object[] { 12, new List<int>() { 2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37 } };
        }
    }
}
