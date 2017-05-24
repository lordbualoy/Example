using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Endianness
{
    class Program
    {
        static void Main(string[] args)
        {
            //Single Hexadecimal Digit == 4 Bits  //0xF == 1111
            //Single Byte == 8 Bits     //which means 1 Byte could hold the 2 digits of Hexadecimal number
            //Single Int32 == 4 Bytes

            byte[] binaryData = { 0, 1, 0, 0 };
            //equivalent to:
            //binaryData[0] == 0;
            //binaryData[1] == 1;
            //binaryData[2] == 0;
            //binaryData[3] == 0;

            byte[] binaryData2 = new byte[binaryData.Length];
            Buffer.BlockCopy(binaryData, 0, binaryData2, 0, binaryData.Length);
            Array.Reverse(binaryData2, 0, binaryData2.Length);
            //equivalent to:
            //binaryData[0] == 0;
            //binaryData[1] == 0;
            //binaryData[2] == 1;
            //binaryData[3] == 0;

            bool isLittleEndian = BitConverter.IsLittleEndian;
            int data1 = BitConverter.ToInt32(binaryData, 0);    //256    got intepreted as   0x0010 in little endian system; would have been 65536 (0x0100) in big endian system
            int data2 = BitConverter.ToInt32(binaryData2, 0);   //65536  got intepreted as   0x0100 in little endian system; would have been 256 (0x0010) in big endian system

            //test result
            //if (BitConverter.IsLittleEndian)
            //    binaryData[0] == 0;   Least Significant Byte
            //    binaryData[1] == 1;
            //    binaryData[2] == 0;
            //    binaryData[3] == 0;   Most Significant Byte
            //else
            //    binaryData[0] == 0;   Most Significant Byte
            //    binaryData[1] == 1;
            //    binaryData[2] == 0;
            //    binaryData[3] == 0;   Least Significant Byte
        }
    }
}
