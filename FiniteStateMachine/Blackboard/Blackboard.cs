using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MD.AI
{
    public class Blackboard<T> : Dictionary<string, T>
    {
        public override string ToString()
        {
            var sb = new StringBuilder();
            foreach (var item in this)
            {
                sb.AppendLine(item.ToString());
            }

            return sb.ToString();
        }
    }
}
