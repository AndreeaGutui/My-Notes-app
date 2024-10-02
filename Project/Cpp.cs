using System.Drawing;
using System.Windows.Forms;

namespace Project
{
    internal class Cpp : ProgrammingLanguages
    {
        public Cpp(RichTextBox textBox) : base(textBox, Color.Fuchsia)
        {
            keywords = new string[] { "auto", "else", "operator", "template", "break", "enum", "private", "this", "case",
                "extern", "protected", "throw", "catch", "float", "public", "try", "char", "for", "register", "typedef",
                "class", "friend", "return", "union", "const", "goto","short", "unsigned", "continue", "if", "signed", "virtual",
                "default", "inline", "sizeof", "void", "delete", "int", "static", "volatile", "do", "long", "struct", "while",
                "bool", "double", "string"
            };
        }
    }
}
