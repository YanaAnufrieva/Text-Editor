using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextEditorMVC
{
    internal class LexerController
    {
        Lexer lexer = new();

        List<LexemaInfo> lexemes = new List<LexemaInfo>();
        List<Error> errors = new List<Error>();

        public List<LexemaInfo> Lexemes { get { return lexemes; } }
        public List<Error> Errors { get { return errors; } }

        public bool LexicalAnalysis(string code)
        {
            if (code == null) return false;

            if (lexer.LexicalAnalysis(code) == true)
            {
                lexemes = lexer.Lexemes;
                return true;
            }
            else
            {
                errors = lexer.Errors;
                return false;
            }
        }
    }
}
