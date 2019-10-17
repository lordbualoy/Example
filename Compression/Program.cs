using System;
using System.IO;
using System.IO.Compression;
using System.Text;

namespace Compression
{
    class Program
    {
        static void Main(string[] args)
        {
            Gzip();
            Deflate();

            void Gzip()
            {
                byte[] data = Encoding.UTF8.GetBytes(new string('0', 1000));
                byte[] compressed = data.CompressWithGzip();
                byte[] decompressed = compressed.DecompressWithGzip();
                string result = Encoding.UTF8.GetString(decompressed);
            }
            void Deflate()
            {
                byte[] data = Encoding.UTF8.GetBytes(new string('0', 1000));
                byte[] compressed = data.CompressWithDeflate();
                byte[] decompressed = compressed.DecompressWithDeflate();
                string result = Encoding.UTF8.GetString(decompressed);
            }
        }
    }

    static class Extension
    {
        public static byte[] CompressWithGzip(this byte[] value)
        {
            using (MemoryStream src = new MemoryStream(value))
            using (MemoryStream dest = new MemoryStream())
            {
                src.CompressWithGzip(dest);
                return dest.ToArray();
            }
        }

        public static byte[] DecompressWithGzip(this byte[] value)
        {
            using (MemoryStream src = new MemoryStream(value))
            using (MemoryStream dest = new MemoryStream())
            {
                src.DecompressWithGzip(dest);
                return dest.ToArray();
            }
        }

        public static void CompressWithGzip(this Stream value, Stream destination)
        {
            using (GZipStream gzStream = new GZipStream(destination, CompressionMode.Compress))
                value.CopyTo(gzStream);
        }

        public static void DecompressWithGzip(this Stream value, Stream destination)
        {
            using (GZipStream gzStream = new GZipStream(value, CompressionMode.Decompress))
                gzStream.CopyTo(destination);
        }

        public static byte[] CompressWithDeflate(this byte[] value)
        {
            using (MemoryStream src = new MemoryStream(value))
            using (MemoryStream dest = new MemoryStream())
            {
                src.CompressWithDeflate(dest);
                return dest.ToArray();
            }
        }

        public static byte[] DecompressWithDeflate(this byte[] value)
        {
            using (MemoryStream src = new MemoryStream(value))
            using (MemoryStream dest = new MemoryStream())
            {
                src.DecompressWithDeflate(dest);
                return dest.ToArray();
            }
        }

        public static void CompressWithDeflate(this Stream value, Stream destination)
        {
            using (DeflateStream deflateStream = new DeflateStream(destination, CompressionMode.Compress))
                value.CopyTo(deflateStream);
        }

        public static void DecompressWithDeflate(this Stream value, Stream destination)
        {
            using (DeflateStream deflateStream = new DeflateStream(value, CompressionMode.Decompress))
                deflateStream.CopyTo(destination);
        }
    }
}
