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
        public int Carrying { get; set; }
        public int Chopped { get; set; }

        public int ChoppingSpeed { get; set; }
        public int ChoppingEnergyCost { get; set; }
        public int MaxCarryAmount { get; set; }

        public int TransportEnergy { get; set; }
        public int TransportSpeed { get; set; }

        public int RecoveryAmount { get; set; }

        public int MovementEnergy { get; set; }
        public int MovementSpeed { get; set; }

        private int _energy;

        public int Energy
        {
            get { return _energy; }
            set { 
                _energy = value;
                if (_energy > 100)
                    _energy = 100;
                if (_energy < 0)
                    _energy = 0;
            }
        }

        public WoodCutterProfile()
        {
            Energy = 100;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"{Name}");
            sb.AppendLine($"  State:    {State}         ");
            sb.AppendLine($"  Energy:   {Energy}        ");
            sb.AppendLine($"  Carrying: {Carrying}      ");
            sb.AppendLine($"  Chopped:  {Chopped}       ");
            return sb.ToString();
        }
    }
}
