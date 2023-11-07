﻿namespace LeetCode
{
	public class Program
	{
		public static void Main()
		{
			bool result = IsValid("){");

			Console.WriteLine(result);
		}

		public static int RomanToInt(string s)
		{
			int num = 0;

			for (int i = 0; i < s.Length; i++)
			{
				char c = s[i];

				if (c == 'I')
				{
					if (i != s.Length - 1 && s[i + 1] == 'V')
					{
						num += 4;
						i++;
					}
					else if (i != s.Length - 1 && s[i + 1] == 'X')
					{
						num += 9;
						i++;
					}
					else
					{
						num += 1;
					}
				}
				else if (c == 'V')
				{
					num += 5;
				}
				else if (c == 'X')
				{
					if (i != s.Length - 1 && s[i + 1] == 'L')
					{
						num += 40;
						i++;
					}
					else if (i != s.Length - 1 && s[i + 1] == 'C')
					{
						num += 90;
						i++;
					}
					else
					{
						num += 10;
					}
				}
				else if (c == 'L')
				{
					num += 50;
				}
				else if (c == 'C')
				{
					if (i != s.Length - 1 && s[i + 1] == 'D')
					{
						num += 400;
						i++;
					}
					else if (i != s.Length - 1 && s[i + 1] == 'M')
					{
						num += 900;
						i++;
					}
					else
					{
						num += 100;
					}
				}
				else if (c == 'D')
				{
					num += 500;
				}
				else if (c == 'M')
				{
					num += 1000;
				}
			}

			return num;
		}

		public static string LongestCommonPrefix(string[] strs)
		{
			string prefix = "";
			string[] ordered = strs.OrderBy(s => s.Length).ToArray();

			if (ordered.Any())
			{
				prefix = ordered[0];
			}

			for (int i = 1; i < ordered.Length; i++)
			{
				for (int j = 0; j < prefix.Length; j++)
				{
					if (ordered[i][j] != prefix[j])
					{
						prefix = prefix.Remove(j);
					}
				}
			}

			return prefix;
		}

		public static bool IsValid(string s)
		{
			if (s.Length % 2 != 0)
			{
				return false;
			}

			Stack<char> chars = new Stack<char>();

			for (int i = 0; i < s.Length; i++)
			{
				char first = s[i];
				if (first == '(' || first == '{' || first == '[')
				{
					chars.Push(first);
				}
				else
				{
					if (chars.Count == 0)
					{
						return false;
					}

					char last = chars.Peek();

					if (last == '(' && first != ')')
					{
						return false;
					}
					else if (last == '{' && first != '}')
					{
						return false;
					}
					else if (last == '[' && first != ']')
					{
						return false;
					}
					else
					{
						chars.Pop();
					}
				}
			}
			if (chars.Count == 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
	}
}