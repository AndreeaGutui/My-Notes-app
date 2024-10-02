using System.Drawing;
using System.Windows.Forms;

namespace Project
{
    public class Python : ProgrammingLanguages
    { 
        public Python(RichTextBox textBox):base(textBox, Color.OrangeRed)
        {
            keywords = new string[] { "def", "class", "if", "elif", "else", "while", "for", "try", "except", "finally", "with", "as",
                "raise", "assert", "import", "from", "nonlocal", "global", "pass", "return", "break", "continue", "del", "yield", "lambda", "print",
                "async", "not", "true", "false","and", "await", "is", "open", "file", "in"
            };
        }
    }

}

