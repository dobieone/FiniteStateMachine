using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MD.AI.Examples.Complex
{
    internal class WoodCutterExample
    {
        private Blackboard<string> _blackboard;
        private List<WoodCutter> _woodCutters;
        public WoodCutterExample()
        {
            _blackboard = new Blackboard<string>
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
                    CuttingSpeed = 3,
                    EnergyCost = 2,
                });

            var slow = new WoodCutter(
                _blackboard,
                new WoodCutterProfile()
                {
                    Name = "Lazy Worker",
                    State = "",
                    Energy = 100,
                    CuttingSpeed = 5,
                    EnergyCost = 4,
                });


            _woodCutters = new List<WoodCutter>
            {
                normal,
                slow
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
                Console.WriteLine(_blackboard.ToString());
                
                foreach (var wc in _woodCutters)
                {
                    Console.WriteLine(wc.Profile.ToString());
                }

            } while (true);
        }
    }
}
