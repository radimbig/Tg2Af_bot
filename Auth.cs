using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Telegram2A
{
    public static class Auth
    {
        // Decode the Base32 encoded secret key
        public static byte[] Base32Decode(string base32)
        {
            const string base32Chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ234567";
            base32 = base32.TrimEnd('='); // Remove padding characters

            int byteCount = base32.Length * 5 / 8; // Calculate the expected number of bytes
            byte[] buffer = new byte[byteCount];

            int byteIndex = 0;
            int value = 0, bitsRemaining = 0;

            foreach (char c in base32)
            {
                int charValue = base32Chars.IndexOf(c);
                value = (value << 5) | charValue;
                bitsRemaining += 5;

                if (bitsRemaining >= 8)
                {
                    buffer[byteIndex++] = (byte)(value >> (bitsRemaining - 8));
                    bitsRemaining -= 8;
                }
            }

            return buffer;
        }


        public static string GenerateTwoFactorCode(string secretKey)
        {
            byte[] keyBytes = Base32Decode(secretKey);
            long timestamp = DateTimeOffset.Now.ToUnixTimeSeconds() / 30; // Generate code every 30 seconds
            byte[] timestampBytes = BitConverter.GetBytes(timestamp);

            // If the system is little-endian, reverse the byte order
            if (BitConverter.IsLittleEndian)
                Array.Reverse(timestampBytes);

            HMACSHA1 hmac = new HMACSHA1(keyBytes);
            byte[] hash = hmac.ComputeHash(timestampBytes);

            // Get the offset where the code starts
            int offset = hash[hash.Length - 1] & 0x0F;

            // Extract 4 bytes from the hash starting at the offset
            int binaryCode = (hash[offset] & 0x7F) << 24 |
                             (hash[offset + 1] & 0xFF) << 16 |
                             (hash[offset + 2] & 0xFF) << 8 |
                             (hash[offset + 3] & 0xFF);

            // Convert the binary code to a 6-digit decimal code
            int code = binaryCode % 1000000;
            return code.ToString("D6");
        }
    }
}
