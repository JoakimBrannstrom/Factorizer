using System;
using System.Collections.Generic;
using System.Linq;

namespace Factorizer
{
	public class Factoring
	{
		public static SortedSet<ulong> CachedPrimes = new SortedSet<ulong>();

		public bool CancellationPending { get; set; }

		public IEnumerable<ulong> GetFactors(ulong i)
		{
			if (i < 2)
			{
				yield return i;
				yield break;
			}

			foreach (var prime in GetSlowPrimes())
			{
				if (CancellationPending)
				{
					yield return 1;
					yield break;
				}

				while (i % prime == 0)
				{
					yield return prime;

					i = i / prime;
					if (i < 2)
						yield break;
				}
			}
		}

		public static IEnumerable<ulong> GetSlowPrimes(ulong start = 2)
		{
			return GetPrimes(IsPrimeSlow, start);
		}

		public static IEnumerable<ulong> GetFastPrimes(ulong start = 2)
		{
			return GetPrimes(IsPrimeFast, start);
		}

		private static IEnumerable<ulong> GetPrimes(Func<ulong, bool> isPrime, ulong start = 2)
		{
			if (start < 2)
				throw new ArgumentOutOfRangeException("start", "A prime number can't be less than '2'");

			for (var candidate = start; candidate < ulong.MaxValue; candidate++)
			{
				if (!isPrime(candidate))
					continue;

				if (!CachedPrimes.Contains(candidate))
					CachedPrimes.Add(candidate);

				yield return candidate;
			}
		}

		private static bool IsPrimeSlow(ulong candidate)
		{
			var maxValue = (ulong)Math.Ceiling(Math.Sqrt(candidate));

			if (CachedPrimes.Contains(candidate))
				return true;

			return CachedPrimes
					.Where(p => p <= maxValue)
					.All(p => candidate % p != 0);
		}

		public static bool IsPrimeFast(ulong candidate)
		{
			if (candidate == 2)
				return true;

			if (candidate < 2)
				return false;

			// http://primes.utm.edu/prove/prove2_3.html
			// For prime p and a < p
			// a^(p-1) = 1 (mod p)
			const ulong a = 2;
			var p = candidate;
			var result = Math.Pow(a, p - 1);
			if(double.IsPositiveInfinity(result))
				throw new ArgumentOutOfRangeException("candidate", "IsPrimeFast can't be used for inputs as large as " + candidate);

			var reminder = (ulong)Math.Round(result % p);

			return reminder == 1;
		}
	}
}
