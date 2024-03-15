using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextEditorMVC.Models;

namespace TextEditorMVC
{
    internal class LexemaInfo
    {
        public int Position { get; }
        public LexemaType LexemaType { get; }
        public string Text { get; }

        public LexemaInfo(string text, int Position, LexemaType lexemaType)
        {
            this.Text = text;
            this.Position = Position;
            this.LexemaType = lexemaType;
        }
    }
}
