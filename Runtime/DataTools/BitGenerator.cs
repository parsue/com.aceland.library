using System;
using System.Collections.Generic;

namespace AceLand.Library.DataTools
{
    public abstract class BitGenerator
    {
        public static IEnumerable<byte> Generate(uint startValue, int requestLength = 32)
        {
            if (requestLength <= 0) yield break;

            DataUnion32 dataUnion = new();
            var valueLength = (byte)Convert.ToString(startValue, 2).Length;
            var shift = (byte)(32 - valueLength);

            var firstState = (startValue << shift) | 1;
            var nextState = firstState;
            var count = 0;

            do 
            {
                dataUnion.UInt = (32 <= 4) switch
                {
                    true => (nextState ^ (nextState >> 1)) & 1,
                    false when 32 <= 16 => (nextState ^ (nextState >> 1) ^ (nextState >> 2)) & 1,
                    _ => (nextState ^ (nextState >> 1) ^ (nextState >> 3) ^ (nextState >> 7)) & 1,
                };
                nextState = (nextState >> 1) | (dataUnion.UInt << 31);
                count++;
                yield return dataUnion.Byte;
            } while (count < requestLength && firstState != nextState);
        }
    }
}
