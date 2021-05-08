using System;
using Utils.Lib;
using System.Collections.Generic;

public class Program
{
    private const int M = (int)1e7;
    InputScanner sc = new InputScanner();
    public static Dictionary<int,List<int>> nTree = new Dictionary<int,List<int>>();
    public static Dictionary<int,List<int>> lMap = new Dictionary<int,List<int>>();
    public void Solve()
    {
        int t = sc.ReadInt();
        while(t>0)
        {
           nTree = new Dictionary<int,List<int>>();
            int n = sc.ReadInt();
            while(n>0)
            {
                var pc = sc.IntArray();
                AddNewNode(pc[0],pc[1]);
                n--;
            }
            int root = sc.ReadInt();
            fillLMap(root,1);
            foreach(var i in lMap)
            {
                Console.Write(i.Key+" ==> ");
                foreach(var j in i.Value)
                {
                    Console.Write(j+" ");
                }
                Console.WriteLine();
            }
            t--;
        }
    }
    static void fillLMap(int r,int l)
    {
       AddLevelMap(l,r);
       if(!nTree.ContainsKey(r)) return;
       foreach(var i in nTree[r])
       {
           fillLMap(i,l+1);
       }
    }
    static void AddLevelMap(int l,int i)
    {
        if(!lMap.ContainsKey(l))
        {
            lMap[l]=new List<int>();
        }
        lMap[l].Add(i);
    }
    static void PreOrder(int r)
    {
           
       Console.Write(r+" ");
       if(!nTree.ContainsKey(r)) return;
       foreach(var i in nTree[r])
       {
           PreOrder(i);
       }
    }
    static void AddNewNode(int p,int c)
    {
        if(!nTree.ContainsKey(p))
        {
            nTree[p]=new List<int>();
        }
        nTree[p].Add(c);
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
