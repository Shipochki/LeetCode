﻿namespace LeetCode
{
	using System.Numerics;

	public static class Part1
	{
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

		public static ListNode MergeTwoLists(ListNode list1, ListNode list2)
		{
			if (list1 == null)
			{
				return list2;
			}

			if (list2 == null)
			{
				return list1;
			}

			if (list1.val >= list2.val)
			{
				ListNode tempNode = new ListNode(list1.val, list1.next);
				list1.val = list2.val;
				list1.next = tempNode;

				return MergeTwoLists(list1, list2.next);
			}
			else
			{
				list1.next = MergeTwoLists(list1.next, list2);
			}

			return list1;
		}

		public static int RemoveDuplicates(int[] nums)
		{
			int k = 1;
			int current = 0;

			for (int i = 0; i < nums.Length - 1; i++)
			{
				if (nums[current] == nums[i + 1])
				{
					continue;
				}
				else
				{
					current++;
					k++;
					nums[current] = nums[i + 1];
				}
			}

			return k;
		}

		public static int RemoveElement(int[] nums, int val)
		{
			int k = 0;
			int current = 0;

			for (int i = 0; i < nums.Length; i++)
			{
				if (nums[i] == val)
				{
					continue;
				}
				else
				{
					nums[current] = nums[i];
					current++;
					k++;
				}
			}

			nums = nums.Take(k).ToArray();

			return k;
		}

		public static int StrStr(string haystack, string needle)
		{
			int current = 0;

			for (int i = 0; i < haystack.Length; i++)
			{
				if (haystack[i] == needle[0])
				{
					if (i + needle.Length > haystack.Length)
					{
						return -1;
					}

					for (int j = i; j < i + needle.Length; j++)
					{
						if (needle[current] == haystack[j])
						{
							current++;
							if (current == needle.Length)
							{
								return i;
							}
						}
						else
						{
							current = 0;
							break;
						}
					}
				}
			}

			return -1;
		}

		public static int SearchInsert(int[] nums, int target)
		{
			int index = 0;

			for (int i = 0; i < nums.Length; i++)
			{
				if (nums[i] == target)
				{
					index = i;
					break;
				}
				else if (nums[i] > target)
				{
					index = i--;
					break;
				}
			}

			if (nums[nums.Length - 1] < target)
			{
				index = nums.Length;
			}

			return index;
		}

		public static int LengthOfLastWord(string s)
		{
			return s.Trim().Split(" ").Last().Length;
		}

		public static int[] PlusOne(int[] digits)
		{
			string numsS = "";

			for (int i = 0; i < digits.Length; i++)
			{
				numsS += digits[i];
			}

			BigInteger num = BigInteger.Parse(numsS);

			numsS = (num + 1).ToString();

			digits = new int[numsS.Length];

			for (int i = 0; i < numsS.Length; i++)
			{
				digits[i] = int.Parse(numsS[i].ToString());
			}

			return digits;
		}

		public static string AddBinary(string a, string b)
		{
			List<int> sum = new List<int>();
			for (int i = a.Length - 1, j = b.Length - 1, carry = 0; i >= 0 || j >= 0 || carry > 0;)
			{
				var firstDigit = i >= 0 ? a[i--] - '0' : 0;
				var secondDigit = j >= 0 ? b[j--] - '0' : 0;
				var sumDigit = firstDigit + secondDigit + carry;
				carry = sumDigit / 2;
				sum.Add(sumDigit % 2);
			}

			sum.Reverse();
			return String.Concat(sum);
		}

		public static int MySqrt(int x)
		{
			return (int)Math.Sqrt(x);
		}
	}
}
