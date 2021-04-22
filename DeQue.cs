using System;
using Utils.Lib;
using Utils.Queue;
public class Program
{
    private const int M = (int)1e7;
    InputScanner sc = new InputScanner();
    public void Solve()
    {
        var t = sc.ReadInt();
       Queue q = new Queue(t);
        while (t > 0)
        {
            var ip = sc.Array();
            switch (ip[0])
            {
                case "push_front":
                        q.Push(ip[1]);
                        break;
                    case "push_back":
                        q.Enqueue(ip[1]);
                        break;
                    case "pop_front":
                        Console.WriteLine(q.Dequeue());
                        break;
                    case "pop_back":
                        Console.WriteLine(q.DequeueBack());
                        break;
            }
            t--;
        }
    }
    static void Main()
    {
        new Program().Solve();
    }
}
    
namespace Utils.Queue
{
    using System;
   public class Queue
    {
        private string[] a { get; set; }
        private int s;
        private int i;
        public Queue(int size)
        {
            s = size;
            a = new string[s];
            i = -1;
        }
        private string ShiftElement(bool front)
        {
            int n = a.Length;
            var op = front?a[0]:a[i];
            if(front)
            {
                for(int j=0;j<n-1;j++)
                {
                    if(!String.IsNullOrEmpty(a[j]))
                    {
                        a[j]=a[j+1];
                    }
                    else break;
                }
            }
            else
            {
                a[i]="";
            }
            i--;
            return op;
        }
        
        private void Empty()
        {
            a=new string[s];
            i=-1;
        }
      public void Enqueue(string e)
      {
            if (i == s-1)
            {
                Console.WriteLine("Queue is Full");
            }
            else
            {
                a[++i] = e;
            }
        }
    
        public string Dequeue()
        {
            if (i == -1)
            {
                return "Empty";
            }
            return ShiftElement(true);
        }
        
        public void Push(string e)
        {
            string[] b = a;
            Empty();
            Enqueue(e);
            for(int j=0;j<b.Length;j++)
            {
                if(!String.IsNullOrEmpty(b[j]))
                {
                    Enqueue(b[j]);
                }
            }
        }
        
        public string DequeueBack()
        {
            if (i == -1)
            {
                return "Empty";
            }
            return ShiftElement(false);
        }
        
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

                _line = s.Split(Separator);
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
            _line = s.Length == 0 ? new string[0] : s.Split(Separator);
            _index = _line.Length;
            return _line;
        }

        public int[] IntArray() => Array().Select(int.Parse).ToArray();
        public long[] LongArray() => Array().Select(long.Parse).ToArray();
        public double[] DoubleArray() => Array().Select(double.Parse).ToArray();
        public decimal[] DecimalArray() => Array().Select(decimal.Parse).ToArray();
    }
}
