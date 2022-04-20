using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PodGame
{
    public class Player
    {
        public event EventHandler<DataEventArgs<string>> OnPlayerChanged;
        public Player(Action<int[][]> action)
        {
            _action = action;
            
        }
        /// <summary>
        /// 回显界面
        /// </summary>
        private Action<int[][]> _action;
        public string Name { get; set; }
        /// <summary>
        /// 玩家输入数据
        /// </summary>
        /// <returns></returns>
        public string GetKey()
        {
            OnPlayerChanged(this,new DataEventArgs<string> { Data= $"请{Name}输入"});
            var GetString = string.Empty;
            var r = true;
            while (r)
            {
                GetString = Console.ReadLine();
                ///确保录入的是三位数字
                if (GetString.Length != 3 || !int.TryParse(GetString, out int minumber))
                {
                    OnPlayerChanged(this, new DataEventArgs<string> { Data = $"请{Name}输入三位数字" });
                }
                else
                {
                    r = false;
                }
            }
            return GetString;
        }
        public bool Play(int[][] pods)
        {
            var state = true;
            var numbers = new List<int>();
            //显示图形
            _action(pods);
            while (state)
            {
                var number = GetKey();
                numbers = number.Select(x => x.ToInt()).ToList();
                var ps = pods.Select(x => x.Where(a => a == 1).Sum()).ToList();
                var dis = numbers.Parequet(ps);
                var v = false;
                //判断是是否超出范围
                v = CheckCC(numbers, ps, v);
                if (v)
                {
                    state = true;
                    OnPlayerChanged(this, new DataEventArgs<string> { Data = $"超出范围" });
                }
                else if (dis != 2)
                {
                    //跨行
                    OnPlayerChanged(this, new DataEventArgs<string> { Data = "不允许跨行" });
                    state = true;
                }
                else
                {
                    state = false;
                }
            }
            //更新pods
            pods = pods.UpdatePod(numbers);
            int d = pods.Sum(x => x.Where(a => a == 1).Sum());
            if (d == 0)
            {
                OnPlayerChanged(this, new DataEventArgs<string> { Data = $"{Name}输了" });
                return true;
            }
            return false;
        }
        private static bool CheckCC(List<int> numbers, List<int> ps, bool v)
        {
            for (int i = 0; i < numbers.Count; i++)
            {
                if (numbers[i] - ps[i] > 0)
                {
                    v = true;
                    break;
                }
            }
            return v;
        }
    }
}
