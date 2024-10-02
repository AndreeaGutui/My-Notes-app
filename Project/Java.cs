using System.Drawing;
using System.Windows.Forms;

namespace Project
{
    internal class Java : ProgrammingLanguages
    {
        public Java(RichTextBox textBox) : base(textBox, Color.Purple)
        {
            keywords = new string[] { "abstract", "continue", "for", "new", "switch", "assert", "default","goto","package", "synchronized", "java.util.", "String", "double",
                "private", "this", "break",	"double", "implements", "protected", "throw", "byte", "else", "import", "public", "throws", "case", "enum", "instanceof", "return",
                "transient","catch", "extends", "int", "short", "try", "char", "final", "interface", "static", "void", "class", "finally", "long", "strictfp", "volatile", "const",	 		
                  "float", "native","super", "while"  
            };
        }
    }
}
