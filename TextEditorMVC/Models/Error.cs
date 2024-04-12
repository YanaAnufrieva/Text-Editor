using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextEditorMVC
{
    internal class Error
    {
        public int Position { get; }
        public string ErrorMessage { get; }

        public Error(int position, string errorMessage)
        {
            this.Position = position;
            this.ErrorMessage = errorMessage;
        }
    }
}
