using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PodGame
{
    public static class Extend
    {
        /// <summary>
        /// 将char转化成int
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public static int ToInt(this char c)
        {
            return int.Parse(c.ToString());
        }
        /// <summary>
        /// 获取集合中相同的数量
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static  int Parequet(this List<int> a, List<int> b)
        {
            int d=0;
            for (int i=0; i<a.Count; i++)
            {
                if (a[i] == b[i])
                {
                    d++;
                }
            }
            
          // var ld= (from  n in a join m in b on n equals m   select n ).ToArray();
            return d;
        }
        public static  int[][]  UpdatePod(this int [][] a, List<int> b)
        {

            for(int i = 0; i < a.Count(); i++)
            {
                for (int j = 0; j < a[i].Count(); j++)
                {
                    if (b[i] > j)
                    {
                        a[i][j] = 1;
                    }
                    else
                    {
                        a[i][j] = 0;
                    }
                }
            }
            return a;
        }
    }
}
