namespace Simulation.Interface.Models
{
    public struct MinusOneToOneRange
    {
        private double _value;

        public MinusOneToOneRange(double value)
        {
            _value = Truncate(value);
        }

        public static MinusOneToOneRange MinValue => -1;
        public static MinusOneToOneRange MaxValue => 1;

        public static implicit operator MinusOneToOneRange(double value)
        {
            return new MinusOneToOneRange(value);
        }

        public static implicit operator MinusOneToOneRange(float value)
        {
            return new MinusOneToOneRange(value);
        }

        public static implicit operator MinusOneToOneRange(int value)
        {
            return new MinusOneToOneRange(value);
        }

        public static implicit operator MinusOneToOneRange(uint value)
        {
            return new MinusOneToOneRange(value);
        }

        public static implicit operator MinusOneToOneRange(long value)
        {
            return new MinusOneToOneRange(value);
        }

        public static implicit operator MinusOneToOneRange(ulong value)
        {
            return new MinusOneToOneRange(value);
        }

        public static implicit operator MinusOneToOneRange(char value)
        {
            return new MinusOneToOneRange(value);
        }

        public static implicit operator MinusOneToOneRange(byte value)
        {
            return new MinusOneToOneRange(value);
        }

        public static implicit operator MinusOneToOneRange(short value)
        {
            return new MinusOneToOneRange(value);
        }

        public static implicit operator MinusOneToOneRange(ushort value)
        {
            return new MinusOneToOneRange(value);
        }

        public static implicit operator MinusOneToOneRange(bool value)
        {
            return new MinusOneToOneRange(value ? 1 : 0);
        }

        public static implicit operator bool(MinusOneToOneRange a)
        {
            return a.Value >= 0.5 ? true : false;
        }

        public static implicit operator double(MinusOneToOneRange a)
        {
            return a.Value;
        }

        public static implicit operator byte(MinusOneToOneRange a)
        {
            return (byte)(a ? 1 : 0);
        }

        public static MinusOneToOneRange operator +(MinusOneToOneRange a, MinusOneToOneRange b)
        {
            return a.Value + b.Value;
        }

        public static MinusOneToOneRange operator *(MinusOneToOneRange a, MinusOneToOneRange b)
        {
            return a.Value * b.Value;
        }

        public static MinusOneToOneRange operator /(MinusOneToOneRange a, MinusOneToOneRange b)
        {
            return a.Value / b.Value;
        }

        public static MinusOneToOneRange operator -(MinusOneToOneRange a, MinusOneToOneRange b)
        {
            return a.Value - b.Value;
        }

        private double Value
        {
            get { return _value; }
            set
            {
                _value = Truncate(value);
            }
        }

        private static double Truncate(double value)
        {
            return (value < MinValue) ? MinValue.Value : (value > MaxValue) ? MaxValue.Value : value;
        }

        public override bool Equals(object o)
        {
            try
            {
                return Value.Equals(((MinusOneToOneRange)o).Value);
            }
            catch
            {
                return false;
            }
        }

        public override int GetHashCode()
        {
            return _value.GetHashCode();
        }
    }
}
