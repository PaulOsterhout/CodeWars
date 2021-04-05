using System.Collections.Generic;
using System.Linq;

namespace CodeWars.Kata_58e61f3d8ff24f774400002c
{
	public class AssemblerInterpreter
	{
		public static string Interpret(string input)
		{
			Context context = new Context();
			string[] program = input.Split('\n');
			List<Instruction> instructions = program.Select(x => CreateInstruction(x)).ToList();
			instructions.RemoveAll(x => x == null);
			List<LabelInstruction> labelInstructions = instructions.Where(x => x is LabelInstruction).Select(x => x as LabelInstruction).ToList();
			foreach (LabelInstruction labelInstruction in labelInstructions)
			{
				int index = instructions.IndexOf(labelInstruction) + 1;
				while (instructions[index] is not ReturnInstruction)
				{
					labelInstruction.Instructions.Add(instructions[index]);
					instructions.RemoveAt(index);
				}
				instructions.RemoveAt(index);
			}
			foreach (Instruction instruction in instructions)
			{
				instruction.Execute(context);
			}
			return context.Output.Length == 0 ? null : context.Output.ToString();
		}

		private static Instruction CreateInstruction(string text)
		{
			string[] items = text.Split(' ');
			string action = items[0].Trim();
			string parameters = text.Substring(text.IndexOf(action) + action.Length, text.Length - action.Length).Trim();
			return action switch
			{
				"add" => new AddInstruction(action, parameters),
				"dec" => new DecrementInstruction(action, parameters),
				"div" => new DivideInstruction(action, parameters),
				"end" => new EndInstruction(action, parameters),
				"inc" => new IncrementInstruction(action, parameters),
				"mov" => new MoveInstruction(action, parameters),
				"mul" => new MultiplyInstruction(action, parameters),
				"msg" => new MessageInstruction(action, parameters),
				"ret" => new ReturnInstruction(action, parameters),
				"sub" => new SubInstruction(action, parameters),
				"" => null,
				";" => null,
				_ => action.EndsWith(':') ? new LabelInstruction(action, parameters) : null
			};
		}

		private class AddInstruction : Instruction
		{
			public AddInstruction(string action, string parameters) : base(action, parameters) {}

			public override void Execute(Context context)
			{
				string[] addParameters = Parameters.Split(' ');
				addParameters[0] = RemoveTrailingComma(addParameters[0]);
				context.Registers[addParameters[0]] += context.GetIntValue(addParameters[1]);
			}
		}

		private class DecrementInstruction : Instruction
		{
			public DecrementInstruction(string action, string parameters) : base(action, parameters) {}

			public override void Execute(Context context)
			{
				context.Registers[Parameters.Split(' ')[0]]--;
			}
		}

		private class DivideInstruction : Instruction
		{
			public DivideInstruction(string action, string parameters) : base(action, parameters) {}

			public override void Execute(Context context)
			{
				string[] addParameters = Parameters.Split(' ');
				addParameters[0] = RemoveTrailingComma(addParameters[0]);
				context.Registers[addParameters[0]] /= context.GetIntValue(addParameters[1]);
			}
		}

		private class EndInstruction : Instruction
		{
			public EndInstruction(string action, string parameters) : base(action, parameters) {}

			public override void Execute(Context context)
			{
				context.IsComplete = true;
			}
		}

		private class IncrementInstruction : Instruction
		{
			public IncrementInstruction(string action, string parameters) : base(action, parameters) {}

			public override void Execute(Context context)
			{
				context.Registers[Parameters.Split(' ')[0]]++;
			}
		}

		private class LabelInstruction : Instruction
		{
			public List<Instruction> Instructions { get; }

			public LabelInstruction(string action, string parameters) : base(action, parameters)
			{
				Instructions = new List<Instruction>();
				Label = action.Substring(0, action.IndexOf(':'));
			}

			public override void Execute(Context context)
			{
			}
		}

