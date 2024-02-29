using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace TextEditorMVC
{
    internal class Lexer
    {
        List<LexemaInfo> lexemes = new();
        List<Error> errors;

        public List<LexemaInfo> Lexemes
        {
            get { return lexemes; }
        }

        public List<Error> Errors
        {
            get { return errors; }
        }

        public bool LexicalAnalysis(string code)
        {
            lexemes = new();
            errors = new();

            string subText = "";

            int i = 0;
            while (i < code.Length)
            {
                if (Char.IsLetter(code[i]))
                {
                    int j = i + 1;
                    while (Char.IsLetter(code[j]))
                    {
                        j++;
                        if (j >= code.Length)
                        {
                            break;
                        }
                    }
                    subText = code.Substring(i, j - i);

                    i++;
                    if (IsKeywordConst(subText))
                    {
                        lexemes.Add(new LexemaInfo(subText, i, 1, "Ключевое слово - const"));
                    }
                    else if (IsKeywordVal(subText))
                    {
                        lexemes.Add(new LexemaInfo(subText, i, 2, "Ключевое слово - val"));
                    }
                    else if (IsKeywordDouble(subText))
                    {
                        lexemes.Add(new LexemaInfo(subText, i, 3, "Ключевое слово - Double"));
                    }
                    else if (IsVariableName(subText))
                    {
                        lexemes.Add(new LexemaInfo(subText, i, 4, "Идентификатор"));
                    }
                    else
                    {
                        errors.Add(new Error(i, $"Ошибка в названии идентификатора"));
                        return false;
                    }
                    i = j;
                }
                else if (IsSpace(code[i].ToString()))
                {
                    lexemes.Add(new LexemaInfo(code[i].ToString(), i + 1, 5, "Разделитель - пробел"));
                    i++;
                }
                else if (IsAssignmentOperator(code[i].ToString()))
                {
                    lexemes.Add(new LexemaInfo(code[i].ToString(), i + 1, 6, "Оператор присваивания"));
                    i++;
                }
                else if (IsColon(code[i].ToString()))
                {
                    lexemes.Add(new LexemaInfo(code[i].ToString(), i + 1, 7, "Оператор принадлежности к типу - двоеточие"));
                    i++;
                }
                else if (Char.IsNumber(code[i]))
                {
                    int j = i;
                    while (Char.IsNumber(code[j]) || code[j] == '.')
                    {
                        j++;
                        if (j >= code.Length)
                        {
                            break;
                        }
                    }

                    subText = code.Substring(i, j - i);

                    i++;
                    if (IsRealNumber(subText))
                    {
                        lexemes.Add(new LexemaInfo(subText, i, 8, "Вещественное число"));
                    }
                    else
                    {
                        errors.Add(new Error(i, $"Ошибка в написании вещественного числа."));
                        return false;
                    }

                    i = j;
                }
                else if (IsEndOfOperator(code[i].ToString()))
                {
                    lexemes.Add(new LexemaInfo("\\n", i + 1, 9, "Конец оператора - перенос на новую строку"));
                    i++;
                }
                else if (code[i] == '\r')
                {
                    i++;
                }
                else
                {
                    errors.Add(new Error(i, $"Ошибка"));
                    return false;
                }
            }
            return true;
        }

        bool IsKeywordConst(string text)
        {
            return (text == "const");
        }

        bool IsKeywordVal(string text)
        {
            return (text == "val");
        }

        bool IsKeywordDouble(string text)
        {
            return (text == "Double");
        }

        bool IsVariableName(string text)
        {
            return (text != "const") && (text != "val") && (text != "Double");
        }

        bool IsSpace(string text)
        {
            return (text == " ");
        }

        bool IsAssignmentOperator(string text)
        {
            return (text == "=");
        }

        bool IsColon(string text)
        {
            return (text == ":");
        }

        bool IsEndOfOperator(string text)
        {
            return (text == "\n");
        }

        static bool IsRealNumber(string text)
        {
            return text.Contains('.') && double.TryParse(text, NumberStyles.Any, CultureInfo.InvariantCulture, out var parsedDoubleNumber);
        }
    }
}
