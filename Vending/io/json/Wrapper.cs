using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vending
{
    public class Wrapper<T>
    {
        public T[] Wrapped { get; set; }

        [Newtonsoft.Json.JsonIgnore]
        public int Count => Wrapped != null ? Wrapped.Length : 0;
        public T this[int index] => Wrapped[index];
    }
}
