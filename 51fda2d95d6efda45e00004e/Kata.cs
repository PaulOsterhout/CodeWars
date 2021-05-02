using System;

namespace CodeWars.Kata_51fda2d95d6efda45e00004e
{
	public class User
	{
		public User()
		{
			progress = 0;
			rank = -8;
		}

		public User(int initialRank, int initialProgress)
		{
			progress = initialProgress;
			rank = initialRank;
		}

		public void incProgress(int rank)
		{
			betterIncProgress(rank);
			//myIncProgress(rank);
		}

		private void betterIncProgress(int level)
		{
			if (level < -8 || level > 8 || level == 0)
				throw new ArgumentException();

			int tempLevel = level > 0 ? level - 1 : level;
			int tempRank = rank > 0 ? rank - 1 : rank;
			int diff = tempLevel - tempRank;
			
			progress += diff < -1 ? 0 : diff == -1 ? 1 : diff == 0 ? 3 : 10 * diff * diff;
		}

		private void myIncProgress(int level)
		{
			int computeProgress(int level)
			{
				int difference = (rank < 0) && (level > 0)
					? level - rank - 1
					: (rank > 0) && (level < 0)
						? level - rank + 1
						: level - rank;
				if (difference < -2) return 0;
				if (difference == -1) return 1;
				if (difference == 0) return 3;
				return 10 * difference * difference;
			}

			if ((level < -8) || (level == 0) || (level > 8)) throw new ArgumentException("Invalid rank");
			_progress += computeProgress(level);
			while (_progress > 99)
			{
				_rank = _rank == -1 ? 1 : _rank + 1;
				_progress = _progress - 100;
			}
			if (_rank > 7)
			{
				_progress = 0;
				_rank = 8;
			}
		}

		private int _progress;
		public int progress
		{
			get { return rank == 8 ? 0 : _progress; }
			private set
			{
				int up = value / 100;
				int newRank = rank + up;
				rank = (rank < 0) && (newRank >= 0) ? newRank + 1 : newRank;
				_progress = value % 100;
			}
		}

		private int _rank;
		public int rank
		{
			get { return _rank; }
			private set { _rank = value == 0 ? 1 : value > 7 ? 8 : value; }
		}
	}
}