		private class MessageInstruction : Instruction
		{
			public MessageInstruction(string action, string parameters) : base(action, parameters) {}

			public override void Execute(Context context)
			{
				foreach (string value in GetMessageValues())
				{
					context.Output.Append(context.GetStringValue(value));
				}
			}

			private IEnumerable<string> GetMessageValues()
			{
				bool hasQuotes = false;
				bool newItem = true;System.Text.StringBuilder value = new System.Text.StringBuilder();
				
				foreach (char character in Parameters)
				{
					if (newItem)
					{
						if (character == ' ') continue;
						hasQuotes = character == '\'';
						newItem = false;
						value = new System.Text.StringBuilder(hasQuotes ? "" : character.ToString());
						continue;
					}
					switch (character)
					{
						case '\'':
							if (!hasQuotes) value.Append(character);
							hasQuotes = false;
							break;
						case ',':
							if (hasQuotes)
							{
								value.Append(character);
								continue;
							}
							newItem = true;
							yield return value.ToString();
							break;
						case ' ':
							if (hasQuotes) value.Append(character);
							break;
						default:
							value.Append(character);
							break;
					};
				}
				if (value.Length > 0) yield return value.ToString();
			}
		}

		private class MoveInstruction : Instruction
		{
			public MoveInstruction(string action, string parameters) : base(action, parameters) {}

			public override void Execute(Context context)
			{
				string[] moveParameters = Parameters.Split(' ');
				string key = RemoveTrailingComma(moveParameters[0]);
				int value = context.GetIntValue(moveParameters[1]);
				if (context.Registers.ContainsKey(key))
				{
					context.Registers[key] = value;
				}
				else
				{
					context.Registers.Add(key, value);
				}
			}
		}

		private class MultiplyInstruction : Instruction
		{
			public MultiplyInstruction(string action, string parameters) : base(action, parameters) {}

			public override void Execute(Context context)
			{
				string[] addParameters = Parameters.Split(' ');
				addParameters[0] = RemoveTrailingComma(addParameters[0]);
				context.Registers[addParameters[0]] *= context.GetIntValue(addParameters[1]);
			}
		}

		private class ReturnInstruction : Instruction
		{
			public ReturnInstruction(string action, string parameters) : base(action, parameters) {}

			public override void Execute(Context context)
			{
			}
		}

		private class SubInstruction : Instruction
		{
			public SubInstruction(string action, string parameters) : base(action, parameters) {}

			public override void Execute(Context context)
			{
				string[] addParameters = Parameters.Split(' ');
				addParameters[0] = RemoveTrailingComma(addParameters[0]);
				context.Registers[addParameters[0]] -= context.GetIntValue(addParameters[1]);
			}
		}

		private abstract class Instruction
		{
			public Instruction(string action, string parameters)
			{
				Action = action;
				Parameters = parameters;
			}

			public string Label { get; set; }

			public abstract void Execute(Context context);

			protected string Action { get; }
			protected string Parameters { get; }

			protected bool HasSingleQuotes(string s)
			{
				return s.StartsWith('\'') && s.EndsWith('\'');
			}

			protected string RemoveSingleQuotes(string s)
			{
				return HasSingleQuotes(s) ? s.Substring(1, s.Length - 2) : s;
			}

			protected string RemoveTrailingComma(string s)
			{
				return s.EndsWith(',') ? s.Substring(0, s.Length - 1) : s;
			}
		}

		private class Context
		{
			public bool IsComplete { get; set; } = false;
			public readonly System.Text.StringBuilder Output = new System.Text.StringBuilder();
			public readonly Dictionary<string, int> Registers = new Dictionary<string, int>();

			public int GetIntValue(string s) => int.TryParse(s, out var temp) ? temp : Registers[s];

			public string GetStringValue(string s) => int.TryParse(s, out var temp) ? temp.ToString() : Registers.ContainsKey(s) ? Registers[s].ToString() : s;
		}
	}
}
