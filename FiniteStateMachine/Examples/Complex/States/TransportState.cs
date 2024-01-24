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
        private string _stateName = "Transporting";
        private int _seconds = 0;

        private WoodCutterProfile _profile;

        public WoodCutterProfile Profile
        {
            get { return _profile; }
            set { _profile = value; }
        }

        public TransportState(WoodCutterProfile profile)
        {
            _profile = profile;
        }

        public void Enter(FSM fsm)
        {
            _seconds = 0;
            SetTimer(1);
            _profile.State = _stateName;
        }
        public void Tick(FSM fsm)
        {
            if (DateTime.Now >= _timer)
            {
                _seconds++;
                _profile.Energy -= _profile.TransportEnergy;
                SetTimer(1);
            }
            if (_seconds >= _profile.TransportSpeed)
            {
                fsm.Blackboard["Logs"] += _profile.Carrying;
                _profile.Carrying = 0;

                if (_profile.Energy <= 10)
                {
                    fsm.ChangeState("Rest");
                }
                else
                {
                    fsm.ChangeState("Move");
                }
            }
        }

        private void SetTimer(int duration)
        {
            var dt = DateTime.Now;
            _timer = dt.AddSeconds((double)duration);
        }
    }
}
