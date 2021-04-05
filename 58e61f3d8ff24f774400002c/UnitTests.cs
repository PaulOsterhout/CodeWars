using System;
using NUnit.Framework;

namespace CodeWars.Kata_58e61f3d8ff24f774400002c
{
	public class AssemblerInterpreterTest
	{
		[Test]
		public void TestNull()
		{
			Assert.AreEqual(null, AssemblerInterpreter.Interpret("\n; Null Test"));
		}

		[Test]
		public void TestIncDec()
		{
			Assert.AreEqual("Register: 6",
				AssemblerInterpreter.Interpret("\n; First Test from Part 1\nmov a, 5\ninc a\ndec a\ninc a\nmsg 'Register: ', a\nend\n"));
			Assert.AreEqual("Register: a = -9, b = -11",
				AssemblerInterpreter.Interpret("\n; Second Test from Part 1\nmov a, -10\nmov b a\ninc a\ndec b\nmsg 'Register: a = ', a, ', b = ', b\nend\n"));
		}

		[Test]
		public void TestAddSub()
		{
			Assert.AreEqual("Register: a = -7, b = -14",
				AssemblerInterpreter.Interpret("\n; Add Test\nmov a, -10\nmov b, a\ninc a\ndec b\nadd a, 2\nadd b, -3\nmsg 'Register: a = ', a, ', b = ', b\nend\n"));
			Assert.AreEqual("Register: a = -5, b = -17",
				AssemblerInterpreter.Interpret("\n; Sub Test\nmov a, -10\nmov b, a\ninc a\ndec b\nadd a, 2\nadd b, -3\nsub a, -2\nsub b, 3\nmsg 'Register: a = ', a, ', b = ', b\nend\n"));
		}

		[Test]
		public void TestMultDiv()
		{
			Assert.AreEqual("Register: a = -1, b = -34",
				AssemblerInterpreter.Interpret("\n; Sub Test\nmov a, -10\nmov b, a\ninc a\ndec b\nadd a, 2\nadd b, -3\nsub a, -2\nsub b, 3\ndiv a, 5\nmul b, 2\nmsg 'Register: a = ', a, ', b = ', b\nend\n"));
		}

		[Test]
		public void TestBlankSubroutine()
		{
			Assert.AreEqual("Register: a = -1, b = -34",
				AssemblerInterpreter.Interpret("\n; Sub Test\nmov a, -10\nmov b, a\ninc a\ndec b\nadd a, 2\nadd b, -3\nsub a, -2\nsub b, 3\ndiv a, 5\nmul b, 2\nnop:\nret\nmsg 'Register: a = ', a, ', b = ', b\nend\n"));
		}

		// [Test]
		// public void TestSimpleSubroutine()
		// {
		// 	Assert.AreEqual("Register: a = -1, b = -34",
		// 		AssemblerInterpreter.Interpret("\n; Sub Test\nmov a, -10\nmov b, a\ncall domath\ndo_math:\ninc a\ndec b\nadd a, 2\nadd b, -3\nsub a, -2\nsub b, 3\ndiv a, 5\nmul b, 2\nret\nmsg 'Register: a = ', a, ', b = ', b\nend\n"));
		// }

		[Test]
		public void TestSimple()
		{
			// for (int i = 0; i < expected.Length; i++)
			// {
			// 	Assert.AreEqual(expected[i], AssemblerInterpreter.Interpret(displayProg(progs[i])));
			// }
		}

		private static string[] progs =
		{
			"\n; My first program\nmov  a, 5\ninc  a\ncall function\nmsg  '(5+1)/2 = ', a    ; output message\nend\n\nfunction:\n    div  a, 2\n    ret\n",
			"\nmov   a, 5\nmov   b, a\nmov   c, a\ncall  proc_fact\ncall  print\nend\n\nproc_fact:\n    dec   b\n    mul   c, b\n    cmp   b, 1\n    jne   proc_fact\n    ret\n\nprint:\n    msg   a, '! = ', c ; output text\n    ret\n",
			"\nmov   a, 8            ; value\nmov   b, 0            ; next\nmov   c, 0            ; counter\nmov   d, 0            ; first\nmov   e, 1            ; second\ncall  proc_fib\ncall  print\nend\n\nproc_fib:\n    cmp   c, 2\n    jl    func_0\n    mov   b, d\n    add   b, e\n    mov   d, e\n    mov   e, b\n    inc   c\n    cmp   c, a\n    jle   proc_fib\n    ret\n\nfunc_0:\n    mov   b, c\n    inc   c\n    jmp   proc_fib\n\nprint:\n    msg   'Term ', a, ' of Fibonacci series is: ', b        ; output text\n    ret\n",
			"\nmov   a, 11           ; value1\nmov   b, 3            ; value2\ncall  mod_func\nmsg   'mod(', a, ', ', b, ') = ', d        ; output\nend\n\n; Mod function\nmod_func:\n    mov   c, a        ; temp1\n    div   c, b\n    mul   c, b\n    mov   d, a        ; temp2\n    sub   d, c\n    ret\n",
			"\nmov   a, 81         ; value1\nmov   b, 153        ; value2\ncall  init\ncall  proc_gcd\ncall  print\nend\n\nproc_gcd:\n    cmp   c, d\n    jne   loop\n    ret\n\nloop:\n    cmp   c, d\n    jg    a_bigger\n    jmp   b_bigger\n\na_bigger:\n    sub   c, d\n    jmp   proc_gcd\n\nb_bigger:\n    sub   d, c\n    jmp   proc_gcd\n\ninit:\n    cmp   a, 0\n    jl    a_abs\n    cmp   b, 0\n    jl    b_abs\n    mov   c, a            ; temp1\n    mov   d, b            ; temp2\n    ret\n\na_abs:\n    mul   a, -1\n    jmp   init\n\nb_abs:\n    mul   b, -1\n    jmp   init\n\nprint:\n    msg   'gcd(', a, ', ', b, ') = ', c\n    ret\n",
			"\ncall  func1\ncall  print\nend\n\nfunc1:\n    call  func2\n    ret\n\nfunc2:\n    ret\n\nprint:\n    msg 'This program should return null'\n",
			"\nmov   a, 2            ; value1\nmov   b, 10           ; value2\nmov   c, a            ; temp1\nmov   d, b            ; temp2\ncall  proc_func\ncall  print\nend\n\nproc_func:\n    cmp   d, 1\n    je    continue\n    mul   c, a\n    dec   d\n    call  proc_func\n\ncontinue:\n    ret\n\nprint:\n    msg a, '^', b, ' = ', c\n    ret\n"
		};

		private static string[] expected =
		{
			"(5+1)/2 = 3",
			"5! = 120",
			"Term 8 of Fibonacci series is: 21",
			"mod(11, 3) = 2",
			"gcd(81, 153) = 9",
			null,
			"2^10 = 1024"
		};

		private string displayProg(string p)
		{
			Console.WriteLine("\n----------------------\n");
			Console.WriteLine(p);
			return p;
		}
	}
}
