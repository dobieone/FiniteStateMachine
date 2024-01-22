using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MD.AI.Examples.Simple
{
    internal class SimpleExample
    {
        public void Run() 
        {

            var fsm = new FSM();

            var s = new SimpleExampleStates();

            var one = new State();
            one.OnEnter += s.StateOneEnter;
            one.OnTick += s.StateOneTick;
            one.OnExit += s.StateOneExit;

            var two = new State();
            two.OnEnter += s.StateTwoEnter;
            two.OnTick += s.StateTwoTick;
            two.OnExit += s.StateTwoExit;

            var three = new State();
            three.OnEnter += s.StateThreeEnter;
            three.OnTick += s.StateThreeTick;


            fsm.AddState("One", one)
                .AddState("Two", two)
                .AddState("Three", three);

            fsm.Start("One");

            do
            {
                fsm.Tick();
            } while (true);

        }

    }
}
