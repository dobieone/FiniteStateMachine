using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MD.AI.Examples.Complex.States
{
    internal class RestState
    {
        public void Enter(FSM fsm)
        {
            Console.WriteLine("Rest - Enter");
        }
        public void Tick(FSM fsm)
        {
            Console.WriteLine("Rest - Tick");
        }
        public void Exit(FSM fsm)
        {
            Console.WriteLine("Rest - Exit");
        }
    }
}
