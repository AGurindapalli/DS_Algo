using System;
using Utils.Lib;

public class Program
{
    private const int M = (int)1e7;
    InputScanner sc = new InputScanner();
    public void Solve()
    {
        Console.WriteLine("Hello World");
    }
    static void Main()
    {
        new Program().Solve();
    }
}

namespace Utils.Lib
{
    using System;
    using System.Linq;
    class InputScanner
    {
        private string[] _line;
        private int _index;
        private const char Separator = ' ';

        public InputScanner()
        {
            _line = new string[0];
            _index = 0;
        }

        public string Next()
        {
            if (_index >= _line.Length)
            {
                string s;
                do
                {
                    s = Console.ReadLine();
                } while (s.Length == 0);

                _line = s.Trim().Split(Separator);
                _index = 0;
            }

            return _line[_index++];
        }
        public string ReadLine()
        {
            _index = _line.Length;
            return Console.ReadLine();
        }

        public int ReadInt() => int.Parse(Next());
        public long ReadLong() => long.Parse(Next());
        public double ReadDouble() => double.Parse(Next());
        public decimal ReadDecimal() => decimal.Parse(Next());
        public char ReadChar() => Next()[0];
        public char[] ReadCharArray() => Next().ToCharArray();

        public string[] Array()
        {
            string s = Console.ReadLine();
            _line = s.Length == 0 ? new string[0] : s.Trim().Split(Separator);
            _index = _line.Length;
            return _line;
        }

        public int[] IntArray() => Array().Select(int.Parse).ToArray();
        public long[] LongArray() => Array().Select(long.Parse).ToArray();
        public double[] DoubleArray() => Array().Select(double.Parse).ToArray();
        public decimal[] DecimalArray() => Array().Select(decimal.Parse).ToArray();
    }
}
