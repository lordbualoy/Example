using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using N = System.IO.Compression;

namespace DeflateStream
{
    class Program
    {
        static void Main(string[] args)
        {
            byte[] input = new byte[] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, };
            byte[] compressed;
            using (MemoryStream outputStream = new MemoryStream())
            {
                using (N.DeflateStream compressionStream = new N.DeflateStream(outputStream, N.CompressionMode.Compress))
                {
                    compressionStream.Write(input, 0, input.Length);
                }
                compressed = outputStream.ToArray();
            }
            byte[] output = new byte[input.Length];
            using (MemoryStream inputStream = new MemoryStream())
            {
                inputStream.Write(compressed, 0, compressed.Length);
                inputStream.Position = 0;
                using (N.DeflateStream compressionStream = new N.DeflateStream(inputStream, N.CompressionMode.Decompress))
                {
                    compressionStream.Read(output, 0, output.Length);
                }
            }
        }
    }
}
