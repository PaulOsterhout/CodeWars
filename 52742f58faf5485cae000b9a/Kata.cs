using System.Collections.Generic;
using System.Linq;

namespace CodeWars.Kata_52742f58faf5485cae000b9a
{
	public class HumanTimeFormat
	{
		class DurationSpecification
		{
			public string DurationType { get; set; }
			public int SecondsPer { get; set; }

			public string ToString(ref int seconds)
			{
				int value = seconds / SecondsPer;
				seconds -= value * SecondsPer;
				return value > 0 ? $"{value} {DurationType}{(value > 1 ? "s" : "")}" : "";
			}
		}

		public static string formatDuration(int seconds)
		{
			List<string> durations =
				(new DurationSpecification[]
				{
					new DurationSpecification { DurationType = "year", SecondsPer = 31536000 },
					new DurationSpecification { DurationType = "day", SecondsPer = 86400 },
					new DurationSpecification { DurationType = "hour", SecondsPer = 3600 },
					new DurationSpecification { DurationType = "minute", SecondsPer = 60 },
					new DurationSpecification { DurationType = "second", SecondsPer = 1 }
				}).Select(x => x.ToString(ref seconds)).Where(x => x.Length > 0).ToList();
			System.Text.StringBuilder formattedDuration = new System.Text.StringBuilder();
			int durationCount = durations.Count;
			int durationIndex = 0;

			foreach (string duration in durations)
			{
				durationIndex++;
				string prefix = durationIndex == 1 ? "" : (durationCount - durationIndex > 0) ? ", " : " and ";
				formattedDuration.Append(prefix + duration);
			}

			return formattedDuration.Length == 0 ? "now" : formattedDuration.ToString();
		}
	}
}
