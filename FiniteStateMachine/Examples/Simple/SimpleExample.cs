using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MD.AI.Examples.Simple
{
    internal class SimpleExample
    {
        public void StateOneEnter(FSM fsm)
        {
            Console.WriteLine("State One - Enter");
        }
        public void StateOneTick(FSM fsm)
        {
            Console.WriteLine("State One - Tick");
            fsm.ChangeState("Two");
        }
        public void StateOneExit(FSM fsm)
        {
            Console.WriteLine("State One - Exit");
        }
        public void StateTwoEnter(FSM fsm)
        {
            Console.WriteLine();
            Console.WriteLine("State Two - Enter");
        }
        public void StateTwoTick(FSM fsm)
        {
            Console.WriteLine("State Two - Tick");
            fsm.ChangeState("Three");
        }
        public void StateTwoExit(FSM fsm)
        {
            Console.WriteLine("State Two - Exit");
        }
        public void StateThreeEnter(FSM fsm)
        {
            Console.WriteLine();
            Console.WriteLine("State Three - Enter");
        }
        public void StateThreeTick(FSM fsm)
        {
            Console.WriteLine("State Three - Tick");
            Console.WriteLine("Exiting...");
            Console.ReadLine();
            Environment.Exit(0);
        }

    }
}
