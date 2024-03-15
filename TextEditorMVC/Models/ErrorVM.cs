using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextEditorMVC.Models
{
    internal class ErrorVM
    {
        public int Line { get; set; }
        public int Symbol { get; set; }
        public string ErrorMessage { get; set; }
    }
}
