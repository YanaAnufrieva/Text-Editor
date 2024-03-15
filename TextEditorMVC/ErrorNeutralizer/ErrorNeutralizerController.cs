using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextEditorMVC
{
    internal class ErrorNeutralizerController
    {
        ErrorNeutralizer errorNeutralizer;

        public List<LexemaInfo> NeutralizingErrors(List<LexemaInfo> lexemes)
        {
            errorNeutralizer = new(lexemes);

            return errorNeutralizer.NeutralizingErrors();
        }
    }
}
