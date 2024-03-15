using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using TextEditorMVC.Models;
using System.CodeDom.Compiler;

namespace TextEditorMVC
{
    internal class Lexer
    {
        List<LexemaInfo> lexemes = new();
        List<Error> errors = new();
        string code;

        public List<LexemaInfo> Lexemes
        {
            get { return lexemes; }
        }

        public List<Error> Errors
        {
            get { return errors; }
        }
        public string Code
        {
            get { return code; }
        }

        public Lexer(string code)
        {
            this.code = code;
        }

        public void LexicalAnalysis()
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
                    while (Char.IsLetter(code[j]) || Char.IsDigit(code[j]) || code[j] == '_')
                    {
                        j++;
                        if (j >= code.Length)
                        {
                            break;
                        }
                    }
                    subText = code.Substring(i, j - i);

                    if (IsKeywordConst(subText))
                    {
                        lexemes.Add(new LexemaInfo(subText, i, LexemaTypes.dict[1]));
                    }
                    else if (IsKeywordVal(subText))
                    {
                        lexemes.Add(new LexemaInfo(subText, i, LexemaTypes.dict[2]));
                    }
                    else if (IsKeywordDouble(subText))
                    {
                        lexemes.Add(new LexemaInfo(subText, i, LexemaTypes.dict[3]));
                    }
                    else if (IsVariableName(subText))
                    {
                        lexemes.Add(new LexemaInfo(subText, i, LexemaTypes.dict[4]));
                    }
                    else
                    {
                        errors.Add(new Error(i, $"Ошибка в названии идентификатора"));
                    }
                    i = j;
                }
                else if (code[i] == '_')
                {
                    int j = i + 1;
                    while (Char.IsLetter(code[j]) || Char.IsDigit(code[j]) || code[j] == '_')
                    {
                        j++;
                        if (j >= code.Length)
                        {
                            break;
                        }
                    }
                    subText = code.Substring(i, j - i);

                    if (IsVariableName(subText))
                    {
                        lexemes.Add(new LexemaInfo(subText, i, LexemaTypes.dict[4]));
                    }
                    i = j;
                }
                else if (IsSpace(code[i].ToString()))
                {
                    lexemes.Add(new LexemaInfo(code[i].ToString(), i, LexemaTypes.dict[5]));
                    i++;
                }
                else if (IsAssignmentOperator(code[i].ToString()))
                {
                    lexemes.Add(new LexemaInfo(code[i].ToString(), i, LexemaTypes.dict[6]));
                    i++;
                }
                else if (IsColon(code[i].ToString()))
                {
                    lexemes.Add(new LexemaInfo(code[i].ToString(), i, LexemaTypes.dict[7]));
                    i++;
                }
                else if (Char.IsNumber(code[i]) || code[i] == '+' || code[i] == '-')
                {
                    int j = i + 1;
                    while (Char.IsNumber(code[j]) || code[j] == '.')
                    {
                        j++;
                        if (j >= code.Length)
                        {
                            break;
                        }
                    }

                    subText = code.Substring(i, j - i);

                    if (IsRealNumber(subText))
                    {
                        lexemes.Add(new LexemaInfo(subText, i, LexemaTypes.dict[8]));
                    }
                    else
                    {
                        errors.Add(new Error(i, $"Ошибка в написании вещественного числа."));
                    }

                    i = j;
                }
                else if (IsEndOfOperator(code[i].ToString()))
                {
                    lexemes.Add(new LexemaInfo("\\n", i, LexemaTypes.dict[9]));
                    i++;
                }
                else if (code[i] == '\r')
                {
                    int j = i + 1;
                    if (IsEndOfOperator(code[j].ToString()))
                    {
                        lexemes.Add(new LexemaInfo("\\n", i, LexemaTypes.dict[9]));
                    }
                    i = j + 1;
                }
                else
                {
                    errors.Add(new Error(i, $"Ошибка: недопустимый символ"));
                    i++;
                }
            }
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
            CodeDomProvider provider = CodeDomProvider.CreateProvider("C#");
            if (provider.IsValidIdentifier(text))
            {
                return true;
            }
            else
            {
                return false;
            }
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
            return double.TryParse(text, NumberStyles.Any, CultureInfo.InvariantCulture, out var parsedDoubleNumber);
        }
    }
}
