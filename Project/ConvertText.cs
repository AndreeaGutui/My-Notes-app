using System;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace Project
{
    public class TextHandler
    {
        public string ConvertToHex(string text)
        {
                byte[] bytes = Encoding.ASCII.GetBytes(text);
                StringBuilder hexString = new StringBuilder();
                foreach (byte b in bytes)
                {
                    string temp = b.ToString("X");
                    temp.ToUpper();
                    hexString.Append(temp);
                }
                return hexString.ToString();
        }
        public string ConvertToBinary(string text)
        {
            byte[] bytes = Encoding.ASCII.GetBytes(text);
            StringBuilder binaryString = new StringBuilder();
            foreach (byte b in bytes)
            {
                binaryString.Append(Convert.ToString(b, 2));
            }
            return binaryString.ToString();
        }
        public string HexToNormalText(string text)
        {
            string base16 = "0123456789ABCDEF";
            string normalText = "";
            for (int i = 0; i < text.Length; i += 2)
            {
                int v1 = base16.IndexOf(text[i]);
                int v2 = base16.IndexOf(text[i + 1]);
                int value = 16 * v1 + v2;
                normalText += (char)value;
            }
            return normalText;
        }
    }
}
