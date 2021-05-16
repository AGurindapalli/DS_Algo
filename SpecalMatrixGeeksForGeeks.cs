// https://practice.geeksforgeeks.org/problems/special-matrix4201/1
//Input
/* t = 1; r = 3 ; c= 3 ; k = 1; i=2 ; j= 0 */
/*
1
3
3
1
2
0
*/
using System;
using Utils.Lib;

public class Program
{
    private const int M = (int)1e7;
    InputScanner sc = new InputScanner();
    public void Solve()
    {
        int t = sc.ReadInt();
        while(t-->0)
        {
            int r = sc.ReadInt();
            int c = sc.ReadInt();
            int k = sc.ReadInt();
            int[,] arr = new int[r,c];
            while(k-->0)
            {
                int i = sc.ReadInt();
                int j = sc.ReadInt();
                arr[i,j]=-1;
            }
            Console.WriteLine(Path(arr));
        }
        
        
    }
    static int Path(int[,] arr)
    {
        int r = arr.GetLength(0);int c = arr.GetLength(1);
        int[,] dp = new int[r,c];
        for(int i=0;i<r;i++)
        {
            for(int j=0;j<c;j++)
            {
                if(i==0 || j==0)
                {
                    if(arr[i,j]==-1)
                    {
                        dp[i,j]=0;
                    }
                    else if(i==0 && j!=0)
                    {
                        if(dp[i,j-1]==0)
                        {
                            dp[i,j]=0;
                        }
                        else{
                            dp[i,j]=1;
                        }
                    }
                    else if(i!=0 && j==0)
                    {
                      if(dp[i-1,j]==0)
                        {
                            dp[i,j]=0;
                        }
                        else{
                            dp[i,j]=1;
                        }   
                    }
                    else dp[i,j]=1;
                }
                else if(arr[i,j]!=-1){
                    dp[i,j]=dp[i-1,j]+dp[i,j-1];
                }
                else dp[i,j]=0;
            }
        }
        return dp[r-1,c-1];
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
