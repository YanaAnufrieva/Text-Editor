using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextEditorMVC
{
    internal class LexemaInfo
    {
        public int Position { get; }
        public int Code { get; }
        public string Type { get; }
        public string Text { get; }

        public LexemaInfo(string text, int position, int code, string type)
        {
            this.Text = text;
            this.Position = position;
            this.Code = code;
            this.Type = type;
        }
    }
}
