using System.Security.Cryptography;
using System.Text;
using MD5OnlineGenerator.BusinessLogic.Utilities.Interfaces;

namespace MD5OnlineGenerator.BusinessLogic.Utilities.Impl
{
    public class MD5ChecksumGenerator : IChecksumGenerator
    {
        public string CalculateHash(string input)
        {
            // step 1, calculate MD5 hash from input
            var md5 = MD5.Create();

            var inputBytes = Encoding.ASCII.GetBytes(input);

            byte[] hash = md5.ComputeHash(inputBytes);

            // step 2, convert byte array to hex string
            var sb = new StringBuilder();

            foreach (var t in hash)
            {
                sb.Append(t.ToString("X2"));
            }

            return sb.ToString();
        }
    }
}
