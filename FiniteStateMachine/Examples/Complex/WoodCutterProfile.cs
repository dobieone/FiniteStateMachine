using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace MD.AI.Examples.Complex
{
    internal class WoodCutterProfile
    {
        public string Name { get; set; }
        public string State { get; set; }
        public int Energy { get; set; }
        public int Carrying { get; set; }

        public int CuttingSpeed { get; set; }
        public int EnergyCost { get; set; }

        public WoodCutterProfile()
        {
            Energy = 100;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"{Name}");
            sb.AppendLine($"  State:  {State}         ");
            sb.AppendLine($"  Energy: {Energy}        ");
            sb.AppendLine($"  Logs:   {Carrying}      ");
            return sb.ToString();
        }
    }
}
