using System.Linq;
using System.Security.Cryptography;

namespace HFSExtract
{
    public class HFSUtils
    {
        public static uint OverflowToInt(byte[] lpData, int index)
        {
            unchecked
            {
                var A = (sbyte)lpData[index];
                var B = (sbyte)lpData[index + 1];
                var C = (sbyte)lpData[index + 2];
                var D = (sbyte)lpData[index + 3];

#pragma warning disable 675
                return (uint)(D | ((C | ((B | (A << 8)) << 8)) << 8));
#pragma warning restore 675
            }
        }

        private const int KEY_ITER = 0x3F;
        private const int KEY_SIZE = 128;
        private const int HASH_SIZE = 16;

        private static string STATIC_KEY = "MBHEROES!@0u9";

        public static byte[] GenerateEncodingKey(string key)
        {
            char[] keyBuffer = (key.ToLower() + STATIC_KEY).ToArray();
            var keyBlob = new byte[KEY_SIZE];
            for (var i = 0; i < KEY_SIZE; i++)
            {
                int index = keyBuffer.Length - (i % KEY_ITER + 1);
                keyBlob[i] = (byte)(i + ((byte)i % 3 + 2) * (byte)keyBuffer[index]);
            }

            return keyBlob;
        }

        public static byte[] GenerateEncodingKey(char[] keyBuffer)
        {
            //  char[] keyBuffer = (key.ToLower() + STATIC_KEY).ToArray();
            var keyBlob = new byte[KEY_SIZE];
            for (var i = 0; i < KEY_SIZE; i++)
            {
                int index = keyBuffer.Length - (i % KEY_ITER + 1);
                keyBlob[i] = (byte)(i + ((byte)i % 3 + 2) * (byte)keyBuffer[index]);
            }
            return keyBlob;
        }

    }
}
