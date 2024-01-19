using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MD.AI.Example
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var fsm = new FSM();

            var one = new State();
            one.OnEnter += StateOneEnter;
            one.OnTick += StateOneTick;
            one.OnExit += StateOneExit;

            var two = new State();
            two.OnEnter += StateTwoEnter;
            two.OnTick += StateTwoTick;
            two.OnExit += StateTwoExit;

            var three = new State();
            three.OnTick += StateThreeTick;


            fsm.AddState("One", one)
                .AddState("Two", two)
                .AddState("Three", three);

            fsm.Start("One");

            do
            {
                fsm.Tick();
            } while (true);

        }


        private static void StateOneEnter(FSM fsm)
        {
            Console.WriteLine("One - Enter");
        }
        private static void StateOneTick(FSM fsm)
        {
            Console.WriteLine("One - Tick");
            fsm.ChangeState("Two");
        }
        private static void StateOneExit(FSM fsm)
        {
            Console.WriteLine("One - Exit");
        }



        private static void StateTwoEnter(FSM fsm)
        {
            Console.WriteLine("Two - Enter");
        }
        private static void StateTwoTick(FSM fsm)
        {
            Console.WriteLine("Two - Tick");
            fsm.ChangeState("Three");
        }
        private static void StateTwoExit(FSM fsm)
        {
            Console.WriteLine("Two - Exit");
        }

        private static void StateThreeTick(FSM fsm)
        {
            Console.WriteLine("End...");
            Console.ReadLine();
            Environment.Exit(0);
        }



    }
}
