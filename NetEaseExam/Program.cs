using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace qaExam2014
{
    class Program
    {
        static void Main1(string[] args)
        {
            string[] strarr ={"-865987453.36589"
                                 ,"73.23658"
                                ,"0.98"
                            ,"-0.000098784000"
                            ,"-00000001120.0"
                            ,"0"
                            ,"-0.0"
                            };
            BigNum[] bnarr=new BigNum[strarr.Length];
            for (int i = 0; i < strarr.Length; i++)
            {
                bnarr[i] = new BigNum(strarr[i]);
            }

            Level_1 l1 = new Level_1();

            string str = l1.p1_damageBonuses(strarr[0], strarr[1]);
            Console.WriteLine(str);

            int[] cards={1,2,3,4,5};
            int m = 0;
            int result = l1.p3_combo(cards, m);

            Console.Read();
        }
    }
}
