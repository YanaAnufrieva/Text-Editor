using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextEditorMVC.Models
{
    internal class LexemaVM
    {
        public int Line { get; set; }
        public int StartPosition { get; set; }
        public int EndPosition { get; set; }
        public int Code { get; set; }
        public string Name { get; set; }
        public string Text { get; set; }
    }
}
