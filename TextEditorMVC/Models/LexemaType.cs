using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextEditorMVC.Models
{
    internal class LexemaType
    {
        public int Code { get; set; }
        public string Name { get; set; }

        public LexemaType(int code, string name)
        {
            Code = code;
            Name = name;
        }
    }

    internal static class LexemaTypes
    {
        public static Dictionary<int, LexemaType> dict = new()
        {
            { 1, new LexemaType(1, "ключевое слово - const") },
            { 2, new LexemaType(2, "ключевое слово - val") },
            { 3, new LexemaType(3, "ключевое слово - Double") },
            { 4, new LexemaType(4, "иденификатор") },
            { 5, new LexemaType(5, "разделитель - пробел") },
            { 6, new LexemaType(6, "оператор присвивания - '='") },
            { 7, new LexemaType(7, "оператор приндлежности к типу - ':'") },
            { 8, new LexemaType(8, "вещественное число") },
            { 9, new LexemaType(9, "конец оператора - переход на новую строку") },
        };
    }

}
