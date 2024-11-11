using System.Security.Cryptography;
using System.Text;

namespace DataAccess.Utils
{
    public class Cryptography
    {
        public string Encrypt(string plainText)
        {
            if (plainText == null) throw new ArgumentNullException("plainText");

            byte[] encData_byte = new byte[plainText.Length];
            encData_byte = Encoding.UTF8.GetBytes(plainText);
            string encodedData = Convert.ToBase64String(encData_byte);
            return encodedData;
        }

        public string Decrypt(string cipher)
        {
            if (cipher == null) throw new ArgumentException("cipher");
            UTF8Encoding encoder = new UTF8Encoding();
            Decoder utf8Decode = encoder.GetDecoder();
            byte[] todecode_byte = Convert.FromBase64String(cipher);
            int charCount = utf8Decode.GetCharCount(todecode_byte, 0, todecode_byte.Length);
            char[] decoded_char = new char[charCount];
            utf8Decode.GetChars(todecode_byte, 0, todecode_byte.Length, decoded_char, 0);
            string result = new String(decoded_char);
            return result;
        }
    }
}
