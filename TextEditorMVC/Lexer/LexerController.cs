using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextEditorMVC.Models;

namespace TextEditorMVC
{
    internal class LexerController
    {
        Lexer lexer;

        public string Code
        {
            get { return lexer.Code; }
        }

        public bool LexicalAnalysis(string code)
        {
            if (code == null || code.Length == 0) return false;

            lexer = new Lexer(code);
            lexer.LexicalAnalysis();

            if (lexer.Errors.Count == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<LexemaInfo> GetLexemes()
        {
            return lexer.Lexemes;
        }

        public ObservableCollection<LexemaVM> GetLexemesVM()
        {
            if (lexer.Lexemes.Count > 0)
            {
                ObservableCollection<LexemaVM> lexemes = new ObservableCollection<LexemaVM>();

                foreach (LexemaInfo lexema in lexer.Lexemes)
                {
                    Tuple<int, int> pos = TextHelper.GetPosition(lexema.Position);

                    LexemaVM item = new LexemaVM()
                    {
                        Line = pos.Item2,
                        StartPosition = pos.Item1,
                        EndPosition = pos.Item1 + lexema.Text.Length - 1,
                        Code = lexema.LexemaType.Code,
                        Name = lexema.LexemaType.Name,
                        Text = lexema.Text,
                    };

                    lexemes.Add(item);
                }

                return lexemes;
            }
            return new ObservableCollection<LexemaVM>();
        }

        public ObservableCollection<ErrorVM> GetErrors()
        {
            if (lexer.Errors.Count > 0)
            {
                ObservableCollection<ErrorVM> errors = new ObservableCollection<ErrorVM>();

                foreach (Error error in lexer.Errors)
                {
                    Tuple<int, int> pos = TextHelper.GetPosition(error.Position);

                    ErrorVM item = new ErrorVM()
                    {
                        Line = pos.Item2,
                        Symbol = pos.Item1,
                        ErrorMessage = error.ErrorMessage,
                    };

                    errors.Add(item);
                }

                return errors;
            }
            return new ObservableCollection<ErrorVM>();
        }
    }
}
