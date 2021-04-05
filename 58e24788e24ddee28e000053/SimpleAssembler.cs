using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeWars.Kata_58e24788e24ddee28e000053
{
	public static class SimpleAssembler
	{
		private static Dictionary<string, int> Mine(string[] program)
		{
			Dictionary<string, int> register = new Dictionary<string, int>();
			List<Instruction> instructions = program.Select(x => new Instruction(x)).ToList();
			int lineNumber = 0;
			while (lineNumber < instructions.Count)
			{
				switch (instructions[lineNumber].Action)
				{
					case "dec":
					{
						register[instructions[lineNumber].Parameters[0]] -= 1;
						lineNumber++;
						break;
					}
					case "inc":
					{
						register[instructions[lineNumber].Parameters[0]] += 1;
						lineNumber++;
						break;
					}
					case "jnz":
					{
						int x = 0;
						if (int.TryParse(instructions[lineNumber].Parameters[0], out x)
							? x != 0
							: register[instructions[lineNumber].Parameters[0]] != 0)
						{
							int y = 0;
							if (!int.TryParse(instructions[lineNumber].Parameters[1], out y))
							{
								y = register[instructions[lineNumber].Parameters[1]];
							}
							lineNumber += y;
							break;
						}
						lineNumber++;
						break;
					}
					case "mov":
					{
						int y = 0;
						if (!int.TryParse(instructions[lineNumber].Parameters[1], out y))
						{
							y = register[instructions[lineNumber].Parameters[1]];
						}
						string x = instructions[lineNumber].Parameters[0];
						if (register.ContainsKey(x))
						{
							register[x] = y;
						}
						else
						{
							register.Add(x, y);
						}
						lineNumber++;
						break;
					}
					default:
					{
						lineNumber++;
						break;
					}
				}
			}
			return register;
		}

		private class Instruction
		{
			internal Instruction(string instructionText)
			{
				string[] instructionParts = instructionText.Split(' ', StringSplitOptions.RemoveEmptyEntries);
				Action = instructionParts[0];
				Parameters = new List<string>(instructionParts);
				Parameters.RemoveAt(0);
			}

			public string Action { get; private set; }
			public List<string> Parameters { get; set; }
		}

		private static Dictionary<string, int> Better(string[] program)
		{
			Dictionary<string, int> register = new Dictionary<string, int>();
			int GetValue(string s) => int.TryParse(s, out var temp) ? temp : register[s];
			for (int lineNumber = 0; lineNumber < program.Length; lineNumber++)
			{
				string[] instruction = program[lineNumber].Split();
				var _ = instruction[0] switch
				{
					"dec" => register[instruction[1]]--,
					"inc" => register[instruction[1]]++,
					"jnz" => lineNumber += GetValue(instruction[1]) != 0 ? GetValue(instruction[2]) -1 : 0,
					"mov" => register[instruction[1]] = GetValue(instruction[2]),
					_ => throw new Exception("Input error")
				};
			}
			return register;
		}

		public static Dictionary<string, int> Interpret(string[] program)
		{
			// return Mine(program);
			return Better(program);
		}
	}
}
