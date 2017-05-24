using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FloatingPoint
{
    class Program
    {
        static void Main(string[] args)
        {
            // 1   1000 0001   011 0000 0000 0000 0000 0000
            //(S)     (E)                  (F)
            //
            //In 32-bit (or 4 bytes) single-precision floating-point representation:
            //The left most bit is the sign bit (S), with 0 for positive numbers and 1 for negative numbers.
            //          In this example, 1 would represent negative numbers.
            //The following 8 bits represent exponent (E).
            //          In the normalized form, the actual exponent is E-=127 (also known as excess-127 or bias-127).
            //          This is because we need to represent both positive and negative exponent. With an 8-bit E, ranging from 0 to 255,
            //          the excess-127 scheme could provide actual exponent of -127 to 128.
            //          In this example, 1000 0001 is equal to 129D,
            //          E-=127 would be equals to E=129D-127D,
            //          E=2D.
            //The remaining 23 bits represents fraction (F).
            //          In the normalized form, the actual fraction is normalized with an implicit leading 1 in the form of F="1."+F
            //          In this example, 011 0000 0000 0000 0000 0000 is equal to F="1."+"011 0000 0000 0000 0000 0000",
            //          F=1.011 0000 0000 0000 0000 0000,
            //          F=1.375D.
            //In this example, (S) (E) (F) would results in (-)(1.375)*2^(2) or -1.375*2^2
            //                                              (S)  (F)     (E)

            //1 1000 0001 011 0000 0000 0000 0000 0000
            //1100 0000 1011 0000 0000 0000 0000 0000
            //  C    0    B    0    0    0    0    0
            byte[] binaryDataBigEndian = new byte[4] { 0xC0, 0xB0, 0x00, 0x00 };     //binaryData in Big Endian

            float result;
            if (BitConverter.IsLittleEndian)
            {
                //reverse binaryData in Big Endian to Little Endian
                byte[] binaryDataLittleEndian = new byte[binaryDataBigEndian.Length];
                Buffer.BlockCopy(binaryDataBigEndian, 0, binaryDataLittleEndian, 0, binaryDataLittleEndian.Length);
                Array.Reverse(binaryDataLittleEndian);

                result = BitConverter.ToSingle(binaryDataLittleEndian, 0);
            }
            else
            {
                result = BitConverter.ToSingle(binaryDataBigEndian, 0);
            }

            //0 1000 0010 111 1111 0000 0000 0000 0000
            //0100 0001 0111 1111 0000 0000 0000 0000
            //  4    1    7    F    0    0    0    0
            binaryDataBigEndian = new byte[4] { 0x41, 0x7F, 0x00, 0x00 };     //binaryData in Big Endian

            //S=+
            //E=3D Normalized (1000 0010 == 0x82 == 130D to 130D-127D)
            //F=1.9921875 Normalized (111 1111 to 1.111 1111)
            //(+)(1.9921875)2^(3)
            //1.9921875*2^3
            //15.9375
            if (BitConverter.IsLittleEndian)
            {
                //reverse binaryData in Big Endian to Little Endian
                byte[] binaryDataLittleEndian = new byte[binaryDataBigEndian.Length];
                Buffer.BlockCopy(binaryDataBigEndian, 0, binaryDataLittleEndian, 0, binaryDataLittleEndian.Length);
                Array.Reverse(binaryDataLittleEndian);

                result = BitConverter.ToSingle(binaryDataLittleEndian, 0);
            }
            else
            {
                result = BitConverter.ToSingle(binaryDataBigEndian, 0);
            }

            //De-Normalized Form: Normalized form has a serious problem, with an implicit leading 1 for the fraction, it cannot represent the number zero!
            //De-normalized form was devised to represent zero and other numbers that has a value approaching zero.
            //if E==0, the floating point numbers are being represent in the de-normalized form,
            //De-normalized form will have implicit leading 0 (instead of implicit leading 1) for the fraction;
            //and the actual exponent is always -126 (the E-=127 is ignored in this case: E=0 and E-=127 would result in E=-127).
            //So, the number zero can be represented with E=0 and F=0 (because 0.0×2^-126=0).

            //0 0000 0000 000 0000 0000 0000 0000 0001
            //0000 0000 0000 0000 0000 0000 0000 0001
            //  0    0    0    0    0    0    0    1
            binaryDataBigEndian = new byte[4] { 0x00, 0x00, 0x00, 0x01 };     //binaryData in Big Endian

            //S=+
            //E=-126D De-Normalized (E==0D to E=-126D)
            //F=1.1920928955078125E-07 De-Normalized (000 0000 0000 0000 0000 0001 to 0.000 0000 0000 0000 0000 0001)
            //(+)(1.1920928955078125E-07)2^(-126)
            //0.00000011920928955078125*2^-126
            //1.4012984643248170709237295832899E-45
            if (BitConverter.IsLittleEndian)
            {
                //reverse binaryData in Big Endian to Little Endian
                byte[] binaryDataLittleEndian = new byte[binaryDataBigEndian.Length];
                Buffer.BlockCopy(binaryDataBigEndian, 0, binaryDataLittleEndian, 0, binaryDataLittleEndian.Length);
                Array.Reverse(binaryDataLittleEndian);

                result = BitConverter.ToSingle(binaryDataLittleEndian, 0);
            }
            else
            {
                result = BitConverter.ToSingle(binaryDataBigEndian, 0);
            }

            //De-Normalized Form: representing zero
            //0 0000 0000 000 0000 0000 0000 0000 0000
            //0000 0000 0000 0000 0000 0000 0000 0000
            //  0    0    0    0    0    0    0    0
            binaryDataBigEndian = new byte[4] { 0x00, 0x00, 0x00, 0x00 };     //binaryData in Big Endian

            //S=+
            //E=-126D De-Normalized (E==0D to E=-126D)
            //F=0 De-Normalized (000 0000 0000 0000 0000 0000 to 0.000 0000 0000 0000 0000 0000)
            //(+)(0)2^(-126)
            //0*2^-126
            //0
            if (BitConverter.IsLittleEndian)
            {
                //reverse binaryData in Big Endian to Little Endian
                byte[] binaryDataLittleEndian = new byte[binaryDataBigEndian.Length];
                Buffer.BlockCopy(binaryDataBigEndian, 0, binaryDataLittleEndian, 0, binaryDataLittleEndian.Length);
                Array.Reverse(binaryDataLittleEndian);

                result = BitConverter.ToSingle(binaryDataLittleEndian, 0);
            }
            else
            {
                result = BitConverter.ToSingle(binaryDataBigEndian, 0);
            }

            //Infinity representation: if E=255D (1111 1111) and F=0D then the value will be infinity
            //0 1111 1111 000 0000 0000 0000 0000 0000
            //0111 1111 1000 0000 0000 0000 0000 0000
            //  7    F    8    0    0    0    0    0
            binaryDataBigEndian = new byte[4] { 0x7F, 0x80, 0x00, 0x00 };     //binaryData in Big Endian

            //S=+
            //E=128D (E=255, E-=127 to E=128)
            //F=0 Normalized (000 0000 0000 0000 0000 0000 to 1.000 0000 0000 0000 0000 0000)
            //(+)(1)2^(128)
            //1*2^128
            //3.4028236692093846346337460743177E+38, technically not infinity but IEE 754 said let this result represent infinity value
            if (BitConverter.IsLittleEndian)
            {
                //reverse binaryData in Big Endian to Little Endian
                byte[] binaryDataLittleEndian = new byte[binaryDataBigEndian.Length];
                Buffer.BlockCopy(binaryDataBigEndian, 0, binaryDataLittleEndian, 0, binaryDataLittleEndian.Length);
                Array.Reverse(binaryDataLittleEndian);

                result = BitConverter.ToSingle(binaryDataLittleEndian, 0);
            }
            else
            {
                result = BitConverter.ToSingle(binaryDataBigEndian, 0);
            }

            float infinity = 1f / 0f;

            bool isEqual = result == infinity;
            isEqual = result == float.PositiveInfinity;

            //Not A Number (NaN) representation: if E=255D (1111 1111) and F!=0D then the value will be NaN
            //0 1111 1111 000 0000 0000 0000 0000 0001
            //0111 1111 1000 0000 0000 0000 0000 0000
            //  7    F    8    0    0    0    0    1
            binaryDataBigEndian = new byte[4] { 0x7F, 0x80, 0x00, 0x01 };     //binaryData in Big Endian

            //S=+
            //E=128D (E=255, E-=127 to E=128)
            //F=1.0000001192092896 Normalized (000 0000 0000 0000 0000 0000 to 1.000 0000 0000 0000 0000 0001)
            //(+)(1.0000001192092896)2^(128)
            //1.0000001192092896*2^128
            //result will still be technically a number but IEE 754 said let this result represent NaN value
            if (BitConverter.IsLittleEndian)
            {
                //reverse binaryData in Big Endian to Little Endian
                byte[] binaryDataLittleEndian = new byte[binaryDataBigEndian.Length];
                Buffer.BlockCopy(binaryDataBigEndian, 0, binaryDataLittleEndian, 0, binaryDataLittleEndian.Length);
                Array.Reverse(binaryDataLittleEndian);

                result = BitConverter.ToSingle(binaryDataLittleEndian, 0);
            }
            else
            {
                result = BitConverter.ToSingle(binaryDataBigEndian, 0);
            }

            float NaN = 0f / 0f;

            isEqual = result == NaN;        //returns false as NaN comparison against NaN would returns false
            isEqual = result == float.NaN;  //returns false as NaN comparison against NaN would returns false
        }
    }
}
