using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MD.AI.Examples.Complex.States
{
    internal class TransportState
    {
        private DateTime _timer;
        private int _duration = 5;
        private string _stateName = "Transporting";

        private WoodCutterProfile _profile;

        public WoodCutterProfile Profile
        {
            get { return _profile; }
            set { _profile = value; }
        }


        public TransportState(WoodCutterProfile profile)
        {
            _profile = profile;
            _duration = profile.CuttingSpeed;
        }

        public void Enter(FSM fsm)
        {
            //SetTimer(_duration);
            _profile.State = _stateName;
            //_profile.Carrying = 0;
        }
        public void Tick(FSM fsm)
        {
            //Console.WriteLine("Transport - Tick");
        }
        public void Exit(FSM fsm)
        {
            //Console.WriteLine("Transport - Exit");
        }
    }
}
