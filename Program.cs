using Common;
using HFSExtract;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace HFSTest
{
    class Program
    {
        private static byte[] NEW = new byte[]{
        (byte)0x78,(byte)0x1D,(byte)0xCD,(byte)0x3E,(byte)0x89,(byte)0x4C,(byte)0x97,(byte)0xFE,(byte)0x1B,(byte)0xB1,(byte)0x5F,(byte)0x2D,(byte)0x8D,(byte)0xE1,(byte)0x62,(byte)0x0A,
        (byte)0x81,(byte)0x67,(byte)0x19,(byte)0x5B,(byte)0x0F,(byte)0xCE,(byte)0xE9,(byte)0xD2,(byte)0xBE,(byte)0xDF,(byte)0x49,(byte)0x96,(byte)0x5D,(byte)0xCA,(byte)0xFB,(byte)0x8B,
        (byte)0x9B,(byte)0x63,(byte)0x1E,(byte)0xD5,(byte)0xBA,(byte)0x10,(byte)0x52,(byte)0x8B,(byte)0x21,(byte)0xEC,(byte)0x17,(byte)0x2C,(byte)0x7E,(byte)0x82,(byte)0x24,(byte)0x1B,
        (byte)0xFA,(byte)0x21,(byte)0x15,(byte)0x74,(byte)0x89,(byte)0x16,(byte)0xD4,(byte)0xFC,(byte)0x59,(byte)0x61,(byte)0xC6,(byte)0x46,(byte)0x79,(byte)0xAD,(byte)0x0A,(byte)0x00,
        (byte)0x01,(byte)0x11,(byte)0xA9,(byte)0x06,(byte)0xDA,(byte)0x04,(byte)0xA8,(byte)0x5F,(byte)0x49,(byte)0x9E,(byte)0xE5,(byte)0xF5,(byte)0x2C,(byte)0x9F,(byte)0x4A,(byte)0x48,
        (byte)0x13,(byte)0xFD,(byte)0x9A,(byte)0x41,(byte)0x01,(byte)0xFB,(byte)0xF5,(byte)0x00,(byte)0x84,(byte)0x98,(byte)0x49,(byte)0xE8,(byte)0x48,(byte)0xB7,(byte)0x12,(byte)0x6C,
        (byte)0xC6,(byte)0x34,(byte)0xA0,(byte)0x4C,(byte)0x1B,(byte)0x63,(byte)0x65,(byte)0x02,(byte)0xB5,(byte)0x22,(byte)0x16,(byte)0x8A,(byte)0x40,(byte)0x51,(byte)0xDF,(byte)0xFE,
        (byte)0xA4,(byte)0x72,(byte)0xE3,(byte)0xAA,(byte)0xCC,(byte)0xFF,(byte)0x8A,(byte)0x89,(byte)0xC0,(byte)0xB9,(byte)0x8A,(byte)0x95,(byte)0x52,(byte)0xF8,(byte)0x4B,(byte)0x69,
        (byte)0xA8,(byte)0xDA,(byte)0x7E,(byte)0x37,(byte)0x96,(byte)0x8A,(byte)0x13,(byte)0x10,(byte)0xA3,(byte)0x57,(byte)0xC9,(byte)0x59,(byte)0x86,(byte)0x50,(byte)0xEE,(byte)0x7B,
        (byte)0x97,(byte)0xE2,(byte)0x3D,(byte)0xBB,(byte)0xAA,(byte)0xD7,(byte)0x5A,(byte)0x37
        };
        private static byte[] OLD = new byte[] {
        (byte)0x0F,(byte)0x50,(byte)0x70,(byte)0xF0,(byte)0xE8,(byte)0xB1,(byte)0x53,(byte)0xA3,(byte)0xF2,(byte)0x64,(byte)0xEB,(byte)0xAE,(byte)0x9A,(byte)0x30,(byte)0xE5,(byte)0x1B,
        (byte)0xBE,(byte)0x9D,(byte)0x64,(byte)0x4A,(byte)0x3F,(byte)0x3E,(byte)0xF0,(byte)0x88,(byte)0x7B,(byte)0x23,(byte)0xA7,(byte)0x4B,(byte)0x31,(byte)0x7C,(byte)0x05,(byte)0x4E,
        (byte)0x7E,(byte)0x9B,(byte)0x36,(byte)0x8C,(byte)0x38,(byte)0x4F,(byte)0x38,(byte)0x52,(byte)0x9F,(byte)0x92,(byte)0xCE,(byte)0x8F,(byte)0xE1,(byte)0xA2,(byte)0x71,(byte)0x5F,
        (byte)0xCA,(byte)0x31,(byte)0xF6,(byte)0x85,(byte)0xF8,(byte)0x1C,(byte)0x78,(byte)0x41,(byte)0x7D,(byte)0x01,(byte)0xB5,(byte)0xA1,(byte)0x74,(byte)0xA4,(byte)0xD6,(byte)0x60,
        (byte)0xC4,(byte)0xE2,(byte)0x35,(byte)0x90,(byte)0x61,(byte)0x17,(byte)0xBC,(byte)0x7C,(byte)0x0F,(byte)0x34,(byte)0xA4,(byte)0x9C,(byte)0xE7,(byte)0x4B,(byte)0x6A,(byte)0xD4,
        (byte)0xD6,(byte)0xA1,(byte)0xAA,(byte)0x59,(byte)0x8E,(byte)0x68,(byte)0xEA,(byte)0xB5,(byte)0xDA,(byte)0x32,(byte)0xFC,(byte)0x53,(byte)0xC1,(byte)0xD2,(byte)0xB1,(byte)0xAE,
        (byte)0xD4,(byte)0xA4,(byte)0x9B,(byte)0x62,(byte)0x34,(byte)0xB2,(byte)0x7C,(byte)0x94,(byte)0xD5,(byte)0x2B,(byte)0x2D,(byte)0xF2,(byte)0xB6,(byte)0x83,(byte)0x3F,(byte)0xF9,
        (byte)0x83,(byte)0x06,(byte)0xFD,(byte)0x1A,(byte)0xE4,(byte)0x1E,(byte)0xCD,(byte)0xB0,(byte)0x7A,(byte)0xE7,(byte)0x95,(byte)0x33,(byte)0xC5,(byte)0x6C,(byte)0x80,(byte)0xCE,
        (byte)0x33,(byte)0xC7,(byte)0xFE,(byte)0x83,(byte)0x02,(byte)0xCF,(byte)0xD7,(byte)0xCD,(byte)0x46,(byte)0xED,(byte)0x79,(byte)0x5D,(byte)0xEB,(byte)0x1D,(byte)0x82,(byte)0x00,
        (byte)0x74,(byte)0x32,(byte)0x0F,(byte)0xBE,(byte)0xEF,(byte)0x79,(byte)0x03,(byte)0x0B
        };

        private static string NAME = "FE3FAA5BC9499699F9B75973D8997CF05C54ABE1_00002.hfs";

        public static bool Test(byte[] buffer, string key = "MBHEROES!@0u9", bool debug = true)
        {
            var serpent = new HFSSerpent();
            //Now we need to guess about this key
            //If the key is correct, then the following test can pass
            serpent.SetKey(HFSUtils.GenerateEncodingKey((NAME.ToLower() + key).ToCharArray()));
            serpent.Decrypt(buffer);
            using (var ms = new MemoryStream(buffer))
            {
                using (var marshal = new BinaryReader(ms))
                {
                    int resourceNameLength = marshal.ReadInt32();
                    if (resourceNameLength < 0 || resourceNameLength > 127)
                    {
                        if (debug)
                            Console.WriteLine("resourceNameLength is bad!");
                        return false;
                    }
                    var resourceName = Encoding.Unicode.GetString(marshal.ReadBytes(resourceNameLength * 2));//128*2
                    if (resourceName != "models/player/_anim/female/evy/pc_evy_transformation.txt")
                    {
                        if (debug)
                            Console.WriteLine("resourceName is bad!");
                        return false;
                    }
                }
            }
            if (debug)
                Console.WriteLine("good!");
            return true;
        }
        private static char[] POOL = "~!@#$%^&*()_+0123456789.-= abcdefghijklmnopqrstuvwxyz".ToCharArray();
        private static char[] POOL2 = "0123456789abcdefghijklmnopqrstuvwxyz".ToCharArray();
        private static string GenRandomKey(Random random, int size, char[] pool)
        {
            int N = pool.Length;
            char[] cs = new char[size];
            for (int i = 0; i < size; i++)
            {
                cs[i] = pool[random.Next(0, N)];
            }
            return new string(cs);
        }
        public static void Main(string[] args)
        {
            Test(OLD);//good
            var random = new Random((int)(TimeUtil.GetCurrentTimeMillis() / 100));
            Crack(random, 3, "MBHEROES!@", POOL2);
        }

        private static void Crack(Random random, int N , string prefix, char[] pool)
        {
            string pwd = GenRandomKey(random, N, pool);
            long i = 0;
            while (true)
            {
                i++;
                if (i % 100000 == 0)
                {
                    Console.WriteLine("try:" + i);
                }
                // Console.WriteLine(pwd);
                if (Test(NEW, prefix  + pwd, false))
                {
                    Console.WriteLine("Password is good:" + pwd);
                    break;
                }
                pwd = GenRandomKey(random, N, pool);
            }
        }
    }
}
