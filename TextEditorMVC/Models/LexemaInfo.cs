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
        public int StartPosition { get; }
        public int EndPosition { get; }

        public int Code { get; }
        public string Type { get; }
        public string Text { get; }

        public LexemaInfo(string text, int sPosition, int ePosition, int code, string type)
        {
            this.Text = text;
            this.StartPosition = sPosition;
            this.EndPosition = ePosition;
            this.Code = code;
            this.Type = type;
        }
    }
}
