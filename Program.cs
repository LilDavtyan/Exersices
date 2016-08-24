using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        public static bool AreStringsAnagrams(string a, string b)
        {
            if (a == b)
                return true;
            int count;
            List<string> a1 = new List<string>();
            List<string> b1 = new List<string>();
            if (a.Length == b.Length)
            {
                for (int i = 0; i < a.Length; i++)
                {
                    a1.Add(a[i].ToString());
                }

                for (int i = 0; i < b.Length; i++)
                {
                    b1.Add(b[i].ToString());
                }

               
                foreach (var item1 in a1)
                {
                    count = 0;
                    foreach (var item2 in b1)
                    {
                        if (item1 == item2)
                        {
                            count++;
                            b1.Remove(item2);
                            break;
                        }
                                            
                    }
                   if (count==0)
                   {
                       return false;
                   }
                    
                }
                return true;
            }
            else return false;
        }
        static void Main(string[] args)
        {
            Console.WriteLine(AreStringsAnagrams("11111", "11111").ToString());
           Console.ReadLine();           

        }
    }
}
