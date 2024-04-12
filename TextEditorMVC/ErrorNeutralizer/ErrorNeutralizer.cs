using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextEditorMVC.Models;

namespace TextEditorMVC
{
    internal class ErrorNeutralizer
    {
        List<LexemaInfo> lexemes;

        public ErrorNeutralizer(List<LexemaInfo> lexemes)
        {
            this.lexemes = lexemes;
        }

        public List<LexemaInfo> NeutralizingErrors()
        {
            int prevLexema = 0, currentLexema = 0;
            int i = 0;
            while (i <  lexemes.Count) 
            {
                if (lexemes[i].LexemaType != ExpectedLexema(currentLexema, prevLexema))
                {
                    lexemes.RemoveAt(i);
                }
                else
                {
                    prevLexema = currentLexema;
                    currentLexema = lexemes[i].LexemaType.Code;
                    i++;

                }
            }

            return lexemes;
        }

        private LexemaType ExpectedLexema(int currentLexemaCode, int prevLexemaCode)
        {
            if (currentLexemaCode == 0)
            {
                return LexemaTypes.dict[1];
            }
            else if (currentLexemaCode == 1)
            {
                return LexemaTypes.dict[5];
            }
            else if (currentLexemaCode == 2)
            {
                return LexemaTypes.dict[5];
            }
            else if (currentLexemaCode == 3)
            {
                return LexemaTypes.dict[6];
            }
            else if (currentLexemaCode == 4)
            {
                return LexemaTypes.dict[7];
            }
            else if (currentLexemaCode == 5)
            {
                if (prevLexemaCode == 1)
                {
                    return LexemaTypes.dict[2];
                }
                else if (prevLexemaCode == 2)
                {
                    return LexemaTypes.dict[4];
                }
            }
            else if (currentLexemaCode == 6)
            {
                return LexemaTypes.dict[8];
            }
            else if (currentLexemaCode == 7)
            {
                return LexemaTypes.dict[3];
            }
            else if (currentLexemaCode == 8)
            {
                return LexemaTypes.dict[9];
            }
            else if (currentLexemaCode == 9)
            {
                return LexemaTypes.dict[1];
            }
            else if (currentLexemaCode == 10)
            {
				return LexemaTypes.dict[1];
			}

            return null;
        }
    }
}
