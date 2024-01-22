using MD.AI.Examples.Complex.States;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MD.AI.Examples.Complex
{
    internal class WoodCutter
    {
        private FSM _fsm;

        private WoodCutterProfile _profile;

        public WoodCutterProfile Profile
        {
            get { return _profile; }
            set { _profile = value; }
        }

        public WoodCutter(Blackboard<string> blackboard, WoodCutterProfile profile)
        {
            _fsm = new FSM(blackboard);
            _profile = profile;

            var cs = new ChopState(_profile);
            var c = new State();
            c.OnEnter += cs.Enter;
            c.OnTick += cs.Tick;

            var ts = new TransportState(_profile);
            var t = new State();
            t.OnEnter += ts.Enter;
            t.OnTick += ts.Tick;

            _fsm.AddState("Chop", c);
            _fsm.AddState("Transport", t);
            _fsm.Start("Chop");
        }

        public void Run()
        {
            _fsm.Tick();
        }


    }
}
