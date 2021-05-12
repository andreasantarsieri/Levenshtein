using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Santarsieri.Andrea._4H.Levenshtein
{
    class Program
    {
        public static string publicS { get; private set; }
        public static string publicT { get; private set; }

        static void Main(string[] args)
        {
            string s = "naso";
            publicS = s;
            string t = "casa";
            publicT = t;

            Console.WriteLine($"La distanza di Levenshtein tra {s} e {t} vale : {CalcoloDistanza(s,t)}");
            Console.ReadLine();


        }
        static int CalcoloDistanza(string s, string t)
        {
            int n = s.Length;
            int m = t.Length;

            if (n == 0)
                return m;
            if (m == 0)
                return n;

            int[,] distanza = new int[m + 1, n + 1];

            for (int i = 0; i < n + 1; i++)
                distanza[0, i] = i;
            for (int j = 0; j < m + 1; j++)
                distanza[j, 0] = j;

            for(int i = 0; i< n; i++)
            {
                for(int j = 0; j< m; j++)
                {
                    int costo;
                    if (t[j] == s[i])
                        costo = 0;
                    else
                        costo = 1;

                    distanza[j + 1, i + 1] = Minimo(distanza[j + 1 , i] + 1, distanza[j, i + 1] + 1, distanza[j , i] + costo); 
                }
            }
            return distanza[m,n];

        }
        static int Minimo(int a , int b, int c)
        {
            int ret = a;

            if (b < ret)
                ret = b;

            if (c < ret)
                ret = c;
            
            return ret;

        }

    }
    
}


