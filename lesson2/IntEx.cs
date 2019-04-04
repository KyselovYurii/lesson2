using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lesson2
{
    public abstract class IntEx
    {
        protected IntEx(int value)
        {
            Value = value;
        }

        public int Value { get; }
    }

    public class IntEx1 : IntEx
    {
        public IntEx1(int value)
            :base(value) { }

        public override int GetHashCode()
        {
            return 101 * ((Value >> 24) + 101 * ((Value >> 16) + 101 * (Value >> 8))) + Value;
        }
    }

    public class IntEx2 : IntEx
    {
        public IntEx2(int value)
            : base(value) { }

        public override int GetHashCode()
        {
            return ((Value >> 16) ^ Value) * 0x45d9f3b;
        }
    }

    public class IntEx3 : IntEx
    {
        public IntEx3(int value)
            : base(value) { }
        
        public override int GetHashCode()
        {
            return Value;
        }
    }

    public class IntBad : IntEx
    {
        public IntBad(int value)
            : base(value) { }
        
        public override int GetHashCode()
        {
            return 0;
        }
    }
}
