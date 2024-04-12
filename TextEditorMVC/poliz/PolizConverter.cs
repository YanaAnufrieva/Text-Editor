using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextEditorMVC.poliz
{
	internal static class PolizConverter
	{
		static int GetPriority(char op)
		{
			switch (op)
			{
				case '+':
				case '-':
					return 1;
				case '*':
				case '/':
					return 2;
				case '^':
					return 3;
				default:
					return 0;
			}
		}

		public static string InfixToPostfix(string infix)
		{
			string postfix = "";
			Stack<char> operatorStack = new Stack<char>();

			for (int i = 0; i < infix.Length; i++)
			{
				char c = infix[i];
				if (char.IsDigit(c))
				{
					// Считываем двузначное число
					string number = c.ToString();
					while (i + 1 < infix.Length && char.IsDigit(infix[i + 1]))
					{
						number += infix[i + 1];
						i++;
					}
					postfix += number + " ";
				}
				else if (c == '(')
				{
					operatorStack.Push(c);
				}
				else if (c == ')')
				{
					while (operatorStack.Count > 0 && operatorStack.Peek() != '(')
					{
						postfix += operatorStack.Pop() + " ";
					}
					operatorStack.Pop(); // Извлекаем открывающую скобку из стека
				}
				else if (IsOperator(c))
				{
					while (operatorStack.Count > 0 && GetPriority(operatorStack.Peek()) >= GetPriority(c))
					{
						postfix += operatorStack.Pop() + " ";
					}
					operatorStack.Push(c);
				}
			}

			while (operatorStack.Count > 0)
			{
				postfix += operatorStack.Pop() + " ";
			}

			return postfix.Trim();
		}

		static bool IsOperator(char c)
		{
			return c == '+' || c == '-' || c == '*' || c == '/' || c == '^';
		}

	}
}
