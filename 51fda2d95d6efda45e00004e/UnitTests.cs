using NUnit.Framework;

namespace CodeWars.Kata_51fda2d95d6efda45e00004e
{
	[TestFixture]
	public class UnitTests
	{
		[Test]
		public void ProgressByZeroTest()
		{
			User user = new User();
			int expectedProgress = 0;
			int expectedRank = -8;
			while (user.rank < 8)
			{
				user.incProgress(user.rank);
				expectedProgress += 3;
				if (expectedProgress > 99)
				{
					expectedProgress -= 100;
					expectedRank++;
					if (expectedRank == 0) expectedRank = 1;
				}
				Assert.AreEqual(expectedProgress, user.progress, $"Progress Check, Progress: {user.progress}, Rank: {user.rank}");
				Assert.AreEqual(expectedRank, user.rank, $"Rank Check, Progress: {user.progress}, Rank: {user.rank}");
			}
		}

		[Test]
		public void ProgressByOneTest()
		{
			User user = new User();
			int expectedProgress = 0;
			int expectedRank = -8;
			while (user.rank < 8)
			{
				int progressIncrement = 10;
				int nextRank = user.rank + 1;
				if (nextRank == 0)
				{
					nextRank = 1;
				}
				user.incProgress(nextRank);
				expectedProgress += progressIncrement;
				if (expectedProgress > 99)
				{
					expectedProgress -= 100;
					expectedRank++;
					if (expectedRank == 0) expectedRank = 1;
				}
				Assert.AreEqual(expectedProgress, user.progress, $"Progress Check, Progress: {user.progress}, Rank: {user.rank}");
				Assert.AreEqual(expectedRank, user.rank, $"Rank Check, Progress: {user.progress}, Rank: {user.rank}");
			}
		}

		[Test]
		public void ProgressByTwoTest()
		{
			User user = new User();
			int expectedProgress = 0;
			int expectedRank = -8;
			while (user.rank < 7)
			{
				int progressIncrement = 40;
				int nextRank = user.rank + 2;
				if ((user.rank < 0) && (nextRank > -1))
				{
					nextRank += 1;
				}
				user.incProgress(nextRank);
				expectedProgress += progressIncrement;
				while (expectedProgress > 99)
				{
					expectedProgress -= 100;
					expectedRank++;
					if (expectedRank == 0) expectedRank = 1;
				}
				Assert.AreEqual(expectedProgress, user.progress, $"Progress Check, Progress: {user.progress}, Rank: {user.rank}");
				Assert.AreEqual(expectedRank, user.rank, $"Rank Check, Progress: {user.progress}, Rank: {user.rank}");
			}
		}

		[Test]
		public void SampleTest()
		{
			User user = new User();
			Assert.AreEqual(-8, user.rank);
			Assert.AreEqual(0, user.progress);
			user.incProgress(-7);
			Assert.AreEqual(10, user.progress);
			user.incProgress(-5); // will add 90 progress
			Assert.AreEqual(0, user.progress); // progress is now zero
			Assert.AreEqual(-7, user.rank); // rank was upgraded to -7
		}

		[Test]
		public void TestValidMultipleRanks()
		{
			int[] appliedRank = new int[] { -8, -7, -6, -5, -4, -3, -2, -1, 1, 2, 3, 4, 5, 6, 7, 8 };
			int[] expectedProgresses = new int[] { 3, 10, 40, 90, 160, 250, 360, 490, 640, 810, 1000, 1210, 1440, 1690, 1960, 2250 };
			int[] expectedRanks = new int[] { -8, -8, -8, -8, -7, -6, -5, -4, -2, 1, 3, 5, 7, 8, 8, 8 };
			for (int index = 0; index < expectedProgresses.Length; index++)
			{
				User user = new User(-8, 0);
				Assert.AreEqual(-8, user.rank);
				Assert.AreEqual(0, user.progress);
				user.incProgress(appliedRank[index]);
				Assert.AreEqual(expectedRanks[index], user.rank, $"Rank for index {index}.");
				int expectedProgress = expectedRanks[index] < 8 ? expectedProgresses[index] % 100 : 0;
				Assert.AreEqual(expectedProgress, user.progress, $"Progress for index {index}.");
			}
		}

		[Test]
		public void TestAppliedRank()
		{
			int appliedRank = -1;
			int[] initialRanks = new int[] { -8, -7, -6, -5, -4, -3, -2, -1 };
			int[] expectedProgresses = new int[] { 490, 360, 250, 160, 90, 40, 10, 3 };
			int[] expectedRanks = new int[] { -4, -4, -4, -4, -4, -3, -2, -1 };
			for (int index = 0; index < expectedProgresses.Length; index++)
			{
				User user = new User(initialRanks[index], 0);
				Assert.AreEqual(initialRanks[index], user.rank);
				Assert.AreEqual(0, user.progress);
				user.incProgress(appliedRank);
				Assert.AreEqual(expectedRanks[index], user.rank, $"Rank for index {index}.");
				int expectedProgress = expectedRanks[index] < 8 ? expectedProgresses[index] % 100 : 0;
				Assert.AreEqual(expectedProgress, user.progress, $"Progress for index {index}.");
			}
		}

		[Test]
		public void TestAppliedRankProgression()
		{
			int appliedRank = -1;
			int[] expectedProgresses = new int[] { 90, 80, 20, 30, 40, 50, 60, 70, 80, 90, 0 };
			int[] expectedRanks = new int[] { -4, -3, -2, -2, -2, -2, -2, -2, -2, -2, -1 };
			User user = new User();
			Assert.AreEqual(-8, user.rank);
			Assert.AreEqual(0, user.progress);
			for (int index = 0; index < expectedProgresses.Length; index++)
			{
				user.incProgress(appliedRank);
				Assert.AreEqual(expectedRanks[index], user.rank, $"Rank for index {index}.");
				int expectedProgress = expectedRanks[index] < 8 ? expectedProgresses[index] % 100 : 0;
				Assert.AreEqual(expectedProgress, user.progress, $"Progress for index {index}.");
			}
		}

		[Test]
		public void TestValidMultipleRankProgression()
		{
			int[] appliedRanks = new int[] { 1, 1, 1, 1, 1, 2, 2, -1 };
			int[] expectedProgresses = new int[] { 40, 80, 20, 30, 40, 80, 20, 21 };
			int[] expectedRanks = new int[] { -2, -2, -1, -1, -1, -1, 1, 1 };
			User user = new User();
			Assert.AreEqual(-8, user.rank);
			Assert.AreEqual(0, user.progress);
			for (int index = 0; index < expectedProgresses.Length; index++)
			{
				user.incProgress(appliedRanks[index]);
				Assert.AreEqual(expectedRanks[index], user.rank, $"Rank for index {index}.");
				Assert.AreEqual(expectedProgresses[index], user.progress, $"Progress for index {index}.");
			}
		}
	}
}
