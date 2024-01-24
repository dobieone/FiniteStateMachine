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

        public WoodCutter(Blackboard<int> blackboard, WoodCutterProfile profile)
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

            var ms = new MoveState(_profile);
            var m = new State();
            m.OnEnter += ms.Enter;
            m.OnTick += ms.Tick;

            var rs = new RestState(_profile);
            var r = new State();
            r.OnEnter += rs.Enter;
            r.OnTick += rs.Tick;

            _fsm.AddState("Chop", c);
            _fsm.AddState("Transport", t);
            _fsm.AddState("Move", m);
            _fsm.AddState("Rest", r);
            _fsm.Start("Chop");
        }

        public void Run()
        {
            _fsm.Tick();
        }


    }
}
