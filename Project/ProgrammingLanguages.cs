using System;
using System.Drawing;
using System.Windows.Forms;

namespace Project
{
    public class ProgrammingLanguages
    {
        protected string[] keywords;
        private Color textColor;
        private RichTextBox textBox;
        public ProgrammingLanguages(RichTextBox textBox)
        {
            this.textColor = Color.Black;
            this.textBox = textBox;
            keywords = null;
        }
        public ProgrammingLanguages(RichTextBox textBox, Color textColor) {
            this.textColor = textColor;
            this.textBox = textBox;
            keywords = null;
        }
      
        public virtual void UpdateText(object sender, EventArgs keys)
        {
            if (keywords != null)
            {
                //pastreaza pozitia si lungimea selectiei
                int caretPosition = textBox.SelectionStart;
                int selectionLength = textBox.SelectionLength;
                //selecteaza tot textul si fa-l negru
                textBox.Select(0, textBox.TextLength);
                textBox.SelectionColor = Color.Black;
                //muta caret-ul la finalul textului
                textBox.Select(textBox.TextLength, 0);
                int l = keywords.Length;
                for (int i = 0; i < l; i++) //mergem pe cuvinte cheie existente
                {
                    //pastreaza index-ul de start(startIndex) si index-ul pentru aparitia cuvantului
                    int index=0, startIndex = 0; 
                    //verifica daca e cuvant sau nu(subsir sau nu)
                    bool word;
                  
                    //cautam toate aparitile cuvantului cheie
                    //IndexOf returneaza pozitia de inceput a unui subsir din text
                    //incepand de la o pozitie aleasa
                    while ((index = textBox.Text.IndexOf(keywords[i], startIndex)) != -1)
                    {
                        word = true; //presupunem ca ce am gasit e cuvant
                        if (index != 0) //pot sa ma uit inaintea sa?
                        {
                            char ch = textBox.Text[index - 1]; 
                            if (!Delimiter(ch)) word = false; //nu e delimitator, atunci nu e cuvant
                        }
                        
                        if ((index + keywords[i].Length) != textBox.TextLength) //pot sa ma uit dupa el?
                        {
                            char ch = textBox.Text[index + keywords[i].Length];
                            if (!Delimiter(ch)) word = false; //nu e delimitator, deci nu e cuvant
                        }
                        if (word) //daca e cuvant
                        {
                            textBox.Select(index, keywords[i].Length);
                            textBox.SelectionColor = textColor;
                            //coloreaza selectia
                        }
                        startIndex = index + keywords[i].Length; //cautam dupa cuvantul gasit din nou
                    }
                }
                    //restauram selectia de la inceput
                    textBox.SelectionStart = caretPosition; 
                    textBox.SelectionLength = selectionLength;
            }
        }
        public bool Digit(char ch)
        {
            if (ch >= '0' && ch <= '9') return true;
            return false;
        }
        public bool Letter(char ch)
        {
            if (ch >= 'a' && ch <= 'z') return true;
            if (ch >= 'A' && ch <= 'Z') return true;
            return false;
        }
      
        public bool Delimiter(char ch)
        {
            if (!Letter(ch) && !Digit(ch) && ch != '_')
                return true;
            return false;
        }
        
    }
}

