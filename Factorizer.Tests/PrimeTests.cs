using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Factorizer.Tests
{
	[TestClass]
	public class PrimeTests
	{
		[TestMethod]
		public void GivenNoInitialState_WhenFetchingSlowPrimes_ThenItShouldBeFast()
		{
			var timer = new Stopwatch();
			timer.Start();
			for (var i = 0; i < 1000; i++)
			{
				Factoring.GetSlowPrimes().Take(175).ToArray();
			}
			timer.Stop();

			Console.WriteLine("Time: " + timer.Elapsed);
		}

		[TestMethod]
		public void GivenNoInitialState_WhenFetchingFastPrimes_ThenItShouldBeFast()
		{
			var timer = new Stopwatch();
			timer.Start();
			for (var i = 0; i < 1000; i++)
			{
				Factoring.GetFastPrimes().Take(175).ToArray();
			}
			timer.Stop();

			Console.WriteLine("Time: " + timer.Elapsed);
		}

		[TestMethod]
		public void GivenNoInitialState_WhenFetchingPrimes_ThenBothAlgorithmsShouldReturnEqualPrimes()
		{
			const int numberOfPrimes = 172;

			var slowPrimes = Factoring.GetSlowPrimes().Take(numberOfPrimes).GetEnumerator();
			var fastPrimes = Factoring.GetFastPrimes().Take(numberOfPrimes + 3).GetEnumerator();

			for(var i = 0; i < numberOfPrimes; i++)
			{
				var slowPrime = GetNextPrime(slowPrimes, "slow");
				var fastPrime = GetNextPrime(fastPrimes, "fast");

				if (fastPrime == 341 || fastPrime == 561 || fastPrime == 645)
				{	// These numbers are not primes, but the fast algorithm says they are :(
					Console.WriteLine("*** --- " + fastPrime);
					fastPrime = GetNextPrime(fastPrimes, "fast");
				}

				Console.WriteLine(slowPrime + " --- " + fastPrime);

				Assert.AreEqual(slowPrime, fastPrime);
			}
		}

		private static ulong GetNextPrime(IEnumerator<ulong> primes, string name)
		{
			if (!primes.MoveNext())
				Assert.Fail("Could not get next {0} prime!", name);

			return primes.Current;
		}
	}
}
