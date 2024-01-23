using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MD.AI.Examples.Complex.States
{
    internal class RestState
    {

        private DateTime _timer;
        private string _stateName = "Resting";
        private int _seconds = 0;

        private WoodCutterProfile _profile;

        public WoodCutterProfile Profile
        {
            get { return _profile; }
            set { _profile = value; }
        }

        public RestState(WoodCutterProfile profile)
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
                _profile.Energy += _profile.RecoveryAmount;
                _seconds++;
                SetTimer(1);
            }
            if (_seconds >= 2)
            {
                int.TryParse(fsm.Blackboard["Logs"].ToString(), out int l);
                l--;
                fsm.Blackboard["Logs"] = l;

                _seconds = 0;
            }
            if (_profile.Energy >= 100)
            {
                fsm.ChangeState("Move");
            }
        }

        private void SetTimer(int duration)
        {
            var dt = DateTime.Now;
            _timer = dt.AddSeconds((double)duration);
        }
    }
}
