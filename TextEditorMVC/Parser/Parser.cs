using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextEditorMVC.Models;

namespace TextEditorMVC
{
    internal class Parser
    {
        private List<LexemaInfo> lexemes = new();
        private List<Error> errors = new();
        public List<Error> Errors { get { return errors; } }

        public Parser(List<LexemaInfo> lexemes)
        {
            this.lexemes = lexemes;
        }

        public void SyntacticAnalysis()
        {
            errors = new();
            string correctString;
            int currentPos = 0;

            int numberOfLines = lexemes.Where(x => x.LexemaType.Equals(LexemaTypes.dict[9])).Count();
            numberOfLines -= TextHelper.NumberOfEmptyStrings(lexemes);

            int lexemesIndex = 0;
            int k = 0;
            while (k < numberOfLines)
            {
                if (k != numberOfLines)
                {
                    correctString = "12473689";
                }
                else
                {
                    correctString = "1247368";
                }

                for (int i = 0; i < correctString.Length; i++)
                {
                    int.TryParse(correctString[i].ToString(), out int currentLexemaCode);
                    if (lexemesIndex < lexemes.Count)
                    {
                        if (i == 0 && lexemes[lexemesIndex].LexemaType.Code == 9)
                        {
                            currentPos += lexemes[lexemesIndex].Text.Length;
                            lexemesIndex++;
                            break;
                        }

                        while (lexemesIndex < lexemes.Count && lexemes[lexemesIndex].Text == " ")
                        {
                            currentPos += lexemes[lexemesIndex].Text.Length;

                            lexemesIndex++;
                        }

                        if (lexemesIndex >= lexemes.Count)
                        {
                            break;
                        }

                        if (lexemes[lexemesIndex].LexemaType.Code == currentLexemaCode)
                        {
                            currentPos += lexemes[lexemesIndex].Text.Length;
                            lexemesIndex++;
                        }
                        else
                        {
                            errors.Add(new Error(currentPos - 1, $"Ожидается {LexemaTypes.dict[currentLexemaCode].Name}"));
                        }
                    }
                    else
                    {
                        errors.Add(new Error(currentPos - 1, $"Ожидается {LexemaTypes.dict[currentLexemaCode].Name}"));
                    }

                    if (i == correctString.Length - 1)
                    {
                        k++;
                    }
                }
            }
        }
    }
}
