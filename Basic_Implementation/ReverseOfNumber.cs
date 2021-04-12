/*Given few integers N, print Reverse of an integer (reversing its digits). If it has trailing zeroes, reverse should not print zeros.  
e.g. Reverse of 1200 will be 21 (rather than 0021). Negative numbers should reverse digits and must preserve sign.*/ 

using System;
using System.Linq;

class Test
{
    public static void Main(string[] args)
    {
      	String line;
        while ((line = Console.ReadLine()) != null) {
              int n = Int32.Parse(line);
            Console.WriteLine(NumberRev(n));
        }
    }
    static long NumberRev(int ip)
    {
        long reverseNum =0;
        while(ip!=0)
        {
            reverseNum=(reverseNum*10)+(ip%10);
            ip=ip/10;
        }
        return reverseNum;
    }
}

/* Input: 12345
   Output: 54321 */
