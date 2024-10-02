using System;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.MonthCalendar;

namespace Project
{
    public partial class frmMain : Form
    {

        string filePath = "";
        private bool isHighlighted= false;
        private bool isColored = false;
        private TextHandler _converter;
        private ProgrammingLanguages programmingLanguages;
        private StreamWriter sw;
        public frmMain()
        {
            InitializeComponent();
            _converter = new TextHandler();
            programmingLanguages = new ProgrammingLanguages(this.textBox);
            this.textBox.TextChanged += programmingLanguages.UpdateText;
        }
        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox.Undo();
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox.Cut();

        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox.Copy();
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox.Paste();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox.Clear();
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox.SelectAll();
        }


        private void zoomInToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (textBox.Font.Size < 20)
            {
                textBox.Font = new Font(textBox.Font.FontFamily, textBox.Font.Size + 1);
            }

        }

        private void zoomOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (textBox.Font.Size > 6)
            {
                textBox.Font = new Font(textBox.Font.FontFamily, textBox.Font.Size - 1);
            }
        }

        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fontDialog1.ShowDialog();
            textBox.SelectionFont= new Font(fontDialog1.Font.FontFamily, fontDialog1.Font.Size, fontDialog1.Font.Style);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(filePath))
            {
                 SaveFileDialog sfd = new SaveFileDialog() { Filter = "TextDocument|*.txt", ValidateNames = true };
                {
                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        
                        using (sw = new StreamWriter(sfd.FileName)) 
                        {
                            sw.WriteLineAsync(textBox.Text);
                            filePath = sfd.FileName;
                        }
                    }

                }

            }

     
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            filePath = "";
            this.Text = "MyNotes";
            textBox.Text = " ";
            sw.Close();
            
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog() { Filter = "TextDocument|*.txt", ValidateNames = true, Multiselect = false }; 
            
                if(ofd.ShowDialog() == DialogResult.OK && ofd.FileName != filePath)
                {

                    using(StreamReader sr= new StreamReader(ofd.FileName))
                    {
                        filePath = ofd.FileName;
                        Task<string> text= sr.ReadToEndAsync();
                        textBox.Text = text.Result;
                        this.Text = Path.GetFileName(filePath) +  " - MyNotes";

                    }
                }
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog() { Filter = "TextDocument|*.txt", ValidateNames = true };
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                using (sw = new StreamWriter(sfd.FileName))
                {
                    
                    sw.WriteLineAsync(textBox.Text);
                    filePath = sfd.FileName;
                    this.Text = Path.GetFileName(filePath) + " - MyNotes";
                }
                }
        }

        private void textBox_TextChanged(object sender, EventArgs e)
        {
            if(textBox.Text.Length > 0)
            {
                cutToolStripMenuItem.Enabled = true;
                copyToolStripMenuItem.Enabled = true;
            }

            else
            {
                cutToolStripMenuItem.Enabled = false;
                copyToolStripMenuItem.Enabled = false;
            }
        }

        private void wordWrapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(wordWrapToolStripMenuItem.Checked== true) {
                wordWrapToolStripMenuItem.Checked = false;
                textBox.WordWrap = false;

            }

            else
            {
                wordWrapToolStripMenuItem.Checked = false;
                textBox.WordWrap = false;
            }
        }

        private void textColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
           
            if(isColored == false){
                colorDialog1.ShowDialog();
                textBox.SelectionColor = colorDialog1.Color;
                
            }
            else textBox.SelectionColor = Color.Black;
            isColored = !isColored;

        }

        private void highlightToolStripMenuItem_Click(object sender, EventArgs e)
        {
            isHighlighted = !isHighlighted;
            if (isHighlighted == true) textBox.SelectionBackColor = Color.Yellow;
            else textBox.SelectionBackColor = Color.White;
        }

        private void convertToHexToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string text = textBox.Text;
            string hexText = _converter.ConvertToHex(text);
            textBox.Text = hexText;
        }

        private void convertFromHexToNormalTextToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string hexText = textBox.Text;
            string normalText = _converter.HexToNormalText(hexText);
            textBox.Text = normalText;
        }

        private void pythonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.textBox.TextChanged -= programmingLanguages.UpdateText;
            programmingLanguages = new Python(this.textBox);
            programmingLanguages.UpdateText(null, null);
            this.textBox.TextChanged += programmingLanguages.UpdateText;
        }

        private void assemblyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.textBox.TextChanged -= programmingLanguages.UpdateText;
            programmingLanguages = new Assembly(this.textBox);
            programmingLanguages.UpdateText(null, null);
            this.textBox.TextChanged += programmingLanguages.UpdateText;
        }

        private void javaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.textBox.TextChanged -= programmingLanguages.UpdateText;
            programmingLanguages = new Java(this.textBox);
            programmingLanguages.UpdateText(null, null);
            this.textBox.TextChanged += programmingLanguages.UpdateText;
        }

        private void cToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.textBox.TextChanged -= programmingLanguages.UpdateText;
            programmingLanguages = new Cpp(this.textBox);
            programmingLanguages.UpdateText(null, null);
            this.textBox.TextChanged += programmingLanguages.UpdateText;
        }

        private void cToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.textBox.TextChanged -= programmingLanguages.UpdateText;
            programmingLanguages = new CSharp(this.textBox);
            programmingLanguages.UpdateText(null, null);
            this.textBox.TextChanged += programmingLanguages.UpdateText;
        }

        private void convertToBinaryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string text = textBox.Text;
            string binaryText = _converter.ConvertToBinary(text);
            textBox.Text = binaryText;
        }

        private void convertFromBinaryToNormalTextToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }
    }
}















