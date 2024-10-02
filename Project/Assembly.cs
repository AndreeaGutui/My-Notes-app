using System;
using System.Drawing;
using System.Windows.Forms;

namespace Project
{
    internal class Assembly : ProgrammingLanguages
    {
        public Assembly(RichTextBox textBox) : base(textBox, Color.DarkGreen)
        {
            keywords = new string[] {".model", ".data",".code", "db", "dw","dd", "dq","proc", "endp", "mov", "add", "adc","mul","inc","dec",
                "jmp","je", "jne", "small", "tiny", "large", "huge", "loop", "jz","jnz","push", "pop", "call", "ret", "lea", "sub",
                 "ch", "cl", "int", "cmp", "and", "or", "xor", "not", "nop", "shr", "shl", "jg", "jge", "jl", "jle", 
                "word ptr","byte ptr", "aaa", "daa","cld", "clc", "cmpsb", "cmpsw", "div", "imul", "in", "lodsb", "lodsw", "loopx", "movsb", "movsw",
                "xchg", "xlat", "test", "stosb", "stosw", "std", "sbb", "sar", "sal", "ror", "rol", "rep", "pushf", "popf", "neg", "lds", "jcxz", "cwd", ".stack", "bp", "sp", "far",
                "near"
            };
        }
    }
}
