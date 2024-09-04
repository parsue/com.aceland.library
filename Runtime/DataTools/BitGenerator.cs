using System;
using System.Collections.Generic;

namespace AceLand.Library.DataTools
{
    public sealed class BitGenerator
    {
        private BitGenerator() { }

        public static IEnumerable<byte> Generate(uint startValue, int requestLength = 32)
        {
            if (requestLength <= 0) yield break;

            DataUnion32 dataUnion = new();
            byte _valueLength = (byte)Convert.ToString(startValue, 2).Length;
            byte _shift = (byte)(32 - _valueLength);

            uint _firstState = (startValue << _shift) | 1;
            uint _nextState = _firstState;
            uint _count = 0;

            do 
            {
                dataUnion.UInt = (32 <= 4) switch
                {
                    true => (_nextState ^ (_nextState >> 1)) & 1,
                    false when 32 <= 16 => (_nextState ^ (_nextState >> 1) ^ (_nextState >> 2)) & 1,
                    _ => (_nextState ^ (_nextState >> 1) ^ (_nextState >> 3) ^ (_nextState >> 7)) & 1,
                };
                _nextState = (_nextState >> 1) | (dataUnion.UInt << 31);
                _count++;
                yield return dataUnion.Byte;
            } while (_count < requestLength && _firstState != _nextState);
        }
    }
}
