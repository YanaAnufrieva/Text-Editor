using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextEditorMVC
{
    internal static class TextHelper
    {
        public static string Text;

        public static string CreateTextFromLexemes(List<LexemaInfo> lexemes)
        {
            string result = String.Empty;

            foreach (LexemaInfo info in lexemes)
            {
                if (info.Text == "\\n")
                {
                    result += '\n';
                }
                else
                {
                    result += info.Text;
                }
            }

            return result;
        }

        public static Tuple<int, int> GetPosition(int position)
        {
            int lineNumber = 1;
            int charPosition = 1; // Позиция символа в строке (начинается с 1)

            // Найти номер строки и позицию в строке
            for (int i = 0; i < position && i < Text.Length; i++)
            {
                if (Text[i] == '\n')
                {
                    lineNumber++;
                    charPosition = 1; // Сбросить позицию, так как мы переходим на новую строку
                }
                else
                {
                    charPosition++;
                }
            }

            return new Tuple<int, int>(charPosition, lineNumber);
        }

        public static int NumberOfEmptyStrings(List<LexemaInfo> list)
        {
            int count = 0;

            for (int i = 1; i < list.Count; i++)
            {
                if (list[i].Text == "\\n" && list[i - 1].Text == list[i].Text)
                {
                    if (count == 0)
                    {
                        count++;
                    }
                    count++;
                }
            }

            return count;
        }
    }
}
