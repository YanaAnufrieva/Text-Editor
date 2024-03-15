using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextEditorMVC.Models;

namespace TextEditorMVC
{
    internal class ParserController
    {
        Parser parser;

        public bool SyntacticAnalysis(List<LexemaInfo> lexemes)
        {
            if (lexemes == null || lexemes.Count == 0) return false;

            parser = new Parser(lexemes);
            parser.SyntacticAnalysis();

            if (parser.Errors.Count == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public ObservableCollection<ErrorVM> GetErrors()
        {
            if (parser.Errors.Count > 0)
            {
                ObservableCollection<ErrorVM> errors = new ObservableCollection<ErrorVM>();

                foreach (Error error in parser.Errors)
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
