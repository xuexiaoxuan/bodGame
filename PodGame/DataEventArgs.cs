using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PodGame
{
    public class DataEventArgs<T>: EventArgs
    {
        public T Data { get; set; }
    }
}
