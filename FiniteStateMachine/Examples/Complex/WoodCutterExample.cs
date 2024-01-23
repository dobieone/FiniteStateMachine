using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MD.AI.Examples.Complex
{
    internal class WoodCutterExample
    {
        private Blackboard<object> _blackboard;
        private List<WoodCutter> _woodCutters;
        public WoodCutterExample()
        {
            _blackboard = new Blackboard<object>
            {
                { "Logs", "0" }
            };

            var normal = new WoodCutter(
                _blackboard,
                new WoodCutterProfile()
                {
                    Name = "Normal Worker",
                    State = "",
                    Energy = 100,
                    ChoppingSpeed = 3,
                    ChoppingEnergyCost = 2,
                    MaxCarryAmount = 3,
                    TransportEnergy = 3,
                    TransportSpeed = 2,
                    MovementEnergy = 2,
                    MovementSpeed = 1,
                    RecoveryAmount = 8
                });

            var slow = new WoodCutter(
                _blackboard,
                new WoodCutterProfile()
                {
                    Name = "Lazy Worker",
                    State = "",
                    Energy = 100,
                    ChoppingSpeed = 5,
                    ChoppingEnergyCost = 4,
                    MaxCarryAmount = 1,
                    TransportEnergy = 4,
                    TransportSpeed = 3,
                    MovementEnergy = 3,
                    MovementSpeed = 2,
                    RecoveryAmount = 5,
                });

            var fast = new WoodCutter(
                _blackboard,
                new WoodCutterProfile()
                {
                    Name = "Fast Worker",
                    State = "",
                    Energy = 100,
                    ChoppingSpeed = 2,
                    ChoppingEnergyCost = 3,
                    MaxCarryAmount = 2,
                    TransportEnergy = 5,
                    TransportSpeed = 2,
                    MovementEnergy = 2,
                    MovementSpeed = 2,
                    RecoveryAmount = 3,
                });


            _woodCutters = new List<WoodCutter>
            {
                normal,
                slow,
                fast
            };
        }

        public void Run()
        {
            do
            {
                foreach (var wc in _woodCutters)
                {
                    wc.Run();
                }

                Console.SetCursorPosition(0, 0);
                Console.WriteLine($"Logs Stock: {_blackboard["Logs"].ToString()}      \n");
                
                foreach (var wc in _woodCutters)
                {
                    Console.WriteLine(wc.Profile.ToString());
                }

            } while (true);
        }
    }
}
