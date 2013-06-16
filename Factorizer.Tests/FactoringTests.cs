using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Factorizer.Tests
{
	[TestClass]
	public class FactoringTests
	{
		[TestMethod]
		public void GivenNoInitialState_WhenFetchingPrimes_ThenCorrectPrimesShouldBeReturned()
		{
			var expectedPrimes = new ulong[] { 2, 3, 5, 7, 11, 13, 17 };

			var primes = Factoring
							.GetSlowPrimes()
							.Take(expectedPrimes.Length)
							.ToArray();

			for (var i = 0; i < expectedPrimes.Length; i++)
			{
				Assert.AreEqual(expectedPrimes[i], primes[i]);
			}
		}

		[TestMethod]
		public void GivenPrimeNumber_WhenFactoring_ThenPrimeNumberShouldBeReturned()
		{
			const ulong expected = 2;
			var factors = new Factoring().GetFactors(expected).ToArray();

			Assert.AreEqual(expected, factors.Single());
		}

		[TestMethod]
		public void GivenNonPrimeNumber_WhenFactoring_ThenFactorsOfThatNumberShouldBeReturned()
		{
			var factors = new Factoring().GetFactors(6).ToArray();

			Assert.AreEqual(2, factors.Length);
			Assert.AreEqual((ulong)2, factors.First());
			Assert.AreEqual((ulong)3, factors.Skip(1).First());
		}

		[TestMethod]
		public void GivenNumberWithSamePrimeFactors_WhenFactoring_ThenFactorsOfThatNumberShouldBeReturned()
		{
			var factors = new Factoring().GetFactors(9).ToArray();

			Assert.AreEqual(2, factors.Length);
			Assert.AreEqual((ulong)3, factors.First());
			Assert.AreEqual((ulong)3, factors.Skip(1).First());
		}

		[TestMethod]
		public void GivenNumberWithSeveralFactors_WhenFactoring_ThenFactorsOfThatNumberShouldBeReturned()
		{
			var expectedFactors = new ulong[] { 2, 2, 3, 5, 11, 11, 13, 17, 53 };

			var value = expectedFactors.Aggregate<ulong, ulong>(1, (current, factor) => current * factor);

			var factors = new Factoring().GetFactors(value).ToArray();

			for (var i = 0; i < expectedFactors.Length; i++)
			{
				Assert.AreEqual(expectedFactors[i], factors[i]);
			}
		}

		[TestMethod]
		public void GivenNonPrimeNumber_WhenCheckingForPrimality_ThenFalseShouldBeReturned()
		{
			var result = Factoring.IsPrimeFast(4);

			Assert.IsFalse(result);
		}

		[TestMethod]
		public void GivenPrimeNumber_WhenCheckingForPrimality_ThenFalseShouldBeReturned()
		{
			var primes = new ulong[] { 2, 3, 5, 11, 13, 17, 53 };

			foreach (var prime in primes)
			{
				var result = Factoring.IsPrimeFast(prime);
				Assert.IsTrue(result);
			}
		}
	}
}
